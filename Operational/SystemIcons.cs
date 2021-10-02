// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Drawing;
using System.Runtime.InteropServices;

namespace RaphaëlBardini.WinClean.Operational
{
    public static class SystemIcons
    {
        #region Public Methods

        public static Icon GetIcon(PInvokes.SHSTOCKICONID id, PInvokes.SHGSI flags)
        {
            PInvokes.SHSTOCKICONINFO sii = new()
            {
                cbSize = (uint)Marshal.SizeOf(typeof(PInvokes.SHSTOCKICONINFO))
            };
            Marshal.ThrowExceptionForHR(PInvokes.NativeMethods.SHGetStockIconInfo(id,
                flags | PInvokes.SHGSI.SHGSI_ICON,
                ref sii));
            return Icon.FromHandle(sii.hIcon);
        }

        #endregion Public Methods
    }
}
