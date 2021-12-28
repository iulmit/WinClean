using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Dialogs;

public class FSErrorDialog : RetryExitDialog
{
    #region Public Constructors

    /// <inheritdoc cref="FSErrorDialog(Exception, FSVerb, FileSystemInfo, bool)"/>
    public FSErrorDialog(Exception e, FSVerb verb, FileInfo file)
        : this(e, verb, file, true) { }

    /// <inheritdoc cref="FSErrorDialog(Exception, FSVerb, FileSystemInfo, bool)"/>
    public FSErrorDialog(Exception e, FSVerb verb, DirectoryInfo directory)
        : this(e, verb, directory, false) { }

    #endregion Public Constructors

    #region Protected Constructors

    /// <exception cref="ArgumentNullException">One or more of the parameters are <see langword="null"/>.</exception>
    protected FSErrorDialog(Exception e, FSVerb verb, FileSystemInfo info, bool isFileElseDir)
    {
        Icon = TaskDialogIcon.Error;
        Text = string.Format(CultureInfo.CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message);
    }

    #endregion Protected Constructors
}