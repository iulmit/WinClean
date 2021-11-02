using System.Diagnostics;
using System.ComponentModel;

namespace RaphaëlBardini.WinClean.Operational
{
    /// <summary>
    /// Provides method to manage PowerShell settings.
    /// </summary>
    internal static class PowerShell
    {
        public static string Path => System.IO.Path.Join(Environment.GetEnvironmentVariable("SystemRoot"), "System32", "WindowsPowerShell", "v1.0", "powershell.exe");
        /// <summary>Sets the execution policy for the specified scope.</summary>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="policy"/> or <paramref name="scope"/> are not defined constants of their enum types.</exception>
        public static void SetExecutionPolicy(ExecutionPolicy policy, ExecutionPolicyScope scope)
        {
            if (!Enum.IsDefined<ExecutionPolicy>(policy))
            {
                throw new InvalidEnumArgumentException(nameof(policy), (int)policy, typeof(ExecutionPolicy));
            }
            if (!Enum.IsDefined<ExecutionPolicyScope>(scope))
            {
                throw new InvalidEnumArgumentException(nameof(scope), (int)scope, typeof(ExecutionPolicyScope));
            }
            _ = Process.Start(Path, $"-WindowStyle hidden -NoLogo -NoProfile -NonInteractive -Command & \"Set-ExecutionPolicy -ExecutionPolicy {policy} -Scope {scope}\"");
        }
        /// <summary>
        /// Gets the execution policy for the specified scope.
        /// </summary>
        /// <returns>The execution policy for <paramref name="scope"/>.</returns>
        /// <exception cref="InvalidEnumArgumentException"><paramref name="scope"/> is not a defined <see cref="ExecutionPolicyScope"/> constant.</exception>
        public static ExecutionPolicy GetExecutionPolicy(ExecutionPolicyScope scope)
        {
            if (!Enum.IsDefined<ExecutionPolicyScope>(scope))
            {
                throw new InvalidEnumArgumentException(nameof(scope), (int)scope, typeof(ExecutionPolicyScope));
            }
            

            return Enum.Parse<ExecutionPolicy>(RunCommand($"Get-ExecutionPolicy -Scope {scope}"));
        }
        private static string RunCommand(string command)
        {
            using Process powerShell = Process.Start(new ProcessStartInfo(Path, $"-WindowStyle Hidden -NoLogo -NoProfile -NonInteractive -Command & \"{command}\"")
            {
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden
            })!; // ! : it just wont return null
            return powerShell.StandardOutput.ReadToEnd();
        }
    }
    internal enum ExecutionPolicy
    {
        AllSigned,
        Bypass,
        Default,
        RemoteSigned,
        Restricted,
        Undefined,
        Unrestricted,
    }
    internal enum ExecutionPolicyScope
    {
        MachinePolicy,
        UserPolicy,
        //Process, would be useless as it would only target the powershell instance used to run the command
        CurrentUser,
        LocalMachine
    }
}
