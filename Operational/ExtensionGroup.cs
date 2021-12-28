using Microsoft.Win32;

using System.Collections;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// A group of related extensions
/// </summary>
public class ExtensionGroup : IReadOnlyCollection<string>
{
    #region Private Fields

    private readonly IReadOnlyCollection<string> _extensions;

    #endregion Private Fields

    #region Public Constructors

    /// <param name="extensions">The extensions in the group.</param>
    /// <exception cref="ArgumentNullException"><paramref name="extensions"/> is <see langword="null"/>.</exception>
    public ExtensionGroup(IEnumerable<string> extensions) => _extensions = (extensions ?? throw new ArgumentNullException(nameof(extensions))).ToList();

    /// <inheritdoc cref="ExtensionGroup(IEnumerable{string})"/>
    public ExtensionGroup(params string[] extensions) : this((IEnumerable<string>)extensions)
    {
    }

    #endregion Public Constructors

    #region Public Properties

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