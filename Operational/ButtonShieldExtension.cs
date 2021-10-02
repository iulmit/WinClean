// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>Provides methods to show the administrator icon next to a ButtonControl.</summary>
    public static class ButtonShieldExtension
    {
        #region Public Methods

        /// <summary>Adds the shield icon to a button.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="b"/> is <see langword="null"/>.</exception>
        public static void AddShield(this ButtonBase b)
        {
            (b ?? throw new ArgumentNullException(nameof(b))).FlatStyle = FlatStyle.System;
            _ = PInvokes.NativeMethods.SendMessage(b.Handle, 0x1600 + 0x000C, IntPtr.Zero, (IntPtr)1);
        }

        /// <summary>Removes the shield icon from a button.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="b"/> is <see langword="null"/>.</exception>
        public static void RemoveShield(this ButtonBase b)
        {
            (b ?? throw new ArgumentNullException(nameof(b))).FlatStyle = FlatStyle.System;
            _ = PInvokes.NativeMethods.SendMessage(b.Handle, 0x1600 + 0x000C, IntPtr.Zero, (IntPtr)0);
        }

        #endregion Public Methods
    }
}
