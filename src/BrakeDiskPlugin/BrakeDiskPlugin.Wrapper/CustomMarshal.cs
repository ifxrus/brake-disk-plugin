using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

/// <summary>
/// Utility class for custom marshaling operations related to COM objects.
/// Provides methods to retrieve the CLSID from a ProgID and to get the active COM object.
/// </summary>
public static class CustomMarshal
{
    /// <summary>
    /// Constant representing the OLEAUT32.dll library.
    /// </summary>
    internal const string OLEAUT32 = "oleaut32.dll";

    /// <summary>
    /// Constant representing the OLE32.dll library.
    /// </summary>
    internal const string OLE32 = "ole32.dll";

    /// <summary>
    /// Retrieves the active COM object based on the specified ProgID.
    /// </summary>
    /// <param name="progID">The ProgID of the COM object.</param>
    /// <returns>The active COM object associated with the ProgID.</returns>
    [SecurityCritical] // auto-generated_required
    public static object GetActiveObject(string progID)
    {
        Guid clsid;

        // Call CLSIDFromProgIDEx first then fall back on CLSIDFromProgID if
        // CLSIDFromProgIDEx doesn't exist.
        try
        {
            CLSIDFromProgIDEx(progID, out clsid);
        }
        catch (Exception)
        {
            CLSIDFromProgID(progID, out clsid);
        }

        object obj;
        GetActiveObject(ref clsid, IntPtr.Zero, out obj);
        return obj;
    }

    /// <summary>
    /// Retrieves the CLSID from the specified ProgID using an extended version of the function.
    /// </summary>
    /// <param name="progId">The ProgID of the COM object.</param>
    /// <param name="clsid">The resulting CLSID associated with the ProgID.</param>
    [DllImport(OLE32, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void CLSIDFromProgIDEx(
        [MarshalAs(UnmanagedType.LPWStr)] string progId,
        out Guid clsid);

    /// <summary>
    /// Retrieves the CLSID from the specified ProgID.
    /// </summary>
    /// <param name="progId">The ProgID of the COM object.</param>
    /// <param name="clsid">The resulting CLSID associated with the ProgID.</param>
    [DllImport(OLE32, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void CLSIDFromProgID(
        [MarshalAs(UnmanagedType.LPWStr)] string progId,
        out Guid clsid);

    /// <summary>
    /// Retrieves the active COM object based on the specified CLSID.
    /// </summary>
    /// <param name="rclsid">The CLSID of the COM object.</param>
    /// <param name="reserved">Reserved parameter (set to IntPtr.Zero).</param>
    /// <param name="ppunk">The resulting active COM object.</param>
    [DllImport(OLEAUT32, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void GetActiveObject(
        ref Guid rclsid,
        IntPtr reserved,
        [MarshalAs(UnmanagedType.Interface)] out object ppunk);
}