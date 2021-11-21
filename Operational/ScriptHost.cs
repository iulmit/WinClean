// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using RaphaëlBardini.WinClean.ErrorHandling;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

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

    /// <summary>Executes the specified script.</summary>
    /// <param name="script">The script to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    public virtual void Execute(Logic.IScript script)
    {
        _ = script ?? throw new ArgumentNullException(nameof(script));
        ExecuteCode(script.Code, script.Name, script.Extension);
    }

    #endregion Public Methods

    #region Protected Properties

    /// <summary>Arguments passed along <see cref="Executable"/> when executing.</summary>
    protected abstract IncompleteArguments Arguments { get; }

    /// <summary>The executable of the script host program.</summary>
    protected abstract FileInfo Executable { get; }

    #endregion Protected Properties

    #region Protected Methods

    /// <summary>Creates a temporary file with the specified text and the specified extension.</summary>
    /// <returns>The new temporary file.</returns>
    protected FileInfo CreateTempFile(string? text, string? extension)
    {
        FileInfo tmpScript = new(Path.Join(Path.GetTempPath(), $"WinCleanScript{DateTime.Now.ToBinary()}{extension}"));
        try
        {
            using StreamWriter s = tmpScript.CreateText();
            {
                s.Write(text);
            }
            return tmpScript;
        }
        catch (Exception e) when (e.FileSystem())
        {
            new FSErrorDialog(e, tmpScript, FSVerb.Create, () => tmpScript = CreateTempFile(text, extension)).ShowErrorDialog();
        }
        return tmpScript;
    }

    /// <summary>Executes the specified code.</summary>
    /// <param name="code">The code to execute.</param>
    /// <param name="scriptName">The name to give the the code.</param>
    /// <param name="extensionIfCodeWasInsideAFile">If <paramref name="code"/> was the content of a file, the file's extension.</param>
    /// <exception cref="ArgumentNullException"><paramref name="code"/> is <see langword="null"/>.</exception>
    protected void ExecuteCode(string code, string scriptName, string extensionIfCodeWasInsideAFile)
    {
        if (code is null)
        {
            throw new ArgumentNullException(nameof(code));
        }
        if (!SupportedExtensions.Contains(extensionIfCodeWasInsideAFile))
        {
            throw new BadFileExtensionException(extensionIfCodeWasInsideAFile);
        }

        FileInfo tmpScriptFile = CreateTempFile(code, extensionIfCodeWasInsideAFile);

        using Process host = ExecuteHost(tmpScriptFile);
        (string stderr, string stdout) = WaitForHostExit(host, scriptName);

        tmpScriptFile.Delete();

        stderr.Log("Standard error");
        stdout.Log("Standard output");
    }

    /// <summary>Executes the script host program with the specified script.</summary>
    /// <param name="script">The script to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    protected Process ExecuteHost(FileInfo script)
        => Process.Start(new ProcessStartInfo(Executable.FullName, Arguments.Complete(script ?? throw new ArgumentNullException(nameof(script))))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            StandardErrorEncoding = Encoding.Unicode,
            StandardOutputEncoding = Encoding.Unicode,
        })!; // ! : it wont return null

    /// <summary>Waits for the end of the specified script host process</summary>
    /// <param name="p">The process which to wait for exit.</param>
    /// <param name="scriptName">The name of the script being executed.</param>
    /// <exception cref="ArgumentNullException"><paramref name="p"/> or <paramref name="scriptName"/> are <see langword="null"/>.</exception>
    /// <returns>The standard error and standard output streams of the script host process, read to end.</returns>
    protected (string stderr, string stdout) WaitForHostExit(Process p, string scriptName)
    {
        // placeholder for the time a script would take to run
        Thread.Sleep(2000);
        _ = p ?? throw new ArgumentNullException(nameof(p));
        _ = scriptName ?? throw new ArgumentNullException(nameof(scriptName));

        if (!p.WaitForExit(Convert.ToInt32(Program.Settings.ScriptTimeout.TotalMilliseconds)))
        {
            Dialog.HungScript(scriptName,
            restart: () =>
            {
                p.Kill(true);
                _ = p.Start();
            },
            kill: () => p.Kill(true),
            ignore: () => WaitForHostExit(p, scriptName));
        }
        return (p.StandardError.ReadToEnd(), p.StandardOutput.ReadToEnd());
    }

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
                throw new ArgumentException(string.Format(InvariantCulture, Resources.DevException.WrongFormatItemCount, ExpectedFormatItemCount), nameof(args));
            }
            _args = args;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>Completes the arguments with the specified script file.</summary>
        /// <param name="script">The file to complete the arguments with.</param>
        /// <returns>The completed arguments</returns>
        public string Complete(FileInfo script) => string.Format(InvariantCulture, _args, script);

        #endregion Public Methods
    }

    #endregion Protected Classes
}
