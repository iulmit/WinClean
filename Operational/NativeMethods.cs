// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack;

namespace RaphaëlBardini.WinClean.Operational
{
    internal static partial class NativeMethods
    {
        #region Public Methods

        /// <summary>Removes the system menu icon from a window.</summary>
        /// <param name="window">The Win32 window to remove the icon from.</param>
        /// <returns>The old window icon</returns>
        public static void RemoveTitleBarIcon(IntPtr window)
            => Microsoft.WindowsAPICodePack.Win32Native.Core.SendMessage(window, WindowMessage.SetIcon, IntPtr.Zero, IntPtr.Zero);

        /// <inheritdoc cref="RemoveTitleBarIcon(IntPtr)"/>
        public static void RemoveTitleBarIcon(this IWin32Window window)
            => RemoveTitleBarIcon(window.Handle);

        public static void RebootWindows()
        {
            if (!ExitWindowsEx(ExitWindows.Reboot, ShutdownReason.MajorApplication | ShutdownReason.MinorMaintenance | ShutdownReason.FlagPlanned))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }
        #endregion Public Methods

        #region Private Methods

        #region P/Invokes

        [DllImport("user32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ExitWindowsEx(ExitWindows uFlags, ShutdownReason dwReason);

        #endregion P/Invokes

        #endregion Private Methods
    }
}
