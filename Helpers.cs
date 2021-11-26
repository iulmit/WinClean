﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RaphaëlBardini.WinClean;

/// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
public static class Helpers
{
    #region Public Methods

    [return: NotNull]
    public static T AssertNotNull<T>(this T? t) where T : class
    {
        Debug.Assert(t is not null, $"Null at {new StackFrame(1, true)}");
        return t;
    }

    /// <summary>Checks if an exception is of a type that .NET Core's filesystem methods may throw.</summary>
    /// <returns>
    /// <para><see langword="true"/> if <paramref name="e"/> is of any of the following types :</para>
    /// <br><see cref="IOException"/> (including all derived exceptions)</br><br><see
    /// cref="UnauthorizedAccessException"/></br><br><see cref="NotSupportedException"/></br><br><see cref="System.Security.SecurityException"/></br>
    /// <para>Otherwise; <see langword="false"/>.</para>
    /// </returns>
    /// <remarks>Note that unrelated methods may throw any of these exceptions.</remarks>
    public static bool FileSystem(this Exception e)
        => e is IOException or UnauthorizedAccessException or NotSupportedException or System.Security.SecurityException;

    /// <summary>Creates a file extension filter for an <see cref="OpenFileDialog"/> control.</summary>
    /// <param name="ofd">The <see cref="OpenFileDialog"/> control to make a filter for.</param>
    /// <param name="exts">The extension to put into the filter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="ofd"/> is <see langword="null"/>.</exception>
    public static void MakeFilter(this OpenFileDialog ofd, IEnumerable<ExtensionGroup> exts)
        => (ofd ?? throw new ArgumentNullException(nameof(ofd))).Filter = new StringBuilder().AppendJoin('|', exts.SelectMany(group => new string[]
                                                                              {
                                                                                  $"{group.Name} ({string.Join(';', group.Select(ext => $"*{ext}"))})",
                                                                                  string.Join(';', group.Select(ext => $"*{ext}"))
                                                                              })).ToString();

    /// <inheritdoc cref="MakeFilter(OpenFileDialog, IEnumerable{ExtensionGroup})"/>
    public static void MakeFilter(this OpenFileDialog ofd, params ExtensionGroup[] exts) => MakeFilter(ofd, (IEnumerable<ExtensionGroup>)exts);

    public static TaskDialogButton ShowPage(this TaskDialogPage page)
    {
        IWin32Window? owner = GetApplicationActiveWindow();
        return owner is null ? TaskDialog.ShowDialog(page) : TaskDialog.ShowDialog(owner, page);
    }

    public static IWin32Window? GetApplicationActiveWindow()
        => (IWin32Window?)System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().FirstOrDefault((window) => window.IsActive);
    #endregion Public Methods
}
