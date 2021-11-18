﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.Logic;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            DirectoryInfo info = new(Path.Join(Program.AppDir.FullName, "Scripts"));
            try
            {
                info.Create();
            }
            catch (Exception e) when (e.FileSystem())
            {
                ErrorDialog.CantCreateDirectory(e, info, () => info = GetOrCreate());
            }
            return info;
        }
    }

    #endregion Private Constructors

    #region Public Properties

    public static ScriptsDir Instance { get; } = new();

    public IEnumerable<string> Groups => Info.EnumerateDirectories().Select((dir) => dir.Name);

    /// <summary>The <see cref="DirectoryInfo"/> representing the scripts directory.</summary>
    public DirectoryInfo Info { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Joins the specified path components with the path of the scripts directory.</summary>
    /// <param name="paths">The path components to join with the scripts dir.</param>
    /// <returns>The concatenated path.</returns>
    public string Join(params string[] paths) => Path.Join(paths.Prepend(Info.FullName).ToArray());

    /// <summary>Loads all the scripts present in the scripts directory.</summary>
    /// <param name="owner">The listView to load the scripts into.</param>
    /// <returns>The scripts previously saved into the scripts dir.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <see langword="null"/>.</exception>
    public void LoadScripts(ListView owner)
    {
        _ = owner ?? throw new ArgumentNullException(nameof(owner));
        foreach (FileInfo script in Info.EnumerateFiles("*.xml", SearchOption.AllDirectories))
        {
            _ = owner.Items.Add(new Script(script, owner));
        }
    }
    #endregion Public Methods
}
