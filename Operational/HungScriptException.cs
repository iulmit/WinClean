namespace RaphaëlBardini.WinClean.Operational;

public class HungScriptException : Exception
{
    #region Public Constructors

    public HungScriptException(string? scriptName) : this(scriptName, null)
    {
    }

    public HungScriptException(string? scriptName, Exception? innerException) : base(string.Format(CultureInfo.CurrentCulture, Resources.DevException.HungScriptSpecified, scriptName), innerException)
        => ScriptName = scriptName;

    public HungScriptException() : base(Resources.DevException.HungScript)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public string? ScriptName { get; }

    #endregion Public Properties
}
