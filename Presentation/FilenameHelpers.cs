using System.Text.RegularExpressions;

namespace RaphaëlBardini.WinClean.Presentation;

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

    /// <summary>Creates a valid Windows filename from a string.</summary>
    /// <param name="filenameCandidate">The filename candidate.</param>
    /// <param name="replaceInvalidCharsWith">
    /// What to replace invalid filename chars in <paramref name="filenameCandidate"/> with.
    /// </param>
    /// <returns><paramref name="filenameCandidate"/>, modified to be a valid Windows filename if it wasn't already.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="filenameCandidate"/> or <paramref name="replaceInvalidCharsWith"/> are <see langword="null"/>, or
    /// <paramref name="replaceInvalidCharsWith"/> contains invalid filename chars.
    /// </exception>
    public static string ToFilename(this string filenameCandidate, string replaceInvalidCharsWith = "_")
        => string.IsNullOrWhiteSpace(filenameCandidate)
            ? throw new ArgumentException(Resources.DevException.NullOrWhitspace, nameof(filenameCandidate))
            : string.IsNullOrWhiteSpace(replaceInvalidCharsWith)
                ? throw new ArgumentException(Resources.DevException.NullOrWhitspace, nameof(replaceInvalidCharsWith))
                : replaceInvalidCharsWith.IndexOfAny(Path.GetInvalidFileNameChars()) != -1
                    ? throw new ArgumentException(Resources.DevException.InvalidFilenameChars, nameof(replaceInvalidCharsWith))
                    : (new(Regex.Replace(filenameCandidate.Trim(), $"[{Regex.Escape(new(Path.GetInvalidFileNameChars()))}]",
                                         replaceInvalidCharsWith, RegexOptions.Compiled | RegexOptions.CultureInvariant)
                           .Take(MaxFilename).ToArray()));

    #endregion Public Methods
}
