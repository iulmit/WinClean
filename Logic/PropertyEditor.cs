// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A set of properties that can be edited by the user.</summary>
    public class PropertyEditor : TableLayoutPanel
    {
        private readonly ToolTip _toolTip = new() { Active = true };

        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="PropertyEditor"/> class with the specified properties.</summary>
        /// <param name="properties">The properties that the user will be able to see.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is <see langword="null"/>.</exception>
        public PropertyEditor(IList<PropertyDescriptor> properties)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));

            SuspendLayout();

            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            AutoScroll = AutoSize = true;
            CausesValidation = false;
            ColumnCount = 2;
            _ = ColumnStyles.Add(new(SizeType.AutoSize));
            _ = ColumnStyles.Add(new(SizeType.AutoSize));

            for (int i = 0; i < properties.Count; ++i)
            {
                Label label = new()
                {
                    CausesValidation = false,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Text = properties[i].DisplayName,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Enabled = !properties[i].IsReadOnly
                };
                _toolTip.SetToolTip(label, properties[i].Description);
                Controls.Add(label, 0, i);

                _ = RowStyles.Add(new(SizeType.AutoSize));
            }

            ResumeLayout();
        }

        ///<inheritdoc cref="PropertyEditor(IList{PropertyDescriptor})"/>
        public PropertyEditor(params PropertyDescriptor[] properties) : this((IList<PropertyDescriptor>)properties)
        {
        }

        /// <inheritdoc/>
        public new void Dispose()
        {
            _toolTip.Dispose();
            base.Dispose();
        }
        #endregion Public Constructors

        #region Public Properties

        /// <summary>The properties that the user will be able to see.</summary>
        public IList<PropertyDescriptor> Properties { get; }

        #endregion Public Properties

        /// <inheritdoc/>
        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            if (e is not null && e.Column == 1)
            {
                ((UITypeEditor)Properties[e.Row].GetEditor(typeof(UITypeEditor))).PaintValue(Properties[e.Row].GetValue(null), e.Graphics, e.CellBounds);
            }
            base.OnCellPaint(e);
        }
    }
}
