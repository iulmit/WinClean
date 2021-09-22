// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>A <see cref="Logic.IPreset"/>, as seen by the <see cref="Presentation"/> layer.</summary>
    public class Preset : Logic.Preset
    {
        #region Private Properties

        private string[] StandardPresetSubItems => new string[]
        {
                Scripts.Count().ToString(),
        };

        #endregion Private Properties

        #region Public Constructors

        /// <summary>Generates a new instance of the <see cref="Preset"/> class with a name, a description, and a scripts collection.</summary>
        /// <inheritdoc cref="Logic.Preset.Preset(string, string, IEnumerable{Logic.Script})" path="/exception"/>
        public Preset(string name, string description, IEnumerable<Script> scripts) : base(name, description, scripts)
        {
        }

        /// <summary>Generates a new instance of the <see cref="Preset"/> class with a name and a description.</summary>
        /// <inheritdoc cref="Preset(string, string, IEnumerable{Script})" path="/exception"/>
        public Preset(string name, string description) : this(name, description, Enumerable.Empty<Script>())
        {
        }

        /// <summary>Generates a new instance of the <see cref="Preset"/> class with a name.</summary>
        /// <inheritdoc cref="Preset(string, string, IEnumerable{Script})" path="/exception"/>
        public Preset(string name) : this(name, string.Empty, Enumerable.Empty<Script>())
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>Creates a new <see cref="Preset"/> from the checked items of a <see cref="ListView"/>.</summary>
        /// <param name="scriptsListView">The <see cref="ListView"/> to save the <see cref="Preset"/> from.</param>
        /// <returns></returns>
        public static Preset CreateFromScripts(ListView scriptsListView)
        {
            if (scriptsListView is null)
                throw new ArgumentNullException(nameof(scriptsListView));

            string name = $"Nouvelle présélection {Program.Presets.Count((p) => p.Name.StartsWith("Nouvelle présélection")) + 1}";
            const string desc = "Ceci est une nouvelle présélection. Vous pouvez la renommer avec la touche F2 ou avec clic droit, puis renommer.";

            IEnumerable<Script> scripts = scriptsListView.CheckedItems.ToEnumerable().Select((sChecked) => Script.RetrieveTag(sChecked));
            return new Preset(name, desc, scripts);
        }

        /// <summary>Retrieves a <see cref="Preset"/> from a <see cref="ListViewItem"/>.</summary>
        /// <param name="item">Contains the <see cref="Preset"/> in it's <see cref="ListViewItem.Tag"/> property.</param>
        /// <returns>The instance of <see cref="Preset"/> contained in the <see cref="ListViewItem.Tag"/> property of the parameter.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="item"/> doesn't contains a valid <see cref="IEnumerable{Script}"/>.</exception>
        public static Preset Create(ListViewItem item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));
            return new Preset(
            item.Text ?? string.Empty,
            item.ToolTipText ?? string.Empty,
            // If we pass an empty script collection instead of throwing, any ListViewItem can become a preset and nobody will know.
            (item.Tag as IEnumerable<Script>) ?? throw new ArgumentException($"Is not a valid {nameof(Preset)}", $"{nameof(item)}.{nameof(item.Tag)}")
            );
        }

        /// <summary>Loads a preset into a <see cref="ListView"/> control.</summary>
        /// <param name="scriptsListView">The <see cref="ListView"/> to load the <see cref="Preset"/> in.</param>
        /// <exception cref="ArgumentNullException"><paramref name="scriptsListView"/> is <see langword="null"/>.</exception>
        public void Load(ListView scriptsListView)
        {
            if (scriptsListView is null)
                throw new ArgumentNullException(nameof(scriptsListView));
            scriptsListView.CheckedItems.SetAllChecked(false);
            Scripts.ForEach((s) => scriptsListView.Items.Find(s.Name, false)[0].Checked = true);
        }

        public ListViewItem ToListViewItem()
        {
            ListViewItem @new = new (Name)
            {
                ToolTipText = Description,
                Tag = Scripts
            };
            @new.SubItems.AddRange(StandardPresetSubItems);
            return @new;
        }

        #endregion Public Methods
    }
}
