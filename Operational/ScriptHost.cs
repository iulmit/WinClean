// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <inheritdoc cref="IScriptHost"/>
    public class ScriptHost : IScriptHost
    {
        #region Private Fields

        private readonly IncompleteArguments _arguments;

        private readonly Encoding _encoding;

        private readonly FileInfo _executable;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="ScriptHost"/> class.</summary>
        /// <param name="executable">The filename of the script host program's executable.</param>
        /// <param name="arguments">
        /// A formattable string representing the appropriate arguments to run the script host, hidden, with a single script. It
        /// must have exactly 1 argument, the path of the script file to execute.
        /// </param>
        /// <param name="encoding">The default encoding of the script host.</param>
        /// <param name="supportedExtensions">The extensions the script host supports.</param>
        /// <exception cref="ArgumentNullException">One ore more parameters are <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="arguments"/> does not contain exactly 1 formattable argument..</exception>
        public ScriptHost(FileInfo executable, string arguments, Encoding encoding, ExtensionGroup supportedExtensions)
        {
            _executable = executable;
            _arguments = new(arguments);
            _encoding = encoding;
            SupportedExtensions = supportedExtensions;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>Creates a new <see cref="ScriptHost"/> object from a script file extension.</summary>
        /// <param name="ext">The file extension to create a <see cref="ScriptHost"/> from.</param>
        /// <exception cref="BadFileExtensionException"><paramref name="ext"/> is not supported by any known <see cref="ScriptHost"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="ext"/> is <see langword="null"/>.</exception>
        /// <returns>A known <see cref="ScriptHost"/>.</returns>
        public static ScriptHost FromFileExtension(string ext)
            => ext is null
                   ? throw new ArgumentNullException(nameof(ext))
                   : Cmd.SupportedExtensions.Contains(ext)
                       ? Cmd
                       : PowerShell.SupportedExtensions.Contains(ext)
                           ? PowerShell
                           : Regedit.SupportedExtensions.Contains(ext)
                               ? Regedit
                               : throw new BadFileExtensionException(ext);

        #endregion Public Methods

        #region Public Properties

        /// <summary>The Windows Command Line interpreter (cmd.exe) script host.</summary>
        public static ScriptHost Cmd
            => new(executable: new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine)),
                   arguments: "/d /c \"\"{0}\"\"",
                   encoding: Encoding.GetEncoding(850),
                   supportedExtensions: new(".cmd", ".bat"));

        /// <summary>The Windows PowerShell script host.</summary>
        public static ScriptHost PowerShell
           => new(executable: new(Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe")),
                  arguments: new("-WindowStyle hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\""),
                  encoding: Encoding.GetEncoding(1252),
                  supportedExtensions: new(".ps1"));

        /// <summary>The Windows Registry Editor script host.</summary>
        public static ScriptHost Regedit
            => new(executable: new(Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe")),
                   arguments: new("/s {0}"),
                   encoding: Encoding.Unicode,
                   supportedExtensions: new(".reg"));

        /// <inheritdoc/>
        public string DisplayName => ShellProperty.GetFileDescription(_executable);

        /// <inheritdoc/>
        public ExtensionGroup SupportedExtensions { get; init; }

        #endregion Public Properties



        #region Public Methods

        /// <inheritdoc/>
        public void Execute(FileInfo script)
        {
            if (script is null)
            {
                throw new ArgumentNullException(nameof(script));
            }
            if (!SupportedExtensions.Contains(script.Extension))
            {
                throw new BadFileExtensionException(script.Extension);
            }

            try
            {
                script.ThrowIfUnacessible(FileAccess.Read);
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.ScriptInacessible(script.Name, e, () => Execute(script), null/*chaud : delete script*/);
            }

            ToString().Log("Script execution");
            using Process host = Process.Start(new ProcessStartInfo(_executable.FullName, _arguments.Complete(script))
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = _encoding,
                StandardOutputEncoding = _encoding,
            });

            // placeholder -- simulate the time a script would take to complete.
            Thread.Sleep(2000);

            WaitForScriptEnd(host, script);
            ToUnicode(host.StandardError).Log($"Error stream");
            ToUnicode(host.StandardOutput).Log($"Output stream");
        }

        /// <inheritdoc/>
        public void Execute(string code)
        {
            FileInfo tmpScriptFile = new(Path.GetTempFileName());
            tmpScriptFile.CreateText().Write(code);
            Execute(tmpScriptFile);
        }

        /// <inheritdoc/>
        public override string ToString() => $"{_executable.Name} {_arguments}";

        #endregion Public Methods

        #region Private Methods

        private static void WaitForScriptEnd(Process p, FileInfo script)
        {
            Assert(p is not null);

            if (!p.WaitForExit(Convert.ToInt32(Properties.Settings.Default.ScriptTimeout.TotalMilliseconds)))
            {
                ErrorDialog.HungScript(script.Name,
                restart: () =>
                {
                    p.Kill(true);
                    _ = p.Start();
                },
                kill: () => p.Kill(true),
                ignore: () => WaitForScriptEnd(p, script));
            }
        }

        /// <summary>Reads everything in a stream and returns the converted Uunicode text.</summary>
        /// <param name="stream">A text stream in a non-unicode encoding.</param>
        /// <returns>The text of <paramref name="stream"/> in Unicode.</returns>
        private string ToUnicode(StreamReader stream)
        {
            Assert(stream is not null);

            using StreamReader convertedStream = new(Encoding.CreateTranscodingStream(stream.BaseStream, _encoding, Encoding.Unicode, true));
            return convertedStream.ReadToEnd();
        }

        #endregion Private Methods

        #region Private Classes

        /// <summary>Formattable executable arguments with a single file path argument.</summary>
        private readonly struct IncompleteArguments
        {
            #region Private Fields

            private readonly string _args;

            #endregion Private Fields

            #region Public Constructors

            /// <param name="args">Formattable string with 1 argument, the path of the script file.</param>
            /// <exception cref="ArgumentException"><paramref name="args"/> does not contain exactly one argument.</exception>
            /// <exception cref="ArgumentNullException"><paramref name="args"/> is <see langword="null"/>.</exception>
            public IncompleteArguments(string args)
            {
                Assert(FormattableStringFactory.Create(args, "dummy").ArgumentCount == 1, $"Not exactly 1 argument to {nameof(args)}");
                _args = args;
            }

            #endregion Public Constructors

            #region Public Methods

            /// <summary>Completes the arguments with the specified script file.</summary>
            /// <param name="script">The file to complete the arguments with.</param>
            /// <returns>The completed arguments</returns>
            public string Complete(FileInfo script) => string.Format(CultureInfo.InvariantCulture, _args, script);

            /// <inheritdoc/>
            public override string ToString() => _args;

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}
