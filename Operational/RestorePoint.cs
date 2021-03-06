using System.Management;
using System.Runtime.InteropServices;

namespace RaphaëlBardini.WinClean.Operational;

public enum EventType
{
    None,

    /// <summary>
    /// A system change has begun. A subsequent nested call does not create a new restore point.
    /// <para>Subsequent calls must use <see cref="EventType.EndNestedSystemChange"/>, not <see cref="EventType.EndSystemChange"/>.</para>
    /// </summary>
    BeginNestedSystemChange = 0x66,

    /// <summary>A system change has begun.</summary>
    BeginSystemChange = 0x64,

    /// <summary>A system change has ended.</summary>
    EndNestedSystemChange = 0x67,

    /// <summary>A system change has ended.</summary>
    EndSystemChange = 0x65
}

/// <seealso href="https://stackoverflow.com/a/42733327/11718061"/>
public class RestorePoint
{
    #region Private Fields

    private readonly string _description;
    private readonly EventType _eventType;
    private readonly RestorePointType _type;

    #endregion Private Fields

    #region Public Constructors

    /// <param name="description">The description to be displayed so the user can easily identify a restore point.</param>
    /// <param name="eventType">The type of event.</param>
    /// <param name="type">The type of restore point.</param>
    public RestorePoint(string description, EventType eventType, RestorePointType type)
    {
        _description = description;
        _eventType = eventType;
        _type = type;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>Creates a restore point on the local system.</summary>
    /// <exception cref="ManagementException">Access denied.</exception>
    /// <exception cref="SystemProtectionDisabledException">System restore is disabled.</exception>
    public void Create()
    {
        ManagementScope mScope = new("\\\\localhost\\root\\default");
        ManagementPath mPath = new("SystemRestore");
        ObjectGetOptions options = new();

        using ManagementClass mClass = new(mScope, mPath, options);
        using ManagementBaseObject parameters = mClass.GetMethodParameters("CreateRestorePoint");
        parameters["Description"] = _description;
        parameters["EventType"] = (int)_eventType;
        parameters["RestorePointType"] = (int)_type;

        try
        {
            _ = mClass.InvokeMethod("CreateRestorePoint", parameters, null);
        }
        // HRESULT -2147023838 = 0x80070422 : system restore is disabled
        catch (COMException e) when (e.HResult == -2147023838)
        {
            throw new SystemProtectionDisabledException();
        }
    }

    #endregion Public Methods
}

public enum RestorePointType
{
    /// <summary>An application has been installed.</summary>
    ApplicationInstall = 0x0,

    /// <summary>An application has been uninstalled.</summary>
    ApplicationUninstall = 0x1,

    /// <summary>
    /// An application needs to delete the restore point it created. For example, an application would use this flag when a user
    /// cancels an installation.
    /// </summary>
    CancelledOperation = 0xd,

    /// <summary>A device driver has been installed.</summary>
    DeviceDriverInstall = 0xa,

    /// <summary>An application has had features added or removed.</summary>
    ModifySettings = 0xc
}
