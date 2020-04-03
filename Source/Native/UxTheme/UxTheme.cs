using System;
using System.Runtime.InteropServices;

namespace Captain.Common.Native {
  /// <summary>
  ///   Exported functions from the uxtheme.dll Windows library.
  /// </summary>
  public static class UxTheme {
    /// <summary>
    ///   Causes a window to use a different set of visual style information than its class normally uses.
    /// </summary>
    /// <param name="hwnd">Handle to the window whose visual style information is to be changed.</param>
    /// <param name="pszSubAppName">
    ///   Pointer to a string that contains the application name to use in place of the calling application's name. If
    ///   this parameter is NULL, the calling application's name is used.
    /// </param>
    /// <param name="pszSubAppId">
    ///   Pointer to a string that contains a semicolon-separated list of CLSID names to use in place of the actual
    ///   list passed by the window's class. If this parameter is NULL, the ID list from the calling class is used.
    /// </param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport(nameof(UxTheme), CharSet = CharSet.Unicode)]
    public static extern int SetWindowTheme([In] IntPtr hwnd, [In] string pszSubAppName, [In] string pszSubAppId);
  }
}