using System.Reflection;

namespace RaphaëlBardini.WinClean.Presentation;

/// <summary>
/// Displays the traditional about box with application-related metadata
/// </summary>
public partial class AboutBox : Form
{
    #region Public Constructors

    public AboutBox()
    {
        InitializeComponent();

        Text = string.Format(CultureInfo.CurrentCulture, Resources.FormattableStrings.About, Application.ProductName);
        labelVersion.Text = string.Format(CultureInfo.CurrentCulture, Resources.FormattableStrings.Version, Application.ProductVersion);
        labelProductName.Text = Application.ProductName;

        AddAssemblyAttributes();
    }

    #endregion Public Constructors

    #region Private Methods

    private void AddAssemblyAttributes()
    {
        Assembly a = Assembly.GetExecutingAssembly();

        labelDescription.Text = a.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
        labelCompanyName.Text = a.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;

        _ = linkLabelRepoURL.Links.Add(0, linkLabelRepoURL.Text.Length, a.GetCustomAttribute<AssemblyMetadataAttribute>()?.Value);
        labelCopyright.Text = a.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
    }

    private void LabelRepoURL_LinkClicked(object __, LinkLabelLinkClickedEventArgs e)
    {
        linkLabelRepoURL.LinkVisited = true;
        using System.Diagnostics.Process _ = System.Diagnostics.Process.Start("explorer", (string)e.Link.LinkData);
    }

    #endregion Private Methods
}