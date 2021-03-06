using RaphaëlBardini.WinClean.Operational;
using RaphaëlBardini.WinClean.Presentation.Dialogs;

namespace RaphaëlBardini.WinClean.Presentation;

public class GroupDir
{
    #region Public Constructors

    public GroupDir(DirectoryInfo dir)
    {
        _ = dir ?? throw new ArgumentNullException(nameof(dir));
        CreateDir();
        Info = dir;

        void CreateDir()
        {
            try
            {
                dir.Create();
            }
            catch (Exception e) when (e.FileSystem())
            {
                FSErrorFactory.MakeFSError<RetryExitDialog>(e, FSVerb.Create, dir).ShowDialog(CreateDir);
            }
        }
    }

    #endregion Public Constructors

    #region Public Properties

    public DirectoryInfo Info { get; }

    #endregion Public Properties
}
