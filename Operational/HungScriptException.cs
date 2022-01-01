namespace RaphaëlBardini.WinClean.Operational;

public class HungScriptException : Exception
{
    #region Public Constructors

    public HungScriptException(string scriptName) : this(scriptName, null!)
    {
    }

    public HungScriptException(string scriptName, Exception innerException) : base($"The script '{scriptName}' is probably hung.", innerException) => ScriptName = scriptName;

    public HungScriptException() : base("A script is probably hung.")
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public string? ScriptName { get; }

    #endregion Public Properties
}