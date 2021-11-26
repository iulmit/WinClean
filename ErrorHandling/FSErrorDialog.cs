// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public class FSErrorDialog : RetryExitDialog
{
    #region Public Constructors

    /// <inheritdoc cref="FSErrorDialog(Exception, FileSystemInfo, FSVerb, bool)"/>
    public FSErrorDialog(Exception e, FileInfo file, FSVerb verb)
        : this(e, file, verb, true) { }

    /// <inheritdoc cref="FSErrorDialog(Exception, FileSystemInfo, FSVerb, bool)"/>
    public FSErrorDialog(Exception e, DirectoryInfo directory, FSVerb verb)
        : this(e, directory, verb, false) { }

    #endregion Public Constructors

    #region Private Constructors

    /// <exception cref="ArgumentNullException">One or more of the parameters are <see langword="null"/>.</exception>
    private FSErrorDialog(Exception e, FileSystemInfo info, FSVerb verb, bool isFileElseDir)
    {
        Icon = TaskDialogIcon.Error;
        Text = string.Format(CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message);
    }

    #endregion Private Constructors
}
