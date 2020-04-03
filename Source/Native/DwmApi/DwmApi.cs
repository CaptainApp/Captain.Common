using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   Exported functions from the dwmapi.dll Windows library.
  /// </summary>
  public static partial class DwmApi {
    /// <summary>
    ///   Retrieves the current value of a specified attribute applied to a window.
    /// </summary>
    /// <param name="hwnd">The handle to the window from which the attribute data is retrieved.</param>
    /// <param name="dwAttribute">
    ///   The attribute to retrieve, specified as a <see cref="DwmWindowAttribute" /> value.
    /// </param>
    /// <param name="pvAttribute">
    ///   A pointer to a value that, when this function returns successfully, receives the current value of the
    ///   attribute. The type of the retrieved value depends on the value of the <c>dwAttribute</c> parameter.
    /// </param>
    /// <param name="cbAttribute">
    ///   The size of the <see cref="DwmWindowAttribute" /> value being retrieved. The size is dependent on the type of
    ///   the <c>pvAttribute</c> parameter.
    /// </param>
    /// <returns>
    ///   If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
    /// </returns>
    [DllImport(nameof(DwmApi))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int DwmGetWindowAttribute(
      [In] IntPtr hwnd,
      [In] DwmWindowAttribute dwAttribute,
      [Out] out RECT pvAttribute,
      [In] int cbAttribute);

    /// <summary>
    ///   Sets the value of non-client rendering attributes for a window.
    /// </summary>
    /// <param name="hwnd">The handle to the window that will receive the attributes.</param>
    /// <param name="dwAttribute">
    ///   A single <see cref="DwmWindowAttribute" /> flag to apply to the window
    /// </param>
    /// <param name="pvAttribute">
    ///   A pointer to the value of the attribute specified in the <paramref name="dwAttribute" />
    ///   parameter. Different <see cref="DwmWindowAttribute" /> flags require different value types.
    /// </param>
    /// <param name="cbAttribute">
    ///   The size, in bytes, of the value type pointed to by the <paramref name="pvAttribute" /> parameter.
    /// </param>
    /// <returns>
    ///   If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
    /// </returns>
    [DllImport(nameof(DwmApi))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int DwmSetWindowAttribute(
      [In] IntPtr hwnd,
      [In] DwmWindowAttribute dwAttribute,
      [In] [Out] ref IntPtr pvAttribute,
      [In] int cbAttribute);

    /// <summary>
    ///   Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled.
    /// </summary>
    /// <param name="pfEnabed">
    ///   A pointer to a value that, when this function returns successfully, receives TRUE if DWM composition is
    ///   enabled; otherwise, FALSE.
    /// </param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport(nameof(DwmApi))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int DwmIsCompositionEnabled([Out] out bool pfEnabed);

    /// <summary>
    ///   Undocumented function. Retrieves colorization parameters for the current theme.
    /// </summary>
    /// <param name="dp">Destination colorization parameters struct.</param>
    [DllImport(nameof(DwmApi), EntryPoint = "#127")]
    public static extern void DwmGetColorizationParameters([In] [Out] ref DWMCOLORIZATIONPARAMS dp);

    /// <summary>
    ///   Extends the window frame into the client area.
    /// </summary>
    /// <param name="hWnd">The handle to the window in which the frame will be extended into the client area.</param>
    /// <param name="pMarInset">
    ///   A pointer to a <see cref="MARGINS" /> structure that describes the margins to use when extending the frame
    ///   into the client area.
    /// </param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    /// <remarks>
    ///   This function must be called whenever Desktop Window Manager (DWM) composition is toggled.
    ///   Handle the WM_DWMCOMPOSITIONCHANGED message for composition change notification.
    /// </remarks>
    [DllImport(nameof(DwmApi))]
    [return: MarshalAs(UnmanagedType.Error)]
    public static extern int DwmExtendFrameIntoClientArea([In] IntPtr hWnd, [In] [Out] ref MARGINS pMarInset);
  }
}