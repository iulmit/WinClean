// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;

using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.AppDir;

/// <summary>Represents the scripts dir of the application root directory.</summary>
public class ScriptsDir
{
    #region Private Constructors

    private ScriptsDir()
    {
        Info = GetOrCreate();

        DirectoryInfo GetOrCreate()
        {
            string scriptsDirpath = Path.Join(Program.AppDir.FullName, "Scripts");

            DirectoryInfo created = null!;
            try
            {
                created = Directory.CreateDirectory(scriptsDirpath);
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.CantCreateDirectory(e, scriptsDirpath, () => created = GetOrCreate());
            }
            return created;
        }
    }

    #endregion Private Constructors

    #region Public Properties

    public static ScriptsDir Instance { get; } = new();

    /// <summary>The <see cref="DirectoryInfo"/> representing the scripts directory.</summary>
    public DirectoryInfo Info { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Joins the specified path components with the path of the scripts directory.</summary>
    /// <param name="paths">The path components to join with the scripts dir.</param>
    /// <returns>The concatenated path.</returns>
    public string Join(params string[] paths) => Path.Join(paths.Prepend(Info.FullName).ToArray());

    /// <summary>Loads all the scripts present in the scripts directory.</summary>
    /// <param name="loadInto">The listView to load the scripts into.</param>
    /// <returns>The scripts previously saved into the scripts dir.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="loadInto"/> is <see langword="null"/>.</exception>
    public IEnumerable<Script> LoadAllScripts()
    {
        foreach (FileInfo script in Info.EnumerateFiles("*.xml"))
        {
            yield return new Script(script.Name);
        }
    }

    #endregion Public Methods
}
