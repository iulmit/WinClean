namespace RaphaëlBardini.WinClean.Logic;

public class ScriptExecutionProgressChangedEventArgs : EventArgs
{
    #region Public Constructors

    public ScriptExecutionProgressChangedEventArgs(int scriptIndex) => ScriptIndex = scriptIndex;

    #endregion Public Constructors

    #region Public Properties

    public int ScriptIndex { get; }

    #endregion Public Properties
}
