// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>A script as seen in the <see cref="Operational"/> layer. Performs low level operations.</summary>
    public abstract class Script : IEquatable<Script>
    {
        #region Public Constructors

        /// <summary>Generates a new instance of the <see cref="Script"/> class. Throws if <paramref name="filename"/> is an invalid file path or name or if the file is inaccessible.</summary>
        /// <inheritdoc cref="Path.GetFullPath(string)" path="/exception"/>
        public Script(string filename)
        {
            FullPath = Path.GetFullPath(filename);
        }

        #endregion Public Constructors

        #region Protected Fields

        /// <summary>The comment markers of the corresponding script langage.</summary>
        protected StringTag[] _comments;

        /// <summary>The arguments of the script engine program.</summary>
        protected string _scriptHostArguments;

        /// <summary>The executable file path of the script engine program.</summary>
        protected string _scriptHostExecutable;

        #endregion Protected Fields

        #region Public Properties

        /// <summary>The script file's path.</summary>
        public string FullPath { get; }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj) => Equals(obj as Script);

        public bool Equals(Script other) => other != null
                   && FullPath.Equals(other.FullPath)
                   && _comments.SequenceEqual(other._comments)
                   && _scriptHostArguments.Equals(other._scriptHostArguments)
                   && _scriptHostExecutable.Equals(other._scriptHostExecutable);

        public override string ToString() => $"[{nameof(FullPath)} = {FullPath}]";

        public void Execute()
        {
            do
            {
                ToString().Log($"Script execution");
                using Process process = Process.Start(new ProcessStartInfo(_scriptHostExecutable, _scriptHostArguments)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "RunAs", // Run as administrator
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                });

                if (!process.WaitForExit(Constants.SCRIPT_TIMEOUT))
                {
                    $"Script is hung ! Still running after {Constants.SCRIPT_TIMEOUT} milliseconds.".Log("Script execution", TraceEventType.Warning);
                }
                else
                {
                    "Script terminated".Log("Script execution");
                }
                process.StandardError.ReadToEnd().Log($"Standard error stream of script execution");// chaud possible deadlock
                process.StandardOutput.ReadToEnd().Log($"Standard output stream of script execution");// chaud possible deadlock
            } while (PromptRetryHungScript());
        }

        /// <summary>Finds the first comment of the script's file.</summary>
        /// <returns>The first valid comment of the script's file without including the comment marker, or and empty string if nothing is found
        /// or if there was an exception trying to access the file.</returns>
        /// <remarks>May return something wrong, as this does not care about escape characters.</remarks>
        public string FirstComment()
        {
            try
            {
                return File.ReadAllText(FullPath).Between(_comments);
            }
            catch (Exception e) when (e is IOException
                                        or ArgumentException
                                        or NotSupportedException
                                        or System.Security.SecurityException
                                        or UnauthorizedAccessException)
            {
                return string.Empty;
            }
        }

        public override int GetHashCode() => HashCode.Combine(FullPath);

        #endregion Public Methods

        #region Protected Methods

        protected bool PromptRetryHungScript()
        {
            $"The script executed for {Constants.SCRIPT_TIMEOUT} milliseconds. It may be hung. Prompting user on what to do.".Log("Hung script", TraceEventType.Warning);
            DialogResult result = MessageBox.Show($@"Le script {FullPath} est toujours en cours d'exécution. Cela peut-être causé par une boucle infinie dans le script.

• Pour quitter le programme, cliquez sur ""Abandonner"".
• Pour réessayer d'exécuter le script, cliquez sur ""Réessayer"".
• Pour arrêter le script et passer au script suivant, cliquez sur ""Ignorer"".
• En cas de fermeture de la boîte de dialogue par son menu Système, l'action interprétée sera ""Ignorer"""

, "Avertissement", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Abort:
                    "The user choose to exit the program.".Log("Hung script", TraceEventType.Information);
                    Helpers.Exit();
                    return false;//This shouldn't execute but it's required
                case DialogResult.Retry:
                    "The user choose to restart the script".Log("Hung script", TraceEventType.Information);
                    return true;
                default:
                    "The use choose to ignore the hung script".Log("Hung script", TraceEventType.Information);
                    return false;
            }
        }

        #endregion Protected Methods
    }
}
