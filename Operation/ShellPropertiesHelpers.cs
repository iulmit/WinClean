// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;
namespace RaphaëlBardini.WinClean.Operational
{
    public static class ShellPropertiesHelpers
    {
        private const int DESCRIPTION_PROPERTY_INDEX = 3;
        private const string DESCRIPTION_PROPERTY_GUID = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
        public static string GetFileDescription(string path) =>
            new ShellFile(path).Properties.GetProperty<string>(new PropertyKey(DESCRIPTION_PROPERTY_GUID, DESCRIPTION_PROPERTY_INDEX)).Value;
    }
}
