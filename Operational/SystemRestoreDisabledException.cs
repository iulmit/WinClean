namespace RaphaëlBardini.WinClean.Operational;

public class SystemRestoreDisabledException : Exception
{
    public SystemRestoreDisabledException(string message) : base(message)
    {
    }

    public SystemRestoreDisabledException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public SystemRestoreDisabledException() : base("Impossible de créer le point de restauration car la protection du système est désactivée.")
    {
    }
}
