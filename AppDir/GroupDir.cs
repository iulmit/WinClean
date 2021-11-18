// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.AppDir
{
    public class GroupDir
    {
        public DirectoryInfo Info { get; }

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
                    ErrorDialog.CantCreateDirectory(e, info, () => info = GetOrCreate());
                }

                return info;
            }
        }
    }
}
