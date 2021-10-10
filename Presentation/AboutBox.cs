// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    public partial class AboutBox : Form
    {
        #region Public Constructors

        public AboutBox()
        {
            InitializeComponent();
            Text = Resources.FormattableStrings.About(Application.ProductName);
            labelProductName.Text = Application.ProductName;
            labelVersion.Text = Resources.FormattableStrings.Version(Application.ProductVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            labelDescription.Text = AssemblyDescription;
        }

        #endregion Public Constructors

        #region Assembly attributes accessors

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        #endregion Assembly attributes accessors
    }
}
