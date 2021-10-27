// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A script that can be executed from a script host program.</summary>
    [Serializable]
    public class Script : ListViewItem, IScript, ISerializable
    {
        #region Private Fields

        private const byte RecommendedColorAlpha = 63;
        private readonly Color _initialBackColor;
        private FileInfo _source;
        private ScriptAdvised _scriptAdvised;

        #endregion Private Fields

        #region Public Constructors

        /*/// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class.
        /// </summary>
        public Script()
        {

        }*/

        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class by copying <paramref name="source"/> to the scripts directory.
        /// </summary>
        /// <param name="source">The source script file.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <inheritdoc cref="ScriptHost.FromFileExtension(string)" path="/exception"/>
        public Script(FileInfo source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            Host = ScriptHost.FromFileExtension(source.Extension);
            _initialBackColor = BackColor;
        }

        #endregion Public Constructors

        #region Protected Constructors

        /// <summary>Intializes a new instance of the <see cref="Script"/> class with the specified serialization information and streaming context.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is <see langword="null"/>.</exception>
        /// <inheritdoc/>
        protected Script(SerializationInfo info, StreamingContext context = default) => Deserialize(info, context);

        #endregion Protected Constructors

        #region Public Properties

        /// <inheritdoc/>
        public ScriptAdvised Advised
        {
            get => _scriptAdvised;
            set
            {
                _scriptAdvised = value;
                BackColor = EmulateAlpha(GetColor(value), _initialBackColor, RecommendedColorAlpha);
            }
        }

        /// <inheritdoc/>
        public string Description { get => ToolTipText; set => ToolTipText = value; }

        /// <inheritdoc/>
        public string Filename => _source.Name;

        /// <inheritdoc/>
        public IScriptHost Host { get; private set; }

        /// <inheritdoc/>
        public ICollection<Impact> Impacts { get; private set; }

        /// <inheritdoc/>
        public new string Name { get => Text; set => Text = value; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc/>
        /// <inheritdoc cref="IScriptHost.Execute(FileInfo)" path="/exception"/>
        public void Execute() => Host.Execute(_source);

        /// <inheritdoc/>
        public void Save()
        {
            static DirectoryInfo GetOrCreateScriptsDir()
            {
                DirectoryInfo tmpScriptsDir = null;
                try
                {
                    tmpScriptsDir = Directory.CreateDirectory(Path.Combine(Program.InstallDir.FullName, "Scripts"));
                }
                catch (UnauthorizedAccessException e)
                {
                    ErrorDialog.CantCreateScriptsDir(e, () => tmpScriptsDir = GetOrCreateScriptsDir(), Program.Exit);
                }

                Assert(tmpScriptsDir is not null);
                return tmpScriptsDir;
            }

            using FileStream fileStream = File.Create(Path.Combine(GetOrCreateScriptsDir().FullName, Name.ReplaceInvalidFilenameChars()));
            base.Serialize(new(typeof(Script), new FormatterConverter()), new StreamingContext(StreamingContextStates.File | StreamingContextStates.Persistence));
            /*XmlSerializer xml = new(typeof(Script));
            xml.Serialize(fileStream, this);*/
        }
        #endregion Public Methods

        #region Private Methods

        private static Color EmulateAlpha(Color color, Color fadeInto, byte alpha)
        {
            float amount = (float)alpha / byte.MaxValue;
            byte r = (byte)(color.R * amount + fadeInto.R * (1 - amount));
            byte g = (byte)(color.G * amount + fadeInto.G * (1 - amount));
            byte b = (byte)(color.B * amount + fadeInto.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        private static Color GetColor(ScriptAdvised scriptAdvised) => scriptAdvised switch
        {
            ScriptAdvised.Yes => Color.Green,
            ScriptAdvised.Limited => Color.Orange,
            ScriptAdvised.No => Color.Red,
            _ => throw new InvalidEnumArgumentException(nameof(scriptAdvised), (int)scriptAdvised, typeof(ScriptAdvised))
        };

        #endregion Private Methods
        /// <summary>Serializes the object.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is <see langword="null"/>.</exception>
        protected override void Serialize(SerializationInfo info, StreamingContext context = default)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(Description), Description);
            info.AddValue(nameof(_source), _source);
            info.AddValue(nameof(Advised), Advised);
            info.AddValue(nameof(Host), Host);
            info.AddValue(nameof(Impacts), Impacts);
        }
        /// <summary>Deserializes the object.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is <see langword="null"/>.</exception>
        protected override void Deserialize(SerializationInfo info, StreamingContext context = default)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            Name = info.GetString(nameof(Name));
            Description = info.GetString(nameof(Description));
            _source = (FileInfo)info.GetValue(nameof(_source), typeof(FileInfo));
            Advised = (ScriptAdvised)info.GetValue(nameof(Advised), typeof(ScriptAdvised));
            Host = (IScriptHost)info.GetValue(nameof(Host), typeof(IScriptHost));
            Impacts = (ICollection<Impact>)info.GetValue(nameof(Impacts), typeof(ICollection<Impact>));
        }
        /// <inheritdoc/>
        /// <remarks>Equivalent to <see cref="Serialize(SerializationInfo, StreamingContext)"/>.</remarks>
        public void GetObjectData(SerializationInfo info, StreamingContext context = default) => Serialize(info, context);
    }
}
