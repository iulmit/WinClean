using RaphaëlBardini.WinClean.Logic;
using RaphaëlBardini.WinClean.Operational;
using RaphaëlBardini.WinClean.Presentation.Dialogs;

using System.Diagnostics;

/* Steps :
 * Warning. Show a warning message. Force the user to read it using a verification checkbox.
 * Progress. Execute the scripts asynchronously and dynamically show progress.
 * Completed. Show results and prompt a reboot. Give advice on further optimizations.
*/

namespace RaphaëlBardini.WinClean.Presentation.ScriptExecution;

/// <summary>
/// Walks the user through the multistep high-level operation of the execution of multiple scripts asynchronously by displaying
/// a task dialog tracking the progress.
/// </summary>
public class ScriptExecutionWizard
{
    #region Private Fields

    private readonly ScriptExecutor _executor = new();
    private readonly IReadOnlyList<IScript> _scripts;

    #endregion Private Fields

    #region Public Constructors

    /// <param name="scripts">The scripts to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="scripts"/> is <see langword="null"/>.</exception>
    public ScriptExecutionWizard(IReadOnlyList<IScript> scripts)
    {
        if (scripts is null)
        {
            throw new ArgumentNullException(nameof(scripts));
        }
        if (scripts.Contains(null!))
        {
            throw new ArgumentException(Resources.DevException.CollectionContainsNull, nameof(scripts));
        }
        _scripts = scripts;
    }

    /// <param name="script">The script to execute</param>
    /// <exception cref="ArgumentNullException"><paramref name="script"/> is <see langword="null"/>.</exception>
    public ScriptExecutionWizard(IScript script) : this(new List<IScript> { script ?? throw new ArgumentNullException(nameof(script)) })
    {
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Executes the scripts without displaying a dialog.</summary>
    public async void ExecuteNoUI()
    {
        "Executing scripts without UI...".Log("Script execution", LogLevel.Verbose);
        await _executor.ExecuteScriptsAsync(_scripts,
                                            Program.Settings.ScriptTimeout,
                                            name => KillIgnoreDialog.HungScript(name, Program.Settings.ScriptTimeout).ShowDialog(),
                                            (e, fSInfo, verb) => FSErrorFactory.MakeFSError<RetryExitDialog>(e, verb, fSInfo).ShowDialog(),
                                            Program.Settings.MaxPrompts).ConfigureAwait(false);
    }

    /// <summary>Executes the scripts and displays a dialog tracking the progress.</summary>
    // STEP 1 : Warning
    public void ExecuteUI()
    {
        "Executing scripts with UI...".Log("Script execution");

        ScriptExecution.WarningPage warning = new();

        warning.ContinueClicked += (_, _) =>
        {
            if (YesNoDialog.SystemRestorePoint.ShowDialog())
            {
                bool @continue = true;
                do
                {
                    try
                    {
                        "Creating restore point...".Log("Script execution restore point");
                        new RestorePoint(string.Format(CultureInfo.CurrentCulture, Resources.ScriptExecutionWizard.ScriptExecution, Application.ProductName),
                                         EventType.BeginSystemChange,
                                         RestorePointType.ModifySettings).Create();
                        "Restore point created successfully.".Log("Script execution restore point");
                        @continue = true;
                    }
                    catch (SystemProtectionDisabledException e)
                    {
                        $"Error during restore point creation : {e.Message}\nPrompting user to take action.".Log("Script execution restore point", LogLevel.Error);
                        TaskDialogButton result = ContinueRetryAbortDialog.SystemRestoreDisabled.ShowPage();
                        if (result == TaskDialogButton.Retry)
                        {
                            "User chose to retry creating a restore point.".Log("Script execution restore point");
                            @continue = false;
                        }
                        else if (result == TaskDialogButton.Abort)
                        {
                            "User chose to abort the script execution.".Log("Script execution restore point");
                            warning.Buttons.First(b => b == TaskDialogButton.Cancel).PerformClick();
                            return;
                        }
                        else
                        {
                            "User chose to continue script execution anyway.".Log("Script execution restore point");
                        }
                    }
                } while (!@continue);
            }

            $"Showing progress page...".Log("Script execution", LogLevel.Verbose);
            warning.Navigate(CreateProgressPage());
        };

        $"Showing warning page...".Log("Script execution", LogLevel.Verbose);
        _ = warning.ShowPage();
    }

    #endregion Public Methods

    #region Private Methods

    private static void RebootForApplicationMaintenance()
    {
        $"Rebooting for application maintenance...".Log("Script execution");
        _ = Process.Start("shutdown", $"/g /t 0 /d p:4:1");
    }

    // STEP 2 : Progress
    private TaskDialogPage CreateProgressPage()
    {
        ProgressPage progress = new(_scripts);

        progress.CancelClicked += (s, e) =>
        {
            "Canceled button clicked. Asking user for confirmation...".Log("Script execution cancelation");
            if (YesNoDialog.AbortOperation.ShowDialog())
            {
                "User confirmed cancelation. Canceling script execution...".Log("Script execution cancelation");
                _executor.CancelScriptExecution();
                "Script execution canceled.".Log("Script execution cancelation");
            }
        };

        _executor.ProgressChanged += (_, args) =>
        {
            progress.CurrentScriptIndex = args.ScriptIndex;
        };

        progress.Created += async (_, _) =>
        {
            TimeSpan timerInterval = TimeSpan.FromSeconds(1);
            System.Timers.Timer timer = new(Convert.ToInt32(timerInterval.TotalMilliseconds));

            SynchronizationContext context = SynchronizationContext.Current!; // ! : idk
            timer.Elapsed += (s, e) =>
            {
                context.Send((_) => progress.Elapsed += timerInterval, null);
            };

            timer.Start();
            $"Starting the execution of {_scripts.Count} script(s)...".Log("Script execution");
            await _executor.ExecuteScriptsAsync(_scripts,
                                                Program.Settings.ScriptTimeout,
                                                name => KillIgnoreDialog.HungScript(name, Program.Settings.ScriptTimeout).ShowDialog(),
                                                (e, fSInfo, verb) => FSErrorFactory.MakeFSError<RetryExitDialog>(e, verb, fSInfo).ShowDialog(),
                                                Program.Settings.MaxPrompts).ConfigureAwait(true);
            $"Script(s) executed successfully.".Log("Script execution");
            timer.Stop();

            if (progress.AutoRestart)
            {
                RebootForApplicationMaintenance();
            }
            else
            {
                CompletedPage completed = new(_scripts.Count, progress.Elapsed);
                completed.RestartClicked += (_, _) => RebootForApplicationMaintenance();
                $"Showing completed page...".Log("Script execution");
                progress.Navigate(completed);
            }
        };

        return progress;
    }

    #endregion Private Methods
}
