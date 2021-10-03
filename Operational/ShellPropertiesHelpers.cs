﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;

namespace RaphaëlBardini.WinClean.Operational
{
    public static class ShellPropertiesHelpers
    {
        #region Private Fields

        private const string DescriptionPropertyGuid = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
        private const int DescriptionPropertyIndex = 3;

        #endregion Private Fields

        #region Public Methods

        public static string GetFileDescription(string path)
        {
            using ShellFile sh = new(path);
            return sh.Properties.GetProperty<string>(new PropertyKey(DescriptionPropertyGuid, DescriptionPropertyIndex)).Value;
        }

        #endregion Public Methods
    }
}