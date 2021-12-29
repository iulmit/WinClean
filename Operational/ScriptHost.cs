using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// Represents a program that accepts a file in it's command-line arguments.
/// </summary>
public abstract class ScriptHost
{
    #region Public Properties

    /// <summary>
    /// User friendly name for the script host.
    /// </summary>
    public virtual string DisplayName => new ShellFile(Executable).FileDescription;

    /// <summary>
    /// Extensions of the scripts the script host program can run.
    /// </summary>
    public abstract ExtensionGroup SupportedExtensions { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Executes the specified script.
    /// </summary>
    /// <param name="script">The script to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="IOException">The disk is read-only. -or- An I/O error occured.</exception>
    /// <exception cref="HungScriptException">The script is still running after <paramref name="timeout"/> has elapsed and is probably hung.</exception>
    public virtual void Execute(Logic.IScript script, TimeSpan timeout)
    {
        _ = script ?? throw new ArgumentNullException(nameof(script));
        try
        {
            ExecuteCode(script.Code, timeout);
        }
        catch (TimeoutException e)
        {
            throw new HungScriptException(script, e);
        }
    }

    #endregion Public Methods

    #region Protected Properties

    /// <summary>
    /// Arguments passed along <see cref="Executable"/> when executing.
    /// </summary>
    protected abstract IncompleteArguments Arguments { get; }

    /// <summary>
    /// The executable of the script host program.
    /// </summary>
    protected abstract FileInfo Executable { get; }

    #endregion Protected Properties

    #region Protected Methods

    /// <summary>
    /// Creates a temporary file with the specified text.
    /// </summary>
    /// <returns>The new temporary file.</returns>
    /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="IOException">The disk is read-only. -or- An I/O error occured.</exception>
    protected static FileInfo CreateTempFile(string text)
    {
        FileInfo tmpScript = new(Path.GetTempFileName());
        using StreamWriter s = tmpScript.CreateText();
        {
            s.Write(text);
        }
        return tmpScript;
    }

    /// <summary>
    /// Waits for the end of the specified process.
    /// </summary>
    /// <param name="p">The process which to wait for exit.</param>
    /// <param name="timeout">How long to wait for the process to exit before throwing an exception.</param>
    /// <exception cref="TimeoutException">The process didn't exit afer <paramref name="timeout"/>.</exception>
    protected static void WaitForExit(Process p, TimeSpan timeout)
    {
        _ = p ?? throw new ArgumentNullException(nameof(p));

        if (!p.WaitForExit(Convert.ToInt32(timeout.TotalMilliseconds)))
        {
            throw new TimeoutException(timeout);
        }
    }

    /// <summary>
    /// Executes the specified code.
    /// </summary>
    /// <param name="code">The code to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="code"/> is <see langword="null"/>.</exception>
    /// <inheritdoc cref="CreateTempFile(string)" path="/exception"/>
    /// <inheritdoc cref="WaitForExit(Process, TimeSpan)" path="/exception"/>
    protected void ExecuteCode(string code, TimeSpan timeout)
    {
        if (code is null)
        {
            throw new ArgumentNullException(nameof(code));
        }

        FileInfo tmpScriptFile = CreateTempFile(code);

        using Process host = ExecuteHost(tmpScriptFile);
        WaitForExit(host, timeout);

        tmpScriptFile.Delete();
    }

    /// <summary>
    /// Executes the script host program with the specified script.
    /// </summary>
    /// <param name="script">The script to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    protected Process ExecuteHost(FileInfo script)
        => Process.Start(new ProcessStartInfo(Executable.FullName, Arguments.Complete(script ?? throw new ArgumentNullException(nameof(script))))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
        })!; // ! : it wont return null

    #endregion Protected Methods

    #region Protected Classes

    /// <summary>
    /// Formattable executable arguments with a single file path argument.
    /// </summary>
    protected class IncompleteArguments
    {
        #region Private Fields

        private readonly string _args;

        #endregion Private Fields

        #region Public Constructors

        /// <param name="args">Formattable string with 1 argument, the path of the script file.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="args"/> does not contain exactly one formattable argument.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <see langword="null"/>.</exception>
        public IncompleteArguments(string args)
        {
            const int ExpectedFormatItemCount = 1;
            if (FormattableStringFactory.Create(args ?? throw new ArgumentNullException(nameof(args)), string.Empty).ArgumentCount != ExpectedFormatItemCount)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.DevException.WrongFormatItemCount, ExpectedFormatItemCount), nameof(args));
            }
            _args = args;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Completes the arguments with the specified script file.
        /// </summary>
        /// <param name="script">The file to complete the arguments with.</param>
        /// <returns>The completed arguments</returns>
        public string Complete(FileInfo script) => string.Format(CultureInfo.InvariantCulture, _args, script);

        #endregion Public Methods
    }

    #endregion Protected Classes
}