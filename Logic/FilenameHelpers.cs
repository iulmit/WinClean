using System.Text.RegularExpressions;

namespace RaphaëlBardini.WinClean.Logic;

public static class FilenameHelpers
{
    #region Private Fields

    private const int MaxFilename = 255;

    #endregion Private Fields

    #region Public Methods

    /// <summary>Checks if a string is a valid Windows filename.</summary>
    /// <param name="filenameCandidate">The filename candidate.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="filenameCandidate"/> can be a filename, otherwise; <see langword="false"/>.
    /// This method returns <see langword="false"/> if <paramref name="filenameCandidate"/> is <see langword="null"/>.
    /// </returns>
    public static bool IsValidFilename(this string? filenameCandidate)
        => !string.IsNullOrWhiteSpace(filenameCandidate)
              && filenameCandidate.Length <= MaxFilename
              && filenameCandidate.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;

    #endregion Public Methods
}
