using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   The POINT structure defines the x- and y- coordinates of a point.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct POINT {
    /// <summary>
    ///   The x-coordinate of the point.
    /// </summary>
    public int x;

    /// <summary>
    ///   The x-coordinate of the point.
    /// </summary>
    public int y;
  }
}