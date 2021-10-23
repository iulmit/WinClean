// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using RaphaëlBardini.WinClean.Operational;

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>A script that can be executed from a script host program.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2237", Justification = $"{nameof(Script)} does not support serialization.")]
    public class Script : ListViewItem, IScript
    {
        #region Private Fields

        private const byte RecommendedColorAlpha = 63;
        private readonly Color _initialBackColor;

        private ScriptAdvised _scriptAdvised;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>Instanciates a new <see cref="Script"/> object.</summary>
        /// <param name="host">The associated script host program.</param>
        /// <param name="existingScriptFileName">The filename of the script.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="host"/> or <paramref name="existingScriptFileName"/> are <see langword="null"/>.
        /// </exception>
        /// <inheritdoc cref="Path.Combine(string, string)" path="/exception"/>
        /// <inheritdoc cref="Helpers.ThrowIfUnacessible(FileInfo, FileAccess)"/>
        public Script(IScriptHost host, string existingScriptFileName)
        {
            File = new FileInfo(Path.Combine(IScript.ScriptsDir.FullName, existingScriptFileName));
            File.ThrowIfUnacessible(FileAccess.Read);
            Host = host ?? throw new ArgumentNullException(nameof(host));
            _initialBackColor = BackColor;
        }

        #endregion Public Constructors

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
        public FileInfo File { get; protected set; }

        /// <inheritdoc/>
        public IScriptHost Host { get; }

        /// <inheritdoc/>
        public IEnumerable<Impact> Impacts { get; init; }

        /// <inheritdoc/>
        public new string Name { get => Text; set => Text = value; }

        #endregion Public Properties

        #region Public Methods

        /// <inheritdoc cref="IScriptHost.Execute(FileInfo)" path="/summary"/>
        public void Execute()
        {
            try
            {
                Host.Execute(File);
            }
            catch (FileNotFoundException)
            {
                ErrorDialog.ScriptNotFound(File, Execute, null/*chaud : delete script from settings*/);
            }
            catch (Exception e) when (e is System.Security.SecurityException or UnauthorizedAccessException or IOException)
            {
                ErrorDialog.ScriptInacessible(File, e, Execute, null/*chaud : delete script from settings*/);
            }
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
    }
}
