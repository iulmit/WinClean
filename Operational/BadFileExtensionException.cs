namespace RaphaëlBardini.WinClean.Operational;

/// <summary>The exception is thrown when a file has the wrong extension.</summary>
public class BadFileExtensionException : IOException
{
    #region Public Constructors

    public BadFileExtensionException() : base(Resources.DevException.BadFileExtension)
    {
    }

    /// <param name="extension">The wrong extension.</param>
    public BadFileExtensionException(string? extension) : base(string.Format(CultureInfo.CurrentCulture, Resources.DevException.BadFileExtensionSpecified, extension)) => Extension = extension;

    /// <param name="extension">The wrong extension.</param>
    /// <param name="message">The exception's message.</param>
    public BadFileExtensionException(string? extension, string? message) : base(message) => Extension = extension;

    /// <inheritdoc path="param"/>
    public BadFileExtensionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>The wrong file extension.</summary>
    public string? Extension { get; } = string.Empty;

    #endregion Public Properties
}
