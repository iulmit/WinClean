// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    internal static class NativeMethods
    {
        #region Private Structs

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public int iSysIconIndex;
            public int iIcon;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]// 260 is MAX_PATH
            public string szPath;
        }

        #endregion Private Structs

        #region Public Methods

        /// <summary>Retrieves a common shell icon.</summary>
        /// <returns>The icon corresponding to the <paramref name="id"/> with the specified <paramref name="flags"/>.</returns>
        public static Icon GetShellIcon(ShellIcon id, ShelIconModifier flags = ShelIconModifier.None)
        {
            SHSTOCKICONINFO sii = new()
            {
                cbSize = (uint)Marshal.SizeOf(typeof(SHSTOCKICONINFO))
            };
            // It could throw anything !
            Marshal.ThrowExceptionForHR(SHGetStockIconInfo(id, (SHGSI)flags | SHGSI.SHGSI_ICON, ref sii));
            return Icon.FromHandle(sii.hIcon);
        }

        /// <summary>Removes the system menu icon from a window.</summary>
        /// <param name="window">The Win32 window to remove the icon from.</param>
        /// <returns>The old window icon</returns>
        public static void RemoveTitleBarIcon(IntPtr window)
            => _ = SendMessage(window, WM.SETICON, 0, IntPtr.Zero);

        /// <inheritdoc cref="RemoveTitleBarIcon(IntPtr)"/>
        public static void RemoveTitleBarIcon(this IWin32Window window)
            => RemoveTitleBarIcon(window.Handle);

        #endregion Public Methods

        #region Private Methods

        #region P/Invokes

        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int SendMessage(IntPtr hWnd, WM msg, nuint wParam, nint lParam);

        [DllImport("Shell32.dll", SetLastError = false)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int SHGetStockIconInfo(ShellIcon siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        #endregion P/Invokes

        #endregion Private Methods
    }
}
