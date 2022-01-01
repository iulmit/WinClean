using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Presentation;

public class FSErrorDialog : RetryExitDialog
{
    #region Public Constructors

    /// <exception cref="ArgumentNullException">One or more of the parameters are <see langword="null"/>.</exception>
    public FSErrorDialog(Exception e, FSVerb verb, FileSystemInfo info)
    {
        bool isFileElseDir = info is FileInfo;
        Icon = TaskDialogIcon.Error;
        Text = string.Format(CultureInfo.CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message);
    }
    #endregion Public Constructors
}