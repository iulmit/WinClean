namespace RaphaëlBardini.WinClean.Logic;

public class ScriptExecutor
{
    public event EventHandler<ScriptExecutionProgressChangedEventArgs> ProgressChanged { add => _progress.ProgressChanged += value; remove => _progress.ProgressChanged -= value; }

    private readonly Progress<ScriptExecutionProgressChangedEventArgs> _progress = new();

    private readonly CancellationTokenSource cts;
    private readonly CancellationToken ct;

    public ScriptExecutor()
    {
        cts = new();
        ct = cts.Token;
    }

    public void CancelScriptExecution() => cts.Cancel(true);

    /// <summary>
    /// Executes asynchronously a list of scripts. Raises the <see cref="ProgressChanged"/> event.
    /// </summary>
    /// <param name="scripts">The scripts to execute.</param>
    /// <returns>An awaitable task.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public async Task ExecuteScriptsAsync(IReadOnlyList<IScript> scripts, TimeSpan timeout, Func<string, bool> promptKillOnHung, Func<Exception, FileSystemInfo, Operational.FSVerb, bool> promptRetryOnFSError, uint promptLimit)
    {
        _ = scripts ?? throw new ArgumentNullException(nameof(scripts));
        await Task.Run(() =>
        {
            int scriptIndex = 0;

            for (; scriptIndex < scripts.Count; ++scriptIndex)
            {
                ct.ThrowIfCancellationRequested();
                scripts[scriptIndex].Execute(timeout, promptKillOnHung, promptRetryOnFSError, promptLimit);
                ReportProgress();
            }

            void ReportProgress() => ((IProgress<ScriptExecutionProgressChangedEventArgs>)_progress).Report(new(scriptIndex));
        }, ct).ConfigureAwait(false);
    }
}
