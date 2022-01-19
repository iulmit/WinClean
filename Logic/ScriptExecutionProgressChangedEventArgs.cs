namespace RaphaëlBardini.WinClean.Logic;

public class ScriptExecutionProgressChangedEventArgs : EventArgs
{
    public ScriptExecutionProgressChangedEventArgs(int scriptIndex) => ScriptIndex = scriptIndex;
    public int ScriptIndex { get; }
}

