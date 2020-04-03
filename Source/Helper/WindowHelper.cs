using System;
using System.Runtime.InteropServices;
using Captain.Common.Native;

namespace Captain.Common {
  /// <summary>
  ///   Implements diverse utilities for working with windows
  /// </summary>
  public static class WindowHelper {
    /// <summary>
    ///   Retrieves the specified window's bounds, including the window frame
    /// </summary>
    /// <param name="handle">Window handle</param>
    /// <returns>A <see cref="RECT" /> structure containing the window bounds</returns>
    public static RECT GetWindowBounds(IntPtr handle) {
      // try to use DWM to retrieve the extended window frame bounds - fall back to GetWindowRect on failure
      if (DwmApi.DwmGetWindowAttribute(handle,
            DwmApi.DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS,
            out RECT rect,
            Marshal.SizeOf(typeof(RECT))) !=
          0) { User32.GetWindowRect(handle, out rect); }
      return rect;
    }
  }
}