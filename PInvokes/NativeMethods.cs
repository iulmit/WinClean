// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace RaphaëlBardini.WinClean.PInvokes
{
    internal static class NativeMethods
    {
        #region Public Methods

        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern uint SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("Shell32.dll", SetLastError = false)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        #endregion Public Methods
    }
}
