// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

using RaphaëlBardini.WinClean.Logic;

using static System.Linq.Enumerable;

namespace RaphaëlBardini.WinClean.Operational
{
    public interface IScriptHost
    {
        #region Protected Classes

        protected sealed class IncompleteArguments
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
                if (FormattableStringFactory.Create(args ?? throw new ArgumentNullException(nameof(args)), "dummy").ArgumentCount != 1)
                    throw new ArgumentException("Not exactly 1 argument to the format string", nameof(args));
                _args = args;
            }

            #endregion Public Constructors

            #region Public Methods

            public string Complete(Path script) => string.Format(CultureInfo.InvariantCulture, _args, script);

            public override string ToString() => _args;

            #endregion Public Methods
        }

        #endregion Protected Classes

        #region Public Properties

        public string DisplayName => ShellProperty.GetFileDescription(Executable);

        #endregion Public Properties

        #region Protected Properties

        protected IncompleteArguments Arguments { get; }
        protected Encoding Encoding { get; }
        protected Path Executable { get; }
        protected IReadOnlyCollection<Extension> SupportedExtensions { get; }

        #endregion Protected Properties

        #region Public Methods

        public void Execute(Path script)
        {
            if (!SupportedExtensions.Any((ext) => ext == script.Extension))
                throw new BadFileExtensionException(script.Extension);
            ToString().Log("Script execution");
            /*if (!File.Exists(ScriptPath))
                throw new FileNotFoundException("Fichier de script introuvable ou inacessible.", ScriptPath.Filename);*/
            using Process host = Process.Start(new ProcessStartInfo(Executable, Arguments.Complete(script))
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding,
                StandardOutputEncoding = Encoding,
            });

            // placeholder -- simulate the time a script would take to complete.
            System.Threading.Thread.Sleep(1000);
            WaitForScriptEnd(host, script);
            ToUnicode(host.StandardError).Log($"Error stream");
            ToUnicode(host.StandardOutput).Log($"Output stream");
        }

        /// <inheritdoc cref="object.ToString()"/>
        public sealed string ToString() => $"{Executable.Filename} {Arguments}";

        #endregion Public Methods

        #region Private Methods

        private static void WaitForScriptEnd(Process p, Path script)
        {
            if (!(p ?? throw new ArgumentNullException(nameof(p))).WaitForExit(Constants.ScriptTimeoutMilliseconds))
            {
                ErrorDialog.HungScript(script, Program.MainForm,
                restart: () =>
                {
                    p.Kill(true);
                    _ = p.Start();
                },
                kill: () =>
                {
                    p.Kill(true);
                },
                ignore: () =>
                {
                    WaitForScriptEnd(p, script);
                });
            }
        }

        /// <summary>Reads everything in a stream and returns the converted Uunicode text.</summary>
        /// <param name="stream">A text stream in a non-unicode encoding.</param>
        /// <returns>The text of <paramref name="stream"/> in Unicode.</returns>
        private string ToUnicode(StreamReader stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));
            using StreamReader convertedStream = new(Encoding.CreateTranscodingStream(stream.BaseStream, Encoding, Encoding.Unicode, true));
            return convertedStream.ReadToEnd();
        }

        #endregion Private Methods
    }
}
