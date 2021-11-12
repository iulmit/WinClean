// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.AppDir
{
    /// <summary>
    /// Represents the groups file in the application root directory.
    /// </summary>
    public class GroupsFile
    {
        #region Private Fields

        private static readonly FileInfo s_groupsFile = new(Path.Join(Program.AppDir.FullName, "Groups.xml"));

        #endregion Private Fields

        #region Private Constructors

        public GroupsFile()
        {
        }

        #endregion Private Constructors

        #region Public Properties

        public static GroupsFile Instance { get; } = new();

        /// <summary>
        /// Gets the loaded groups
        /// </summary>
        /// <value>Groups loaded by <see cref="LoadGroups(ListView?)"/>. If the method has yet not been called, <see langword="null"/>.</value>
        public IList<ListViewGroup>? Groups { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Loads all the saved groups into the specified <see cref="ListView"/> control.
        /// </summary>
        /// <param name="owner">The control to add the loaded groups to. Can be null to only get the get the groups.</param>
        public void LoadGroups(ListView? owner)
        {
            Groups = new List<ListViewGroup>();

            if (s_groupsFile.Exists && s_groupsFile.Length > 0)
            {
                XmlDocument doc = new();

                using FileStream groupsFile = s_groupsFile.OpenRead();
                {
                    doc.Load(groupsFile);

                    XmlNode? root = doc.GetElementsByTagName("Groups")[0];
                    Assert(doc.FirstChild is not null && root is not null);
                    foreach (XmlElement element in root.ChildNodes)
                    {
                        ListViewGroup group = FetchGroupFromAttributes(element);

                        if (owner is not null)
                        {
                            _ = owner.Groups.AddIfNotContains(group);
                        }
                        Groups.Add(group);
                    }
                }
            }
            else
            {
                SaveGroups(Array.Empty<ListViewGroup>());
            }

            static ListViewGroup FetchGroupFromAttributes(XmlElement n) => new()
            {
                CollapsedState = Enum.Parse<ListViewGroupCollapsedState>(n.GetAttribute(nameof(ListViewGroup.CollapsedState))),
                Footer = n.GetAttribute(nameof(ListViewGroup.Footer)),
                FooterAlignment = Enum.Parse<HorizontalAlignment>(n.GetAttribute(nameof(ListViewGroup.FooterAlignment))),
                Header = n.GetAttribute(nameof(ListViewGroup.Header)),
                HeaderAlignment = Enum.Parse<HorizontalAlignment>(n.GetAttribute(nameof(ListViewGroup.HeaderAlignment))),
                Name = n.GetAttribute(nameof(ListViewGroup.Name)),
                Subtitle = n.GetAttribute(nameof(ListViewGroup.Subtitle)),
                TaskLink = n.GetAttribute(nameof(ListViewGroup.TaskLink)),
                TitleImageIndex = int.Parse(n.GetAttribute(nameof(ListViewGroup.TitleImageIndex)), CultureInfo.InvariantCulture),
                TitleImageKey = n.GetAttribute(nameof(ListViewGroup.TitleImageKey)),
            };
        }

        public void SaveGroups(IEnumerable<ListViewGroup> groups)
        {
            XmlDocument doc = new();

            _ = doc.AppendChild(doc.CreateXmlDeclaration("1.0", "Unicode", null));

            XmlElement root = doc.CreateElement("Groups");

            foreach (ListViewGroup group in groups ?? throw new ArgumentNullException(nameof(groups)))
            {
                AppendGroupToRoot(group);
            }

            _ = doc.AppendChild(root);

            SaveDoc();

            void SaveDoc()
            {
                try
                {
                    using FileStream groupsFile = s_groupsFile.OpenWrite();
                    doc.Save(groupsFile);
                }
                catch (Exception e) when (e.FileSystem())
                {
                    ErrorDialog.CantAcessFile(e, s_groupsFile.FullName, SaveDoc);
                }
            }
            void AppendGroupToRoot(ListViewGroup group)
            {
                XmlElement n = doc.CreateElement("Group");

                n.SetAttribute(nameof(ListViewGroup.CollapsedState), Enum.GetName<ListViewGroupCollapsedState>(group.CollapsedState));
                n.SetAttribute(nameof(ListViewGroup.Footer), group.Footer);
                n.SetAttribute(nameof(ListViewGroup.FooterAlignment), Enum.GetName<HorizontalAlignment>(group.FooterAlignment));
                n.SetAttribute(nameof(ListViewGroup.Header), group.Header);
                n.SetAttribute(nameof(ListViewGroup.HeaderAlignment), Enum.GetName<HorizontalAlignment>(group.HeaderAlignment));
                n.SetAttribute(nameof(ListViewGroup.Name), group.Name);
                n.SetAttribute(nameof(ListViewGroup.Subtitle), group.Subtitle);
                n.SetAttribute(nameof(ListViewGroup.TaskLink), group.TaskLink);
                n.SetAttribute(nameof(ListViewGroup.TitleImageIndex), group.TitleImageIndex.ToString(CultureInfo.InvariantCulture));
                n.SetAttribute(nameof(ListViewGroup.TitleImageKey), group.TitleImageKey);

                _ = root.AppendChild(n);
            }
        }

        #endregion Public Methods
    }
}
