// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class SettingsForm : Form
    {
        #region Public Constructors
        public SettingsForm()
        {
            InitializeComponent();
            propertyGridSettings.SelectedObject = new CustomObjectWrapper(Sett)
        }

        #endregion Public Constructors
    }

    public struct Settings
    {
        public static void LoadDefaults()
        {
            AppLogLevel = LogLevel.Verbose;
            ScriptTimeout = TimeSpan.FromMinutes(30);
        }
        #region Public Properties

        [DisplayName("Niveau de journalisation")]
        [Description("Global à l'application.")]
        public static LogLevel AppLogLevel { get => LogManager.MinLogLevel; set => LogManager.MinLogLevel = value; }

        [DisplayName("Temps maximum d'exécution d'un script")]
        [Description("Un avertissement s'affichera si un script est toujours en cours d'exécution après cette durée écoulé.")]
        public static TimeSpan ScriptTimeout { get => Operational.IScriptHost.Timeout; set => Operational.IScriptHost.Timeout = value; }

        #endregion Public Properties
    }

    public class CustomObjectWrapper : CustomTypeDescriptor
    {
        public object WrappedObject { get; private set; }
        private IEnumerable<PropertyDescriptor> staticProperties;
        public CustomObjectWrapper(object o)
            : base(TypeDescriptor.GetProvider(o).GetTypeDescriptor(o))
        {
            WrappedObject = o;
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var instanceProperties = base.GetProperties(attributes)
                .Cast<PropertyDescriptor>();
            staticProperties = WrappedObject.GetType()
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(p => new StaticPropertyDescriptor(p, WrappedObject.GetType()));
            return new PropertyDescriptorCollection(
                instanceProperties.Union(staticProperties).ToArray());
        }
    }

    public class StaticPropertyDescriptor : PropertyDescriptor
    {
        PropertyInfo p;
        Type owenrType;
        public StaticPropertyDescriptor(PropertyInfo pi, Type owenrType) : base(pi.Name, pi.GetCustomAttributes().Cast<Attribute>().ToArray())
        {
            p = pi;
            this.owenrType = owenrType;
        }
        public override bool CanResetValue(object c) => false;
        public override object GetValue(object c) => p.GetValue(null);
        public override void ResetValue(object c) { }
        public override void SetValue(object c, object v) => p.SetValue(null, v);
        public override bool ShouldSerializeValue(object c) => false;
        public override Type ComponentType { get { return owenrType; } }
        public override bool IsReadOnly { get { return !p.CanWrite; } }
        public override Type PropertyType { get { return p.PropertyType; } }
    }
}
