// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class FSErrorDialog : Dialog
{
    #region Private Fields

    private readonly Action? _retry;

    #endregion Private Fields

    #region Public Constructors

    /// <inheritdoc cref="FSErrorDialog(Exception, FileSystemInfo, FSVerb, bool, Action?)"/>
    public FSErrorDialog(Exception e, FileInfo file, FSVerb verb, Action? retry = null)
        : this(e, file, verb, true, retry) { }

    /// <inheritdoc cref="FSErrorDialog(Exception, FileSystemInfo, FSVerb, bool, Action?)"/>
    public FSErrorDialog(Exception e, DirectoryInfo directory, FSVerb verb, Action? retry = null)
        : this(e, directory, verb, false, retry) { }

    #endregion Public Constructors

    #region Private Constructors

    /// <exception cref="ArgumentNullException">One or more of the non-nullable parameters are <see langword="null"/>.</exception>
    private FSErrorDialog(Exception e, FileSystemInfo info, FSVerb verb, bool isFileElseDir, Action? retry = null)
    {
        Icon = TaskDialogIcon.Error;
        Text = string.Format(CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message
                             );
        _retry = retry;
    }

    #endregion Private Constructors

    #region Public Methods

    public void ShowErrorDialog() => RetryExit(_retry);

    #endregion Public Methods
}
