namespace RaphaëlBardini.WinClean.Operational;

public class SystemProtectionDisabledException : Exception
{
    #region Public Constructors

    public SystemProtectionDisabledException(string message) : base(message)
    {
    }

    public SystemProtectionDisabledException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SystemProtectionDisabledException() : base(Resources.DevException.SystemProtectionDisabled)
    {
    }

    #endregion Public Constructors
}
