// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Presentation
{
    /// <summary>Displays the traditional about box with application-related metadata</summary>
    public partial class AboutBox : Form
    {
        #region Public Constructors

        /// <summary>Initializes a new instance of the <see cref="AboutBox"/> classe.</summary>
        public AboutBox()
        {
            InitializeComponent();

            Text = Resources.FormattableStrings.About(Application.ProductName);

            labelProductName.Text = Application.ProductName;
            labelVersion.Text = Resources.FormattableStrings.Version(Application.ProductVersion);
            AddAssemblyAttributes();
        }

        #endregion Public Constructors

        #region Private Methods

        private void AddAssemblyAttributes()
        {
            Assembly a = Assembly.GetExecutingAssembly();

            labelDescription.Text = a.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            labelCompanyName.Text = a.GetCustomAttribute<AssemblyCompanyAttribute>().Company;

            _ = linkLabelRepoURL.Links.Add(0, linkLabelRepoURL.Text.Length, a.GetCustomAttribute<AssemblyMetadataAttribute>().Value);
            labelCopyright.Text = a.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
        }

        private void labelRepoURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelRepoURL.LinkVisited = true;
            using System.Diagnostics.Process _ = System.Diagnostics.Process.Start("explorer", (string)e.Link.LinkData);
        }

        #endregion Private Methods
    }
}
