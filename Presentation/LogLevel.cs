namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>Specifies a minimum log level.</summary>
public enum LogLevel
{
    /// <summary>All entries are logged.</summary>
    Verbose,

    /// <summary>Informational entries minimum.</summary>
    Info,

    /// <summary>Warning-level entries minimum.</summary>
    Warning,

    /// <summary>Error-level entries minimum.</summary>
    Error,

    /// <summary>Unrecoverable errors. The application can't continue.</summary>
    Critical
}
