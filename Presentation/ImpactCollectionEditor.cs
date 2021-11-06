using RaphaëlBardini.WinClean.Logic;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>
    /// Displays to the user and allows edition of a collection of <see cref="Impact"/> objects.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710", Justification = "CollectionEditor implies Collection")]
    public partial class ImpactCollectionEditor : UserControl, ICollection<Impact>
    {
        #region Private Fields

        private readonly ObservableCollection<Impact> _impacts = new();

        private readonly ImageList _levelImages = new();

        private readonly List<ImpactRow> _tableImpactsRows = new();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImpactCollectionEditor"/> class.
        /// </summary>
        public ImpactCollectionEditor()
        {
            
            InitializeComponent();
            foreach (string levelName in Enum.GetNames<ImpactLevel>())
            {
                _levelImages.Images.Add(levelName, (Resources.Images.ResourceManager.GetObject(levelName, CultureInfo.CurrentUICulture) as Image).FailIfNull());
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <inheritdoc/>
        public int Count => _impacts.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _impacts.IsReadOnly;

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        public void Add(Impact item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            AddImpactRow(item);
            _impacts.Add(item);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            for (int i = 0; i < _tableImpactsRows.Count; i++)
            {
                RemoveImpactRow(i);
            }
            _impacts.Clear();
        }

        /// <inheritdoc/>
        public bool Contains(Impact item) => _impacts.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(Impact[] array, int arrayIndex) => _impacts.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public new void Dispose()
        {
            _levelImages.Dispose();
            base.Dispose();
        }

        /// <inheritdoc/>
        public IEnumerator<Impact> GetEnumerator() => _impacts.GetEnumerator();

        /// <inheritdoc/>
        public bool Remove(Impact item)
        {
            RemoveImpactRow(_tableImpactsRows.FindIndex((row) => row.Impact.Equals(item)));
            return _impacts.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_impacts).GetEnumerator();

        #endregion Public Methods

        #region Private Properties

        private Button NewRemoveImpactButton(int rowIndex)
        {
            Button b = SetForTable(new Button()
            {
                BackgroundImage = Resources.Images.Negative,
                BackgroundImageLayout = ImageLayout.Center,
                UseMnemonic = false,
                UseVisualStyleBackColor = true,
                TabIndex = tableImpacts.RowCount + tableImpacts.ColumnCount - 1,
                Size = new(20, 20),
            });
            b.Click += (_, _) =>
            {
                RemoveImpactRow(rowIndex);
            };
            return b;
        }

        #endregion Private Properties

        #region Private Methods

        private static T SetForTable<T>(T c) where T : Control
        {
            c.CausesValidation = false;
            c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            c.Margin = new(3, 0, 0, 3);
            return c;
        }

        private void AddImpactRow(Impact impact)
        {
            ImagedComboBox levelSelector = SetForTable(new ImagedComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                ImageList = _levelImages,
                Width = 39
            });
            levelSelector.Items.AddRange(Enum.GetValues<ImpactLevel>().Select((lvl) => (object)new ImagedComboBoxItem(_levelImages.Images.IndexOfKey(Enum.GetName<ImpactLevel>(lvl))) { Tag = lvl }).ToArray());
            levelSelector.SelectedItem = levelSelector.Items.Cast<ImagedComboBoxItem>().First((item) => Equals(item.Tag, impact.Level));

            IList effects = ImpactEffect.Values.ToList();
            ComboBox effectSelector = SetForTable(new ComboBox()
            {
                MaxDropDownItems = effects.Count,
                DataSource = effects,
                SelectedItem = impact.Effect
            });

            if (_tableImpactsRows.Count > 0)
            {
                ImpactRow oldLast = _tableImpactsRows.Last();
                oldLast.LevelControl = SetForTable(new Label()
                {
                    Text = impact.Effect.ToString(),
                });
                oldLast.EffectControl = SetForTable(new PictureBox()
                {
                    Image = _levelImages.Images[Enum.GetName<ImpactLevel>(impact.Level)]
                });
            }
            _tableImpactsRows.Add(new ImpactRow(levelSelector, effectSelector, NewRemoveImpactButton(_tableImpactsRows.Count + 1), impact));

            _ = tableImpacts.RowStyles.Add(new(SizeType.Absolute, 23));
            tableImpacts.Controls.AddRange(_tableImpactsRows[tableImpacts.RowCount++ - 1].ToArray());
        }

        private void ButtonAddImpact_Click(object _, EventArgs __) => AddImpactRow(new());

        private void RemoveImpactRow(int rowIndex)
        {
            foreach (Control control in _tableImpactsRows[rowIndex].ToArray())
            {
                tableImpacts.Controls.Remove(control);
            }
            _tableImpactsRows.RemoveAt(rowIndex);
            tableImpacts.RowStyles.RemoveAt(tableImpacts.RowStyles.Count - 1);

            tableImpacts.RowCount--;
        }

        #endregion Private Methods

        #region Private Classes

        private class ImpactRow
        {
            #region Public Constructors

            public ImpactRow(Control levelControl, Control effectControl, Button removeButton, Impact impact)
            {
                LevelControl = levelControl;
                EffectControl = effectControl;
                RemoveButton = removeButton;
                Impact = impact;
            }

            #endregion Public Constructors

            #region Public Properties

            public Control EffectControl { get; set; }
            public Impact Impact { get; }
            public Control LevelControl { get; set; }
            public Button RemoveButton { get; set; }

            #endregion Public Properties

            #region Public Methods

            public Control[] ToArray() => new Control[3] { LevelControl, EffectControl, RemoveButton };

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}