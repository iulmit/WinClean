// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
    public sealed class ScriptHost : IScriptHost
    {
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
        public static ScriptHost Cmd => new()
        {
            Arguments = new("/d /c \"\"{0}\"\""),
            Encoding = Encoding.GetEncoding(850),
            Executable = new(Environment.GetEnvironmentVariable("comspec", EnvironmentVariableTarget.Machine)),
            SupportedExtensions = new(".cmd", ".bat")
        };

        /// <summary>The Windows PowerShell script host.</summary>
        public static ScriptHost PowerShell => new()
        {
            Arguments = new("-WindowStyle hidden -NoLogo -NoProfile -NonInteractive -File & \"{0}\""),
            Encoding = Encoding.GetEncoding(1252),
            Executable = new(Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe")),
            SupportedExtensions = new(".ps1")
        };

        /// <summary>The Windows Registry Editor script host.</summary>
        public static ScriptHost Regedit => new()
        {
            Arguments = new("/s {0}"),
            Encoding = Encoding.Unicode,
            Executable = new(Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "regedit.exe")),
            SupportedExtensions = new(".reg")
        };

        /// <summary>User friendly name for the script host.</summary>
        public string DisplayName => ShellProperty.GetFileDescription(Executable);

        /// <inheritdoc/>
        public string Filter => Helpers.MakeOpenFileDialogFilter(SupportedExtensions);

        #endregion Public Properties

        #region Private Properties

        private IncompleteArguments Arguments { get; init; }

        private Encoding Encoding { get; init; }

        private FileInfo Executable { get; init; }

        /// <summary>Extensions of the scripts the script host program can run.</summary>
        private ExtensionGroup SupportedExtensions { get; init; }

        #endregion Private Properties



        #region Public Methods

        /// <summary>Executes the script host with the specified script file.</summary>
        /// <param name="script">The path of the script file to run.</param>
        /// <exception cref="ArgumentNullException"><paramref name="script"/>'s <see langword="null"/>.</exception>
        /// <exception cref="BadFileExtensionException"><paramref name="script"/>'s extension is not supported.</exception>
        /// <inheritdoc cref="Helpers.ThrowIfUnacessible(FileInfo, FileAccess)" path="/exception"/>
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
            script.ThrowIfUnacessible(FileAccess.Read);

            ToString().Log("Script execution");
            using Process host = Process.Start(new ProcessStartInfo(Executable.FullName, Arguments.Complete(script))
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding,
                StandardOutputEncoding = Encoding,
            });

            // placeholder -- simulate the time a script would take to complete.
            Thread.Sleep(2000);

            WaitForScriptEnd(host, script);
            ToUnicode(host.StandardError).Log($"Error stream");
            ToUnicode(host.StandardOutput).Log($"Output stream");
        }

        /// <inheritdoc/>
        public override string ToString() => $"{Executable.Name} {Arguments}";

        #endregion Public Methods

        #region Private Methods

        private static void WaitForScriptEnd(Process p, FileInfo script)
        {
            Assert(p is not null);

            if (!p.WaitForExit(Convert.ToInt32(IScriptHost.Timeout.TotalMilliseconds)))
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

            using StreamReader convertedStream = new(Encoding.CreateTranscodingStream(stream.BaseStream, Encoding, Encoding.Unicode, true));
            return convertedStream.ReadToEnd();
        }

        #endregion Private Methods

        #region Private Classes

        /// <summary>Formattable executable arguments with a single file path argument.</summary>
        private sealed class IncompleteArguments
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
