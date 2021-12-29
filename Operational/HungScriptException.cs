namespace RaphaëlBardini.WinClean.Operational;

public class HungScriptException : Exception
{
    #region Public Constructors

    public HungScriptException(Logic.IScript script) : this(script, null!)
    {
    }

    public HungScriptException(Logic.IScript script, Exception innerException) : base($"The script '{script?.Name}' is probably hung.", innerException) => Script = script;

    public HungScriptException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public HungScriptException() : base("A script is probably hung.")
    {
    }

    public HungScriptException(string message) : base(message)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public Logic.IScript? Script { get; }

    #endregion Public Properties
}