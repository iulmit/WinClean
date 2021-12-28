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
    /// <exception cref="BadFileExtensionException">
    /// The script's extension is not supported by this script host.
    /// </exception>
    /// <inheritdoc cref="ExecuteCode(string, string, string, TimeSpan)"/>
    public virtual void Execute(Logic.IScript script, TimeSpan timeout)
    {
        _ = script ?? throw new ArgumentNullException(nameof(script));
        ExecuteCode(script.Code, script.Name, script.Extension, timeout);
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
    /// Creates a temporary file with the specified text and the specified extension.
    /// </summary>
    /// <returns>The new temporary file.</returns>
    protected static FileInfo CreateTempFile(string text, string extension)
    {
        FileInfo tmpScript = new(Path.Join(Path.GetTempPath(), $"WinCleanScript{DateTime.Now.ToBinary()}{extension}"));
        try
        {
            using StreamWriter s = tmpScript.CreateText();
            {
                s.Write(text);
            }
        }
        catch (Exception e) when (e.FileSystem())
        {
            new Dialogs.FSErrorDialog(e, FSVerb.Create, tmpScript).ShowDialog(() => tmpScript = CreateTempFile(text, extension));
        }
        return tmpScript;
    }

    /// <summary>
    /// Waits for the end of the specified script host process
    /// </summary>
    /// <param name="p">The process which to wait for exit.</param>
    /// <param name="scriptName">The name of the script being executed.</param>
    /// <param name="timeout">How long to wait for the script to exit before throwing an exception.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="p"/> or <paramref name="scriptName"/> are <see langword="null"/>.
    /// </exception>
    protected static void WaitForHostExit(Process p, string scriptName, TimeSpan timeout)
    {
        _ = p ?? throw new ArgumentNullException(nameof(p));
        _ = scriptName ?? throw new ArgumentNullException(nameof(scriptName));

        if (!p.WaitForExit(Convert.ToInt32(timeout.TotalMilliseconds)))
        {
            Dialogs.KillIgnoreDialog.HungScript(scriptName, timeout).ShowDialog(p.Kill, () => WaitForHostExit(p, scriptName, timeout));
        }
    }

    /// <summary>
    /// Executes the specified code.
    /// </summary>
    /// <param name="code">The code to execute.</param>
    /// <param name="extension">
    /// If <paramref name="code"/> was the content of a file, the file's extension.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="code"/> is <see langword="null"/>.</exception>
    /// <exception cref="BadFileExtensionException">
    /// <paramref name="extension"/> is not a valid file extension for this script host.
    /// </exception>
    /// <inheritdoc cref="CreateTempFile(string, string)" path="/exception"/>
    /// <inheritdoc cref="WaitForHostExit(Process, string, TimeSpan)"/>
    protected void ExecuteCode(string code, string scriptName, string extension, TimeSpan timeout)
    {
        if (code is null)
        {
            throw new ArgumentNullException(nameof(code));
        }
        if (!SupportedExtensions.Contains(extension))
        {
            throw new BadFileExtensionException(extension);
        }

        FileInfo tmpScriptFile = CreateTempFile(code, extension);

        using Process host = ExecuteHost(tmpScriptFile);
        WaitForHostExit(host, scriptName, timeout);

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