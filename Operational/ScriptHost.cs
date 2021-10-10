// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using RaphaëlBardini.WinClean.Logic;

using static System.Linq.Enumerable;

namespace RaphaëlBardini.WinClean.Operational
{
    public abstract class ScriptHost
    {
        #region Protected Constructors

        protected ScriptHost(Path script)
        {
            if (SupportedExtensions.Any((ext) => ext == script.Extension))
                ScriptPath = script;
            else
                throw new BadFileExtensionException(script.Extension);
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>The user friendly name of the corresponding script host.</summary>
        public string DisplayName => ShellProperty.GetFileDescription(Executable);

        public Path ScriptPath { get; set; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>The script engine program's executable arguments.</summary>
        protected abstract string Arguments { get; }

        /// <summary>The script engine program's executable path.</summary>
        protected abstract Path Executable { get; }

        /// <summary>The supported script file extensions for this host.</summary>
        protected abstract IEnumerable<Extension> SupportedExtensions { get; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>Executes the sript host program to run the script.</summary>
        /// <exception cref="FileNotFoundException"><see cref="ScriptPath"/> doesn't exist or is inacessible.</exception>
        public void Execute()
        {
            if (!File.Exists(ScriptPath))
                throw new FileNotFoundException("Fichier de script introuvable", ScriptPath.Filename);
            using Process host = Process.Start(new ProcessStartInfo(Executable, Arguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            });

            System.Threading.Thread.Sleep(1000);
            WaitForExit(host);

            host.StandardError.ReadToEnd().Log($"Standard error stream of script execution");
            host.StandardOutput.ReadToEnd().Log($"Standard output stream of script execution");
        }

        /// <inheritdoc cref="object.ToString()"/>
        /// <remarks>Overriden in <see cref="ScriptHost"/>.</remarks>
        public override string ToString() => $"{Executable.Filename} {Arguments}";

        private void WaitForExit(Process p)
        {
            if (!p.WaitForExit(Constants.ScriptTimeoutMilliseconds))
            {
                ErrorDialog.HungScript(ScriptPath).ShowIgnoreKillRestart(onIgnore: () =>
                {
                    WaitForExit(p);
                },
                onKill: () =>
                {
                    p.Kill(true);
                },
                onRestart: () =>
                {
                    p.Kill(true);
                    _ = p.Start();
                },
                owner: Program.MainForm);
            }
        }

        #endregion Public Methods
    }
}
