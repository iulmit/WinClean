// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    public enum ErrorActions
    {
        AbortContinue,
        OK,
        Close,
    }

    public enum ErrorLevel
    {
        Error,
        Warning,
        Info
    }

    public static class ErrorActionsConverter
    {
        #region Public Methods

        /// <summary>Converts a <see cref="ErrorActions"/> enumeration to a <see cref="TaskDialogButtonCollection"/> object.</summary>
        /// <returns><paramref name="lvl"/>'s corresponding <see cref="TaskDialogButtonCollection"/>.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><paramref name="lvl"/> is not a defined <see cref="ErrorActions"/> constant.</exception>
        public static TaskDialogButtonCollection ToTaskDialogButtonCollection(this ErrorActions actions)
            => actions switch
            {
                ErrorActions.AbortContinue => new TaskDialogButtonCollection { TaskDialogButton.Abort, TaskDialogButton.Continue },
                ErrorActions.OK => new TaskDialogButtonCollection { TaskDialogButton.OK },
                ErrorActions.Close => new TaskDialogButtonCollection { TaskDialogButton.Close },
                _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(actions), (int)actions, typeof(ErrorActions))
            };

        #endregion Public Methods
    }

    public static class LevelConverter
    {
        #region Public Methods

        /// <summary>Converts a <see cref="ErrorLevel"/> enumeration to a localized error string.</summary>
        /// <returns><paramref name="lvl"/>'s corresponding localized error string.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><paramref name="lvl"/> is not a defined <see cref="ErrorLevel"/> constant.</exception>
        public static string ToErrorString(this ErrorLevel lvl)
            => lvl switch
            {
                ErrorLevel.Error => Resources.ErrorStrings.Error,
                ErrorLevel.Warning => Resources.ErrorStrings.Warning,
                ErrorLevel.Info => Resources.ErrorStrings.Info,
                _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ErrorLevel))
            };

        /// <summary>Converts a <see cref="ErrorLevel"/> enumeration to a <see cref="TaskDialogIcon"/>.</summary>
        /// <returns><paramref name="lvl"/>'s corresponding <see cref="TaskDialogIcon"/>.</returns>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"><paramref name="lvl"/> is not a defined <see cref="ErrorLevel"/> constant.</exception>
        public static TaskDialogIcon ToTaskDialogIcon(this ErrorLevel lvl)
            => lvl switch
            {
                ErrorLevel.Error => TaskDialogIcon.Error,
                ErrorLevel.Warning => TaskDialogIcon.Warning,
                ErrorLevel.Info => TaskDialogIcon.Information,
                _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(lvl), (int)lvl, typeof(ErrorLevel))
            };

        #endregion Public Methods
    }

    public static class TaskDialogButtonCollectionConverter
    {
        #region Public Methods

        /// <summary>Converts a <see cref="TaskDialogButtonCollection"/> object to an <see cref="ErrorActions"/> enumeration.</summary>
        /// <returns><paramref name="buttons"/>'s corresponding <see cref="ErrorActions"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="buttons"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="buttons"/> cannot be converted to an <see cref="ErrorActions"/>.</exception>
        public static ErrorActions ToErrorActions(this TaskDialogButtonCollection buttons)
        {
            if (buttons is null)
                throw new ArgumentNullException(nameof(buttons));
            if (buttons.SequenceEqual(new TaskDialogButtonCollection() { TaskDialogButton.Abort, TaskDialogButton.Continue }))
                return ErrorActions.AbortContinue;
            if (buttons.SequenceEqual(new TaskDialogButtonCollection() { TaskDialogButton.OK }))
                return ErrorActions.OK;
            if (buttons.SequenceEqual(new TaskDialogButtonCollection() { TaskDialogButton.Close }))
                return ErrorActions.Close;
            throw new ArgumentException($"Cannot convert to {nameof(ErrorActions)} enum.", nameof(buttons));
        }

        #endregion Public Methods
    }

    public static class TaskDialogIconConverter
    {
        #region Public Methods

        /// <summary>Converts a <see cref="TaskDialogIcon"/> object to a <see cref="ErrorLevel"/> enumeration.</summary>
        /// <returns><paramref name="icon"/>'s corresponding <see cref="ErrorLevel"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="icon"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="icon"/> cannot be converted to a <see cref="ErrorLevel"/>.</exception>
        public static ErrorLevel ToLevel(this TaskDialogIcon icon)
        {
            if (icon is null)
                throw new ArgumentNullException(nameof(icon));

            if (icon.Equals(TaskDialogIcon.Error))
                return ErrorLevel.Error;
            if (icon.Equals(TaskDialogIcon.Warning))
                return ErrorLevel.Warning;
            if (icon.Equals(TaskDialogIcon.Information))
                return ErrorLevel.Info;

            throw new ArgumentException($"Cannot convert to {nameof(ErrorLevel)} enum.", nameof(icon));
        }

        #endregion Public Methods
    }

    public class UserFriendlyError : IEquatable<UserFriendlyError>
    {
        #region Private Fields

        private readonly TaskDialogPage _page;

        /// <exception cref="ArgumentNullException"><paramref name="page"/> is <see langword="null"/>.</exception>
        public UserFriendlyError(TaskDialogPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }
        public UserFriendlyError() => _page.Caption = Application.ProductName;
        #endregion Private Fields

        #region Public Properties

        /// <summary>Gets or sets the error's commit buttons.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogPage.Buttons" path="/exception"/>
        /// <inheritdoc cref="ErrorActionsConverter.ToTaskDialogButtonCollection(ErrorActions)" path="/exception"/>
        public ErrorActions Actions { get => _page.Buttons.ToErrorActions(); set => _page.Buttons = value.ToTaskDialogButtonCollection(); }

        /// <summary>Gets or sets the error's additionnal information.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogFootnote.Text" path="/exception"/>
        public string AdditionnalInfo { get => _page.Footnote.Text; set => _page.Footnote.Text = value; }

        /// <summary>Gets or sets the error's severity level.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogPage.Buttons" path="/exception"/>
        /// <inheritdoc cref="LevelConverter.ToTaskDialogIcon(ErrorLevel)" path="/exception"/>
        public ErrorLevel Level { get => _page.Icon.ToLevel(); set => _page.Icon = value.ToTaskDialogIcon(); }

        /// <summary>Gets or sets the error's main instruction.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogPage.Heading" path="/exception"/>
        public string MainInstruction { get => _page.Heading; set => _page.Heading = value; }

        /// <summary>Gets or sets the error's proposed solution.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogPage.Text" path="/exception"/>
        public string Solution { get => _page.Text; set => _page.Text = value; }

        /// <summary>Gets or sets the error's technical details.</summary>
        /// <remarks>The default value is <see langword="null"/>.</remarks>
        /// <inheritdoc cref="TaskDialogExpander.Text" path="/exception"/>
        public string TechnicalDetails { get => _page.Expander.Text; set => _page.Expander.Text = value; }

        public override bool Equals(object obj) => Equals(obj as UserFriendlyError);

        public bool Equals(UserFriendlyError other, StringComparison comparisonType) => other != null
                                                       && Actions.Equals(other.Actions)
                                                       && AdditionnalInfo.Equals(other.AdditionnalInfo, comparisonType)
                                                       && Level.Equals(other.Level)
                                                       && MainInstruction.Equals(other.MainInstruction, comparisonType)
                                                       && Solution.Equals(other.Solution, comparisonType)
                                                       && TechnicalDetails.Equals(other.TechnicalDetails, comparisonType);

        public override int GetHashCode() => HashCode.Combine(Actions, AdditionnalInfo, Level, MainInstruction, Solution, TechnicalDetails);

        #endregion Public Properties

        #region Public Methods

        public TaskDialogButton Show(IWin32Window owner = null) => TaskDialog.ShowDialog(owner, _page);

        #endregion Public Methods
    }
}
