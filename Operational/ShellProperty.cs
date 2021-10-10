// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;

namespace RaphaëlBardini.WinClean.Operational
{
    public static class ShellProperty
    {
        #region Public Methods

        public static string GetFileDescription(Path path)
        {
            const string descriptionPropertyGuid = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
            const int descriptionPropertyIndex = 3;
            using ShellFile sh = new(path);
            return sh.Properties.GetProperty<string>(new PropertyKey(descriptionPropertyGuid, descriptionPropertyIndex)).Value;
        }

        #endregion Public Methods
    }
}
