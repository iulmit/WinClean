using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>Represents a program that accepts a file in it's command-line arguments.</summary>
public abstract class ScriptHost
{
    #region Public Properties

    /// <summary>User friendly name for the script host.</summary>
    public virtual string DisplayName => new ShellFile(Executable).FileDescription;

    /// <summary>Extensions of the scripts the script host program can run.</summary>
    public abstract ExtensionGroup SupportedExtensions { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Executes the specified code.</summary>
    /// <param name="code">The code to execute.</param>
    /// <param name="scriptName">The name of the script.</param>
    /// <param name="promptKillOnHung">
    /// Delegate invoked when the script is still running after <paramref name="timeout"/> has elapsed and is probably hung.
    /// </param>
    /// <param name="timeout">How long to wait for the script to end before throwing an <see cref="HungScriptException"/>.</param>
    /// <inheritdoc cref="CreateTempFile(string, Func{Exception, FileSystemInfo, FSVerb, bool}, int)"/>
    public virtual void ExecuteCode(string code, string scriptName, TimeSpan timeout, Func<string, bool> promptKillOnHung, Func<Exception, FileSystemInfo, FSVerb, bool> promptRetryOnFSError, int promptLimit)
    {
        FileInfo tmpScriptFile = CreateTempFile(code, promptRetryOnFSError, promptLimit);

        using Process host = ExecuteHost(tmpScriptFile);

        for (int remainingPrompts = promptLimit; remainingPrompts > 0; --remainingPrompts)
        {
            try
            {
                WaitForExit(host, timeout);
                break;
            }
            catch (TimeoutException e)
            {
                if (!(promptKillOnHung?.Invoke(code) ?? false))
                {
                    throw new HungScriptException(scriptName, e);
                }
            }
        }
        tmpScriptFile.Delete();
    }

    #endregion Public Methods

    #region Protected Properties

    /// <summary>Arguments passed along <see cref="Executable"/> when executing.</summary>
    protected abstract IncompleteArguments Arguments { get; }

    /// <summary>The executable of the script host program.</summary>
    protected abstract FileInfo Executable { get; }

    #endregion Protected Properties

    #region Protected Methods

    /// <summary>Creates a temporary file with the specified text.</summary>
    /// <returns>The new temporary file.</returns>
    /// <param name="text">The text to write in the temporary file.</param>
    /// <param name="promptRetryOnFSError">Delegate invoked when a filesystem error occurs.</param>
    /// <param name="promptLimit">
    /// How many times <paramref name="promptRetryOnFSError"/> can return <see langword="false"/> before the method throws the exception.
    /// </param>
    /// <exception cref="System.Security.SecurityException">
    /// The caller does not have the required permission -and- <paramref name="promptRetryOnFSError"/> returned <see langword="false"/>.
    /// </exception>
    /// <exception cref="IOException">
    /// An I/O error occured. -or- The disk is read-only. -and- <paramref name="promptRetryOnFSError"/> returned <see langword="false"/>.
    /// </exception>
    protected static FileInfo CreateTempFile(string text, Func<Exception, FileSystemInfo, FSVerb, bool> promptRetryOnFSError, int promptLimit)
    {
        // Not catching IOException here
        FileInfo tmp = new(Path.GetTempFileName());

        for (int remainingPrompts = promptLimit; remainingPrompts > 0; --remainingPrompts)
        {
            try
            {
                using StreamWriter s = tmp.CreateText();
                {
                    s.Write(text);
                }
                break;
            }
            catch (Exception e) when (e is System.Security.SecurityException or IOException)
            {
                if (!(promptRetryOnFSError?.Invoke(e, tmp, FSVerb.Create) ?? false))
                {
                    throw;
                }
            }
        }

        return tmp;
    }

    /// <summary>Waits for the end of the specified process.</summary>
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

    /// <summary>Executes the script host program with the specified script.</summary>
    /// <param name="script">The script to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    protected Process ExecuteHost(FileInfo script)
        => Process.Start(new ProcessStartInfo(Executable.FullName, Arguments.Complete(script ?? throw new ArgumentNullException(nameof(script))))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
        })!; // ! : it wont return null

    #endregion Protected Methods

    #region Protected Classes

    /// <summary>Formattable executable arguments with a single file path argument.</summary>
    protected class IncompleteArguments
    {
        #region Private Fields

        private readonly string _args;

        #endregion Private Fields

        #region Public Constructors

        /// <param name="args">Formattable string with 1 argument, the path of the script file.</param>
        /// <exception cref="ArgumentException"><paramref name="args"/> does not contain exactly one formattable argument.</exception>
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

        /// <summary>Completes the arguments with the specified script file.</summary>
        /// <param name="script">The file to complete the arguments with.</param>
        /// <returns>The completed arguments</returns>
        public string Complete(FileInfo script) => string.Format(CultureInfo.InvariantCulture, _args, script);

        #endregion Public Methods
    }

    #endregion Protected Classes
}
