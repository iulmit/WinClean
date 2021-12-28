using RaphaëlBardini.WinClean.Logic;

namespace RaphaëlBardini.WinClean.Presentation;

// Creator interface for Factory Method pattern implementation.
public interface IScriptSerializer
{
    IScript Deserialize(FileInfo source);

    void Serialize(IScript s);
}