namespace RaphaëlBardini.WinClean.Operational;

public class TimeoutException : Exception
{
    #region Public Constructors

    public TimeoutException() : base("A timeout was reached.")
    {
    }

    public TimeoutException(string message) : base(message)
    {
    }

    public TimeoutException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public TimeoutException(TimeSpan timeout, string message) : base(message) => Timeout = timeout;

    public TimeoutException(TimeSpan timeout) : base($"A timeout of {timeout} was reached.") => Timeout = timeout;

    #endregion Public Constructors

    #region Public Properties

    public TimeSpan Timeout { get; }

    #endregion Public Properties
}