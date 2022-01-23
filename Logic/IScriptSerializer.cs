namespace RaphaëlBardini.WinClean.Logic;

// Creator interface for Factory Method pattern implementation.
public interface IScriptSerializer
{
    #region Public Methods

    IScript Deserialize(FileInfo source);

    void Serialize(IScript s);

    #endregion Public Methods
}
