// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

using Microsoft.WindowsAPICodePack;

namespace RaphaëlBardini.WinClean.Operational
{
    internal static partial class NativeMethods
    {
        #region Public Methods

        [System.Diagnostics.CodeAnalysis.DoesNotReturn]
        public static void RebootForApplicationMaintenance() => System.Diagnostics.Process.Start("shutdown", $"/g /t 0 /d p:4:1");

        /// <summary>Removes the system menu icon from a window.</summary>
        /// <param name="window">The Win32 window to remove the icon from.</param>
        /// <returns>The old window icon</returns>
        public static void RemoveTitleBarIcon(IntPtr window)
            => Microsoft.WindowsAPICodePack.Win32Native.Core.SendMessage(window, WindowMessage.SetIcon, IntPtr.Zero, IntPtr.Zero);

        /// <inheritdoc cref="RemoveTitleBarIcon(IntPtr)"/>
        public static void RemoveTitleBarIcon(this IWin32Window window)
            => RemoveTitleBarIcon(window.Handle);

        #endregion Public Methods
    }
}
