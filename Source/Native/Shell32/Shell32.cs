using System;
using System.Runtime.InteropServices;

namespace Captain.Common.Native {
  /// <summary>
  ///   Exported functions from the shell32.dll Windows library.
  /// </summary>
  public static class Shell32 {
    /// <summary>
    ///   Translates a Shell namespace objeect's display name into an item identifier list and returns the attributes
    ///   of the object. This function is the preferred method to convert a string to a pointer to an item identifier
    ///   list (PIDL)
    /// </summary>
    /// <param name="pszName">A pointer to a zero-terminated wide sring that contains the display name to parse.</param>
    /// <param name="pbc">A bind context that controls the parsing operation.</param>
    /// <param name="ppidl">
    ///   The address of a pointer to a variable of type <c>ITEMIDLIST</c> that receives the item identifier list for
    ///   the object. If an error occurs, then this parameter is set to <c>null</c>.
    /// </param>
    /// <param name="sfgaoIn">An <see cref="UInt64" /> value that specifies the attributes to query.</param>
    /// <param name="psfgaoOut">
    ///   A pointer to an <see cref="UInt64" />. On return, those attributes that are true for the object and were
    ///   requested in <paramref name="sfgaoIn" /> are set.
    /// </param>
    /// <returns>
    ///   If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
    /// </returns>
    [DllImport(nameof(Shell32))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int SHParseDisplayName(
      [In] [MarshalAs(UnmanagedType.LPWStr)] string pszName,
      [In] [Optional] IntPtr pbc,
      [Out] out IntPtr ppidl,
      [In] uint sfgaoIn,
      [Out] out uint psfgaoOut);

    /// <summary>
    ///   Opens a Windows Explorer window with specified items in a particular folder selected.
    /// </summary>
    /// <param name="pidlFolder">A pointer to a fully qualified item ID list that specifies the folder</param>
    /// <param name="cidl">A count of items in the selection array, <paramref name="apidl" />.</param>
    /// <param name="apidl">
    ///   A pointer to an array of PIDL structures, each of which is an item to select in the target folder referenced
    ///   by <paramref name="pidlFolder" />.
    /// </param>
    /// <param name="dwFlags">The optional flags.</param>
    /// <returns>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport(nameof(Shell32))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int SHOpenFolderAndSelectItems(
      [In] IntPtr pidlFolder,
      [In] uint cidl,
      [In] [Optional] [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl,
      [In] int dwFlags);
  }
}