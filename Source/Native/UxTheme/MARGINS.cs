using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct MARGINS {
    /// <summary>
    ///   Width of the left border that retains its size.
    /// </summary>
    public int leftWidth;

    /// <summary>
    ///   Width of the right border that retains its size.
    /// </summary>
    public int rightWidth;

    /// <summary>
    ///   Height of the top border that retains its size.
    /// </summary>
    public int topWidth;

    /// <summary>
    ///   Height of the bottom border that retains its size.
    /// </summary>
    public int bottomWidth;
  }
}