// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace RaphaëlBardini.WinClean;

/// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
public static class Helpers
{
    #region Public Methods

    [return: NotNull]
    public static T AssertNotNull<T>(this T? t) where T : class
    {
        Assert(t is not null, $"Null at {new StackFrame(1, true)}");
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

    /// <summary>Gets the neutral culture associated with this culture.</summary>
    /// <returns>The neutral culture specified by the two letter ISO language name of this culture.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="cultureInfo"/> is <see langword="null"/>.</exception>
    public static CultureInfo GetNeutralCulture(this CultureInfo cultureInfo)
    {
        return new((cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo))).TwoLetterISOLanguageName);
    }

    /// <summary>Creates a file extension filter for an <see cref="OpenFileDialog"/> control.</summary>
    /// <param name="ofd">The <see cref="OpenFileDialog"/> control to make a filter for.</param>
    /// <param name="exts">The extension to put into the filter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="ofd"/> is <see langword="null"/>.</exception>
    public static void MakeFilter(this OpenFileDialog ofd, IEnumerable<ExtensionGroup> exts)
        => (ofd ?? throw new ArgumentNullException(nameof(ofd))).Filter = new StringBuilder().AppendJoin('|', exts.SelectMany(group => new string[]
                                                                               {
                                                                                       $"{group.Name} ({string.Join(';', group.Select(ext => $"*{ext}"))})",
                                                                                       string.Join(';', group.Select(ext => $"*{ext}"))
                                                                               }
                                                                           )
                                                      ).ToString();

    /// <inheritdoc cref="MakeFilter(OpenFileDialog, IEnumerable{ExtensionGroup})"/>
    public static void MakeFilter(this OpenFileDialog ofd, params ExtensionGroup[] exts) => MakeFilter(ofd, (IEnumerable<ExtensionGroup>)exts);

    public static bool PathEquals(string left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    /// <summary>Shows the dialog in foreground window</summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static TaskDialogButton ShowPageInForegroundWindow(this TaskDialogPage page)
    {
        IntPtr ownerHandle = GetForegroundWindow();
        IWin32Window? owner = (ownerHandle == IntPtr.Zero) ? null : new Win32Window(ownerHandle);
        return owner is null ? TaskDialog.ShowDialog(page) : TaskDialog.ShowDialog(owner, page);

        [DllImport("user32")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        static extern IntPtr GetForegroundWindow();
    }

    #endregion Public Methods
}
