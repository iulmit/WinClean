// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Represents a property.</summary>
    public class PropertyInfo
    {
        #region Public Constructors

        /// <summary>Intializes a new instance of the <see cref="PropertyInfo"/> class.</summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="description">An user-friendly description for the property.</param>
        /// <param name="value">The current value of the property.</param>
        /// <param name="default">The value it defaults and can reset to.</param>
        /// <param name="readOnly">Wether the user should be able to edit the property.</param>
        /// <exception cref="ArgumentNullException">
        /// One or more of the arguments are <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> and <paramref name="default"/> are not of the same type.</exception>
        public PropertyInfo(string name, string description, object value, object @default, bool readOnly = false)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ReadOnly = readOnly;

            _ = value ?? throw new ArgumentNullException(nameof(value));
            _ = @default ?? throw new ArgumentNullException(nameof(@default));
            if (!value.GetType().Equals(@default.GetType()))
            {
                throw new ArgumentException($"{nameof(value)} ({value.GetType()}) and {nameof(@default)} ({@default.GetType()}) are not of the same type.");
            }
            Value = value;
            Default = @default;

            EditorAttribute editorAttribute = value.GetType().GetCustomAttribute<EditorAttribute>(false);
            Editor = (editorAttribute is null) ? new UITypeEditor() : (UITypeEditor)Activator.CreateInstance(Type.GetType(editorAttribute.EditorTypeName));
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>The value it defaults and can reset to.</summary>
        public object Default { get; }
        /// <summary>
        /// The current value of the property.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// <see langword="true"/> if the property doesn't have a <see langword="set"/> acessor; otherwise <see langword="false"/>.
        /// </summary>
        public bool ReadOnly { get; }

        /// <summary>An user-friendly description for the property.</summary>
        public string Description { get; }

        /// <summary>The type editor of the object.</summary>
        public UITypeEditor Editor { get; }

        /// <summary>The name of the property.</summary>
        public string Name { get; }

        #endregion Public Properties
    }
}
