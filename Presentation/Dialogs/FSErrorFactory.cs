using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation.Dialogs;

public static class FSErrorFactory
{
    #region Public Constructors

    /// <summary>
    /// Sets a <see cref="TaskDialogPage"/> or a subclass with the data of a filesystem error.
    /// </summary>
    /// <param name="page">The page to modify.</param>
    /// <inheritdoc cref="MakeFSError{T}(Exception, FSVerb, FileSystemInfo)" path="/param"/>
    /// <returns>A reference to <paramref name="page"/> with its <see cref="TaskDialogPage.Icon"/> and <see cref="TaskDialogPage.Text"/> properties modified.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="page"/> is <see langword="null"/>.</exception>
    public static T MakeFSError<T>(T page, Exception e, FSVerb verb, FileSystemInfo info) where T : TaskDialogPage
    {
        _ = page ?? throw new ArgumentNullException(nameof(page));

        bool isFileElseDir = info is FileInfo;
        page.Icon = TaskDialogIcon.Error;
        page.Text = string.Format(CultureInfo.CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message);
        return page;
    }
    /// <summary>
    /// Creates a new instance of <typeparamref name="T"/> and makes it a filesystem error.
    /// </summary>
    /// <typeparam name="T">A <see cref="TaskDialogPage"/> or a subtype that can be publicly instanciated.</typeparam>
    /// <param name="e">The exception responsible of the filesystem error.</param>
    /// <param name="verb">The filesystem verb that could apply to what was trying to be done.</param>
    /// <param name="info">The file or directory on which the operation was applying.</param>
    /// <returns>A new instance of <typeparamref name="T"/> with the data of a filesystem error.</returns>
    public static T MakeFSError<T>(Exception e, FSVerb verb, FileSystemInfo info) where T : TaskDialogPage, new()
        => MakeFSError<T>(new T(), e, verb, info);
    #endregion Public Constructors
}
