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
    internal const string OleAut32Library = "oleaut32.dll";

    /// <summary>
    /// Constant representing the OLE32.dll library.
    /// </summary>
    internal const string Ole32Library = "ole32.dll";

    /// <summary>
    /// Retrieves the active COM object based on the specified ProgID.
    /// </summary>
    /// <param name="programId">The ProgramID of the COM object.</param>
    /// <returns>The active COM object associated with the ProgramID.</returns>
    [SecurityCritical] // auto-generated_required
    public static object GetActiveObject(string programId)
    {
        Guid classId;

        // Call CLSIDFromProgIDEx first then fall back on CLSIDFromProgID if
        // CLSIDFromProgIDEx doesn't exist.
        try
        {
            CLSIDFromProgIDEx(programId, out classId);
        }
        catch (Exception)
        {
            CLSIDFromProgID(programId, out classId);
        }

        object comObject;
        GetActiveObject(ref classId, IntPtr.Zero, out comObject);
        return comObject;
    }

    /// <summary>
    /// Retrieves the CLSID from the specified ProgID using an extended version of the function.
    /// </summary>
    /// <param name="progId">The ProgID of the COM object.</param>
    /// <param name="classId">The resulting CLSID associated with the ProgID.</param>
    [DllImport(Ole32Library, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void CLSIDFromProgIDEx(
        [MarshalAs(UnmanagedType.LPWStr)] string progId,
        out Guid classId);

    /// <summary>
    /// Retrieves the CLSID from the specified ProgID.
    /// </summary>
    /// <param name="progId">The ProgID of the COM object.</param>
    /// <param name="classId">The resulting CLSID associated with the ProgID.</param>
    [DllImport(Ole32Library, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void CLSIDFromProgID(
        [MarshalAs(UnmanagedType.LPWStr)] string progId,
        out Guid classId);

    /// <summary>
    /// Retrieves the active COM object based on the specified CLSID.
    /// </summary>
    /// <param name="requestedClsid">The CLSID of the COM object.</param>
    /// <param name="reserved">Reserved parameter (set to IntPtr.Zero).</param>
    /// <param name="ppUnknown">The resulting active COM object.</param>
    [DllImport(OleAut32Library, PreserveSig = false)]
    [ResourceExposure(ResourceScope.None)]
    [SuppressUnmanagedCodeSecurity]
    [SecurityCritical] // auto-generated
    private static extern void GetActiveObject(
        ref Guid requestedClsid,
        IntPtr reserved,
        [MarshalAs(UnmanagedType.Interface)] out object ppUnknown);

}