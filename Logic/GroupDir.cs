﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic;

public class GroupDir
{
    #region Public Constructors

    public GroupDir(DirectoryInfo dir)
    {
        _ = dir ?? throw new ArgumentNullException(nameof(dir));
        CreateDir();
        Info = dir;

        void CreateDir()
        {
            try
            {
                dir.Create();
            }
            catch (Exception e) when (e.FileSystem())
            {
                new Dialogs.FSErrorDialog(e, FSVerb.Create, dir).ShowDialog(CreateDir);
            }
        }
    }

    #endregion Public Constructors

    #region Public Properties

    public DirectoryInfo Info { get; }

    #endregion Public Properties
}
