// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using WinCopies.Collections;

namespace RaphaëlBardini.WinClean.AppDir
{
    /// <summary>Represents the groups file in the application root directory.</summary>
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

        /// <summary>Gets the loaded groups</summary>
        /// <value>Groups loaded by <see cref="LoadGroups(ListView?)"/>. If the method has yet not been called, an empty list of groups.</value>
        public IList<ListViewGroup> Groups { get; } = new List<ListViewGroup>();

        #endregion Public Properties

        #region Public Methods

        /// <summary>Loads all the saved groups into the specified <see cref="ListView"/> control.</summary>
        /// <param name="owner">The control to add the loaded groups to. Can be null to only get the get the groups.</param>
        /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <see langword="null"/>.</exception>
        public void LoadGroups(ListView owner)
        {
            _ = owner ?? throw new ArgumentNullException(nameof(owner));

            if (s_groupsFile.Exists)
            {
                XmlDocument doc = new();

                {
                    try
                    {
                        using FileStream groupsFile = s_groupsFile.OpenRead();
                        {
                            doc.Load(groupsFile);
                        }
                    }
                    catch (Exception e) when (e is XmlException || e.FileSystem())
                    {
                        // The file may be corrupted, so overwrite with a fresh new group file, with no saved groups.
                        SaveGroups();
                    }

                    XmlNode root = doc.GetElementsByTagName("Groups")[0].FailNull();

                    foreach (XmlElement element in root.ChildNodes)
                    {
                        ListViewGroup group = FetchGroupFromAttributes(element);

                        _ = owner.Groups.AddIfNotContains(group);
                        Groups.Add(group);
                    }
                }
            }
            else
            {
                SaveGroups();
            }

            static ListViewGroup FetchGroupFromAttributes(XmlElement n) => new()
            {
                CollapsedState = Enum.Parse<ListViewGroupCollapsedState>(n.GetAttribute(nameof(ListViewGroup.CollapsedState)).Trim()),
                Header = n.GetAttribute(nameof(ListViewGroup.Header)).Trim(),
            };
        }

        public void SaveGroups()
        {
            XmlDocument doc = new();

            _ = doc.AppendChild(doc.CreateXmlDeclaration("1.0", "Unicode", null));

            XmlElement root = doc.CreateElement("Groups");

            foreach (ListViewGroup group in Groups)
            {
                if (group.Items.Count > 0)
                {
                    AppendGroupToRoot(group);
                }
            }

            _ = doc.AppendChild(root);

            SaveDoc();

            void SaveDoc()
            {
                try
                {
                    doc.Save(s_groupsFile.FullName);
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
                n.SetAttribute(nameof(ListViewGroup.Header), group.Header);

                _ = root.AppendChild(n);
            }
        }

        #endregion Public Methods
    }
}
