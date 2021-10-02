// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using static RaphaëlBardini.WinClean.Logic.Helpers;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>A script as seen in the <see cref="Operational"/> layer. Performs low level operations.</summary>
    public abstract class Script
    {
        #region Public Constructors

        /// <summary>Generates a new instance of the <see cref="Script"/> class. Throws if <paramref name="filename"/> is an invalid file path or name or if the file is inaccessible.</summary>
        /// <inheritdoc cref="Path.Combine(string, string)" path="/exception"/>
        protected Script(string filename) => FullPath = Path.Combine(Constants.ScriptsDirPath, Path.GetFileName(filename));

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>The comment markers of the corresponding script langage.</summary>
        protected IEnumerable<StringTag> Comments { get; set; }

        /// <summary>The arguments of the script engine program.</summary>
        protected string ScriptHostArguments { get; set; }

        /// <summary>The executable file path of the script engine program.</summary>
        protected string ScriptHostExecutable { get; set; }

        #endregion Protected Properties

        #region Public Properties

        /// <summary>The script file's path.</summary>
        public string FullPath { get; }

        #endregion Public Properties

        #region Public Methods

        public void Execute()
        {
            ToString().Log($"Script execution");
            using Process process = Process.Start(new ProcessStartInfo(ScriptHostExecutable, ScriptHostArguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "RunAs", // Run as administrator
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            });

            if (process.WaitForExit(Constants.ScriptTimeoutSeconds))
            {
                "Script terminated".Log("Script execution");
            }
            else
            {
                "Script hung!".Log("Script execution", TraceEventType.Error);
                throw new Logic.HungScriptException(this);
            }
            process.StandardError.ReadToEnd().Log($"Standard error stream of script execution");// chaud possible deadlock
            process.StandardOutput.ReadToEnd().Log($"Standard output stream of script execution");// chaud possible deadlock
        }

        /// <summary>Finds the first comment of the script's file.</summary>
        /// <returns>
        /// The first valid comment of the script's file without including the comment marker specified by the script langage, or <see cref="string.Empty"/> if nothing is found or if there was an
        /// exception trying to access the file.
        /// </returns>
        /// <remarks>May return something wrong, as this does not care about escape characters that could be used in string literals.</remarks>
        public string FirstComment()
        {
            try
            {
                return File.ReadAllText(FullPath).Between(Comments);
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

        public override string ToString() => $"[{nameof(FullPath)} = {FullPath}]";

        #endregion Public Methods
    }
}
