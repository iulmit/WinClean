// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

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
        Text = string.Format(CurrentCulture,
                             Resources.Dialog.FSError,
                             (verb ?? throw new ArgumentNullException(nameof(verb))).LocalizedVerb,
                             isFileElseDir ? Resources.FileSystemElements.File : Resources.FileSystemElements.Directory,
                             (info ?? throw new ArgumentNullException(nameof(info))).FullName,
                             (e ?? throw new ArgumentNullException(nameof(e))).Message);
    }

    #endregion Protected Constructors
}
