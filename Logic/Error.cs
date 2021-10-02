// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    public static class Error
    {
        public enum Level
        {
            Critical,
            Error,
            Warning,
            Information
        }
        /// <summary>Prompts the user for quitting the application after showing the exception's details and logs it.</summary>
        /// <param name="summary">A complementary message to be shown to the user.</param>
        /// <param name="lvl">The seriousness of the exception.</param>
        /// <exception cref="ArgumentNullException"><paramref name="e"/> is <see langword="null"/>.</exception>
        public static void Handle(this Exception e, Level lvl, string summary = "")
        {
            (e ?? throw new ArgumentNullException(nameof(e))).ToString().Log(nameof(Handle), lvl);
            HandleDontLog(e, lvl, summary);
        }

        /// <summary>Prompts the user for quitting the application after displaying him an error (not an exception).</summary>
        /// <param name="lvl">The seriousness of the error.</param>
        /// <param name="summary">>A complementary message to be shown to the user.</param>
        public static void Handle(this string str, Level lvl, string summary = "")
        {
            str.Log(nameof(Handle), lvl);
            PromptQuit(lvl, summary, str);
        }

        /// <inheritdoc cref="Handle(Exception, string, TraceEventType)"/>
        /// <remarks>Performs no log operation. Useful if a log operation failed and would fail again.</remarks>
        public static void HandleDontLog(this Exception e, Level lvl, string summary = "") => PromptQuit(lvl, summary, e?.Message);
        /// <summary>Shows a message box and prompts the user for quitting the application.</summary>
        private static void PromptQuit(Level lvl, string summary, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException($"'{nameof(message)} can't be null or whitespace", nameof(message));
            if (!string.IsNullOrWhiteSpace(summary))
                summary += $"{Constants.NL}{Constants.NL}";

            (MessageBoxIcon icon, string caption, bool quit) = lvl.Parse();
            if (MessageBox.Show(
            $"{summary}{message}\n\n{(quit ? Resources.ErrorMessages.ClickOKToExit : Resources.ErrorMessages.PromptContinueApp)}"
            , caption, quit ? MessageBoxButtons.OK : MessageBoxButtons.YesNo, icon) != DialogResult.Yes)
                Helpers.Exit();
        }

        /// <summary>Parses a <see cref="Level"/> enum to data for a message box.</summary>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><paramref name="lvl"/> is not a defined <see cref="Level"/> constant.</exception>
        private static (MessageBoxIcon Icon, string Caption, bool Quit) Parse(this Level lvl) => lvl switch
        {
            Level.Critical => (MessageBoxIcon.Error, Resources.ErrorStrings.Critical, true),
            Level.Error => (MessageBoxIcon.Error, Resources.ErrorStrings.Error, false),
            Level.Warning => (MessageBoxIcon.Warning, Resources.ErrorStrings.Warning, false),
            Level.Information => (MessageBoxIcon.Information, Resources.ErrorStrings.Info, false),
            _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(TraceEventType))
        };
    }
}
