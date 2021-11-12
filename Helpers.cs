// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean;

/// <summary>Provides a set of extension methods that fulfill a relatively generic role.</summary>
public static class Helpers
{
    #region Private Fields

    /// <summary>
    /// MAX_PATH ( <c>260</c>) minus the null terminator ( <c>'\0'</c>), the drive letter, it's colon and slash and a trailing slash.
    /// </summary>
    private const int MaxFilename = byte.MaxValue;

    #endregion Private Fields

    #region Public Methods

    public static RectangleF CenterIn(this SizeF child, RectangleF parent) => new(parent.Location + parent.Size / 2 - child / 2, child);

    public static Rectangle CenterIn(this Size child, Rectangle parent)
    {
        RectangleF rF = CenterIn(child, (RectangleF)parent);
        return new Rectangle(Convert.ToInt32(rF.X),
                             Convert.ToInt32(rF.Y),
                             Convert.ToInt32(rF.Height),
                             Convert.ToInt32(rF.Width));
    }

    [return: NotNull]
    public static T FailNull<T>(this T? t) where T : class
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

    /// <summary>Gets the currently active window control.</summary>
    /// <returns>The currently active window, or <see langword="null"/> if threre is not active window.</returns>
    public static IWin32Window? GetActiveWindow()
    {
        return new Win32Window(GetForegroundWindow());
        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        static extern IntPtr GetForegroundWindow();
    }

    /// <summary>Gets the name of a specific resource.</summary>
    /// <param name="resourceManager">The resource manager containing the resource.</param>
    /// <param name="resource">The resource to get the name of.</param>
    /// <param name="culture">The culture to use. If not specified, <see cref="CultureInfo.CurrentUICulture"/> is used.</param>
    /// <returns>
    /// The name of the resource <paramref name="resource"/>. If <paramref name="resource"/> is not found, <see langword="null"/>.
    /// </returns>
    /// <exception cref="ArgumentException">The resource set for <paramref name="resourceManager"/> doesn't exist.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="resourceManager"/> is <see langword="null"/>.</exception>
    public static string GetName(this System.Resources.ResourceManager resourceManager, object? resource, CultureInfo? culture = null)
        => (string)((resourceManager ?? throw new ArgumentNullException(nameof(resourceManager))).GetResourceSet(culture ?? CultureInfo.CurrentUICulture, true, true) ?? throw new ArgumentException("Resource set doesn't exist", nameof(resourceManager)))
           .OfType<DictionaryEntry>().First((entry) => entry.Value == resource).Key;

    /// <summary>Gets all the resources of the specified type.</summary>
    /// <typeparam name="T">The type of the resources to get.</typeparam>
    /// <param name="resourceManager">The resource manager to get the resources from.</param>
    /// <param name="culture">The culture to use. If not specified, <see cref="CultureInfo.CurrentUICulture"/> is used.</param>
    /// <returns>All the resources the resource manager have access to of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentException">The resource set for <paramref name="resourceManager"/> doesn't exist.</exception>
    public static IEnumerable<T?> GetRessources<T>(this System.Resources.ResourceManager resourceManager, CultureInfo? culture = null)
        => ((resourceManager ?? throw new ArgumentNullException(nameof(resourceManager))).GetResourceSet(culture ?? CultureInfo.CurrentUICulture, true, true) ?? throw new ArgumentException("Resource set doesn't exist", nameof(resourceManager)))
           .OfType<DictionaryEntry>().Where((entry) => entry.Value is T).Select<DictionaryEntry, T?>((entry) => (T?)entry.Value);

    /// <summary>Checks if a string is a valid Windows filename.</summary>
    /// <param name="filenameCandidate">The filename candidate.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="filenameCandidate"/> can be a filename, otherwise; <see langword="false"/>.
    /// This method returns <see langword="false"/> if <paramref name="filenameCandidate"/> is <see langword="null"/>.
    /// </returns>
    public static bool IsValidFilename(this string filenameCandidate)
        => !string.IsNullOrWhiteSpace(filenameCandidate)
           && filenameCandidate.Length <= MaxFilename
           && filenameCandidate.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;

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

    /// <summary>Restarts the system.</summary>
    public static void RebootForApplicationMaintenance() => Process.Start("shutdown", $"/g /t 0 /d p:4:1");

    /// <exception cref="ArgumentNullException"><paramref name="page"/> is <see langword="null"/>.</exception>
    /// <inheritdoc cref="TaskDialog.ShowDialog(IWin32Window, TaskDialogPage, TaskDialogStartupLocation)"/>
    public static TaskDialogButton ShowDialog(this TaskDialogPage page, IWin32Window? owner = null)
        => owner is null ? TaskDialog.ShowDialog(page) : TaskDialog.ShowDialog(owner, page);

    /// <summary>Creates a valid Windows filename from a string.</summary>
    /// <param name="filenameCandidate">The filename candidate.</param>
    /// <param name="replaceInvalidCharsWith">
    /// What to replace invalid filename chars in <paramref name="filenameCandidate"/> with.
    /// </param>
    /// <returns><paramref name="filenameCandidate"/>, modified to be a valid Windows filename if it wasn't already.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="filenameCandidate"/> or <paramref name="replaceInvalidCharsWith"/> are <see langword="null"/>, or
    /// <paramref name="replaceInvalidCharsWith"/> contains invalid filename chars.
    /// </exception>
    public static string ToFilename(this string filenameCandidate, string replaceInvalidCharsWith = "_")
        => string.IsNullOrWhiteSpace(filenameCandidate)
            ? throw new ArgumentException("Can't be null or whitespace", nameof(filenameCandidate))
            : string.IsNullOrWhiteSpace(replaceInvalidCharsWith)
                ? throw new ArgumentException("Can't be null or whitespace", nameof(replaceInvalidCharsWith))
                : replaceInvalidCharsWith.IndexOfAny(Path.GetInvalidFileNameChars()) != -1
                    ? throw new ArgumentException("Contains invalid filename chars", nameof(replaceInvalidCharsWith))
                    : (new(Regex.Replace(filenameCandidate, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
                                         replaceInvalidCharsWith, RegexOptions.Compiled | RegexOptions.CultureInvariant)
                           .Take(MaxFilename).ToArray()));

    #endregion Public Methods
}
