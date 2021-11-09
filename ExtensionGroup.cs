// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

using Microsoft.Win32;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RaphaëlBardini.WinClean;

/// <summary>
/// A group of related extensions
/// </summary>
public class ExtensionGroup : IReadOnlyCollection<string>
{
    #region Private Fields

    private readonly IReadOnlyCollection<string> _extensions;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ExtensionGroup"/> structure.
    /// </summary>
    /// <param name="extensions">The extensions in the group.</param>
    public ExtensionGroup(IEnumerable<string> extensions)
    {
        Assert(extensions is not null);
        _extensions = extensions.ToList();
    }

    /// <inheritdoc cref="ExtensionGroup(IEnumerable{string})"/>
    public ExtensionGroup(params string[] extensionsParam) : this(extensions: extensionsParam)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    /// <inheritdoc/>
    public int Count => _extensions.Count;

    public string Name
    {
        get
        {
            foreach (string ext in _extensions)
            {
                string? result = GetFileTypeDisplayName(ext);
                if (result is not null)
                {
                    return result;
                }
            }
            return string.Empty;
        }
    }

    #endregion Public Properties

    #region Public Methods

    /// <inheritdoc/>
    public IEnumerator<string> GetEnumerator() => _extensions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_extensions).GetEnumerator();

    #endregion Public Methods

    #region Private Methods

    private static string? GetFileTypeDisplayName(string extension)
        => Registry.ClassesRoot.OpenSubKey(extension)?.GetValue(null) is string keyName
                       ? Registry.ClassesRoot.OpenSubKey(keyName)?.GetValue(null) as string
                       : null;

    #endregion Private Methods
}
