// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.WindowsAPICodePack.PropertySystem;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>Wrapper for <see cref="Microsoft.WindowsAPICodePack.Shell.ShellFile"/>.</summary>
public class ShellFile : IDisposable
{
    #region Private Fields

    private readonly Microsoft.WindowsAPICodePack.Shell.ShellFile shFile;

    #endregion Private Fields

    #region Public Constructors

    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    public ShellFile(FileInfo source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        shFile = new(source.FullName);
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>Gets the "File Description" property of the object</summary>
    public string FileDescription
    {
        get
        {
            const string descriptionPropertyGuid = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
            const int descriptionPropertyIndex = 3;
            return shFile.Properties.GetProperty<string>(new PropertyKey(descriptionPropertyGuid, descriptionPropertyIndex)).Value;
        }
    }

    #endregion Public Properties

    #region Public Methods

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion Public Methods

    #region Protected Methods

    /// <inheritdoc cref="IDisposable.Dispose"/>
    protected virtual void Dispose(bool disposing) => shFile.Dispose();

    #endregion Protected Methods
}
