// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.AppDir
{
    public class GroupDir
    {
        #region Public Constructors

        public GroupDir(string name)
        {
            _ = name ?? throw new ArgumentNullException(nameof(name));
            if (!name.IsValidFilename())
            {
                throw new ArgumentException("Not a valid filename", nameof(name));
            }
            Info = GetOrCreate();

            DirectoryInfo GetOrCreate()
            {
                DirectoryInfo info = new(Path.Join(ScriptsDir.Instance.Info.FullName, name));

                try
                {
                    info.Create();
                }
                catch (Exception e) when (e.FileSystem())
                {
                    new FSErrorDialog(e, info, FSOperation.Create, () => info = GetOrCreate()).ShowErrorDialog();
                }

                return info;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public DirectoryInfo Info { get; }

        #endregion Public Properties
    }
}
