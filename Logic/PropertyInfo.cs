// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents a property.</summary>
    public class PropertyInfo
    {
        #region Public Constructors

        /// <summary>Intializes a new instance of the <see cref="PropertyInfo"/> class.</summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="description">An user-friendly description for the property.</param>
        /// <param name="get">The <see langword="get"/> acessor of the property.</param>
        /// <param name="set">The facultative <see langword="set"/> acessor of the property.</param>
        /// <param name="default">The value it defaults and can reset to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/>, <paramref name="description"/> or <paramref name="get"/> are <see langword="null"/>.
        /// </exception>
        public PropertyInfo(string name, string description, Func<IConvertible> get, Action<IConvertible> set = null, IConvertible @default = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Get = get ?? throw new ArgumentNullException(nameof(get));
            Set = set;
            Default = @default;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>The value it defaults and can reset to.</summary>
        public IConvertible Default { get; }

        /// <summary>An user-friendly description for the property.</summary>
        public string Description { get; }

        /// <summary>The control used to show and edit the value from the user.</summary>
        /// <exception cref="NotSupportedException"></exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0072", Justification = "Not supporting every typecode.")]
        public Control Editor => Default.GetTypeCode() switch
        {
            TypeCode.Boolean => MakeBoolEditor(),
            TypeCode.Char => MakeCharEditor(),
            TypeCode.SByte => MakeNumericEditor(sbyte.MinValue, sbyte.MaxValue),
            TypeCode.Byte => MakeNumericEditor(byte.MinValue, byte.MaxValue),
            TypeCode.Int16 => MakeNumericEditor(short.MinValue, short.MaxValue),
            TypeCode.UInt16 => MakeNumericEditor(ushort.MinValue, ushort.MaxValue),
            TypeCode.Int32 => MakeNumericEditor(int.MinValue, int.MaxValue),
            TypeCode.UInt32 => MakeNumericEditor(uint.MinValue, uint.MaxValue),
            TypeCode.Int64 => MakeNumericEditor(long.MinValue, long.MaxValue),
            TypeCode.UInt64 => MakeNumericEditor(ulong.MinValue, ulong.MaxValue),
            TypeCode.Single => MakeNumericEditor(float.MinValue, float.MaxValue),
            TypeCode.Double => MakeNumericEditor(double.MinValue, double.MaxValue),
            TypeCode.Decimal => MakeNumericEditor(decimal.MinValue, decimal.MaxValue),
            TypeCode.DateTime => MakeDateTimeEditor(),
            TypeCode.String => MakeStringEditor(),
            _ => throw new NotSupportedException($"{Default.GetTypeCode()} is not supported.")
        };

        /// <summary>The <see langword="get"/> acessor of the property.</summary>
        public Func<IConvertible> Get { get; }

        /// <summary>The name of the property.</summary>
        public string Name { get; }

        /// <summary>The facultative <see langword="set"/> acessor of the property.</summary>
        public Action<IConvertible> Set { get; }

        #endregion Public Properties

        #region Private Methods

        private void InitEditor(Control c)
        {
            using ToolTip t = new();
            t.SetToolTip(c, Description);

            c.CausesValidation = false;
            c.AutoSize = true;
            c.Enabled = Set != null;
        }

        private CheckBox MakeBoolEditor()
        {
            CheckBox boolEditor = new();
            boolEditor.CheckedChanged += (s, e) => Set?.Invoke(boolEditor.Checked);
            boolEditor.Checked = Get().ToBoolean(CultureInfo.CurrentCulture);

            InitEditor(boolEditor);

            return boolEditor;
        }

        private TextBox MakeCharEditor()
        {
            TextBox charEditor = new()
            {
                MaxLength = 1
            };
            charEditor.TextChanged += (s, e) => Set?.Invoke(charEditor.Text);
            charEditor.Text = Get().ToChar(CultureInfo.CurrentCulture).ToString();

            InitEditor(charEditor);

            return charEditor;
        }

        private DateTimePicker MakeDateTimeEditor()
        {
            DateTimePicker dateTimeEditor = new();
            dateTimeEditor.ValueChanged += (s, e) => Set?.Invoke(dateTimeEditor.Value);
            dateTimeEditor.Value = Get().ToDateTime(CultureInfo.CurrentCulture);

            InitEditor(dateTimeEditor);

            return dateTimeEditor;
        }

        private NumericUpDown MakeNumericEditor(IConvertible min, IConvertible max)
        {
            NumericUpDown numericEditor = new()
            {
                Minimum = min.ToDecimal(CultureInfo.InvariantCulture),
                Maximum = max.ToDecimal(CultureInfo.InvariantCulture)
            };
            numericEditor.ValueChanged += (s, e) => Set?.Invoke(numericEditor.Value);
            numericEditor.Value = Get().ToDecimal(CultureInfo.CurrentCulture);

            InitEditor(numericEditor);

            return numericEditor;
        }

        private TextBox MakeStringEditor()
        {
            TextBox stringEditor = new();
            stringEditor.TextChanged += (s, e) => Set?.Invoke(stringEditor.Text);
            stringEditor.Text = Get().ToString(CultureInfo.CurrentCulture);

            InitEditor(stringEditor);

            return stringEditor;
        }

        #endregion Private Methods
    }
}
