// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Windows.Forms;

namespace RaphaëlBardini.WinClean;

/// <summary>Simple container for a handle which implements <see cref="IWin32Window"/>.</summary>
public record struct Win32Window : IWin32Window
{
    #region Public Constructors

    public Win32Window(IntPtr handle) => Handle = handle;

    #endregion Public Constructors

    #region Public Properties

    public IntPtr Handle { get; }

    #endregion Public Properties
}
