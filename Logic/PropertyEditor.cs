// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A set of properties that can be edited by the user.</summary>
    public class PropertyEditor : TableLayoutPanel
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="PropertyEditor"/> class with the specified properties.</summary>
        /// <param name="properties">The properties that the user will be able to see.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is <see langword="null"/>.</exception>
        public PropertyEditor(IList<PropertyInfo> properties)
        {
            Properties = properties ?? throw new ArgumentNullException(nameof(properties));

            SuspendLayout();

            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            AutoScroll = AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CausesValidation = false;
            _ = RowStyles.Add(new(SizeType.AutoSize));
            _ = ColumnStyles.Add(new(SizeType.AutoSize));

            for (int i = 0; i < properties.Count; ++i)
            {
                Controls.Add(new Label()
                {
                    CausesValidation = false,
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Text = properties[i].Name,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Enabled = properties[i].Set != null,
                }, 0, i);
                Controls.Add(properties[i].Editor, 1, i);
            }
            ResumeLayout();
        }

        ///<inheritdoc cref="PropertyEditor(IList{PropertyInfo})"/>
        public PropertyEditor(params PropertyInfo[] properties) : this((IList<PropertyInfo>)properties)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>The properties that the user will be able to see.</summary>
        public IList<PropertyInfo> Properties { get; }

        #endregion Public Properties
    }
}
