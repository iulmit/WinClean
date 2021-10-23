// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using RaphaëlBardini.WinClean.Logic;

using static System.Linq.Enumerable;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>
    /// Represents a program that accepts a file in it's command-line arguments. The afro-mentionned file has to contain code be
    /// able to have side-effects.
    /// </summary>
    public interface IScriptHost
    {
        #region Public Properties

        /// <summary>Maximum time a script can execute without displaying a warning to the user.</summary>
        public static TimeSpan Timeout { get; set; } = Properties.Settings.Default.ScriptTimeout;

        #endregion Public Properties

        #region Protected Classes

        /// <summary>Formattable executable arguments with a single file path argument.</summary>
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
                Debug.Assert(FormattableStringFactory.Create(args, "dummy").ArgumentCount != 1, $"Not exactly 1 argument to {nameof(args)}");
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

        #endregion Protected Classes



        #region Public Properties

        /// <summary>The host user-friendly display name.</summary>
        public string DisplayName => ShellProperty.GetFileDescription(Executable);

        #endregion Public Properties

        #region Protected Properties

        /// <summary>The command-line arguments.</summary>
        protected IncompleteArguments Arguments { get; }

        /// <summary>The default output encoding.</summary>
        protected Encoding Encoding { get; }

        /// <summary>The executable file.</summary>
        protected FileInfo Executable { get; }

        /// <summary>The supported script file extensions.</summary>
        protected IReadOnlyCollection<string> SupportedExtensions { get; }

        #endregion Protected Properties

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
            if (!SupportedExtensions.Any((ext) => ext == script.Extension))
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
            System.Threading.Thread.Sleep(2000);
            WaitForScriptEnd(host, script);
            ToUnicode(host.StandardError).Log($"Error stream");
            ToUnicode(host.StandardOutput).Log($"Output stream");
        }

        /// <inheritdoc cref="object.ToString()"/>
        public sealed string ToString() => $"{Executable.Name} {Arguments}";

        #endregion Public Methods

        #region Private Methods

        private static void WaitForScriptEnd(Process p, FileInfo script)
        {
            if (!(p ?? throw new ArgumentNullException(nameof(p))).WaitForExit(Convert.ToInt32(Timeout.TotalMilliseconds)))
            {
                ErrorDialog.HungScript(script,
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
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using StreamReader convertedStream = new(Encoding.CreateTranscodingStream(stream.BaseStream, Encoding, Encoding.Unicode, true));
            return convertedStream.ReadToEnd();
        }

        #endregion Private Methods
    }
}
