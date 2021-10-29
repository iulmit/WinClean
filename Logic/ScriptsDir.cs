// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Provides methods representing the available operations with the applicaton scripts dir.</summary>
    public static class ScriptsDir
    {
        #region Public Constructors

        static ScriptsDir()
        {
            Info = GetOrCreate();

            DirectoryInfo GetOrCreate()
            {
                DirectoryInfo created = null;
                try
                {
                    created = Directory.CreateDirectory(Path.Join(Program.InstallDir.FullName, "Scripts"));
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ErrorDialog.CantCreateScriptsDir(e, () => created = GetOrCreate(), Program.Exit);
                }
                Assert(created is not null);
                return created;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>The <see cref="DirectoryInfo"/> representing the scripts directory.</summary>
        public static DirectoryInfo Info { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>Loads all the scripts present in the scripts directory.</summary>
        /// <param name="loadInto">The listView to load the scripts into.</param>
        /// <returns>The scripts previously saved into the scripts dir.</returns>
        /// <remarks>Lazy <see langword="yield return"/> iterator.</remarks>
        public static void LoadAllScripts(ListView loadInto)
        {
            _ = loadInto ?? throw new ArgumentNullException(nameof(loadInto));

            foreach (FileInfo script in Info.EnumerateFiles("*.xml"))
            {
                _ = loadInto.Items.Add(new Script(script.Name, loadInto));
            }
        }

        #endregion Public Methods
    }
}
