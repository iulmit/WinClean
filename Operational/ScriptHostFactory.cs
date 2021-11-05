// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using System.Linq;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// Factory methods for <see cref="ScriptHost"/> objects.
/// </summary>
public static class ScriptHostFactory
{
    #region Public Methods

    /// <summary>
    /// Creates a <see cref="ScriptHost"/> able to run script of the specified extension.
    /// </summary>
    /// <returns>A new <see cref="ScriptHost"/> object.</returns>
    /// <exception cref="BadFileExtensionException">
    /// <paramref name="extension"/> is not supported by any script host.
    /// </exception>
    public static ScriptHost FromFileExtension(string extension)
        => new Cmd().SupportedExtensions.Contains(extension)
            ? new Cmd()
            : new PowerShell().SupportedExtensions.Contains(extension)
                ? new PowerShell()
                : new Regedit().SupportedExtensions.Contains(extension)
                    ? new Regedit()
                    : throw new BadFileExtensionException(extension, "Extension is not supported by any script host.");

    #endregion Public Methods
}