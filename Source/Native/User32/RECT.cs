﻿using System.Drawing;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
  /// </summary>
  /// <remarks>
  ///   By convention, the right and bottom edges of the rectangle are normally considered exclusive.
  ///   In other words, the pixel whose coordinates are ( right, bottom ) lies immediately outside of the rectangle.
  ///   For example, when RECT is passed to the FillRect function, the rectangle is filled up to, but not including,
  ///   the right column and bottom row of pixels. This structure is identical to the RECTL structure.
  /// </remarks>
  [StructLayout(LayoutKind.Sequential)]
  public struct RECT {
    /// <summary>
    ///   The x-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public int left;

    /// <summary>
    ///   The y-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public int top;

    /// <summary>
    ///   The x-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    public int right;

    /// <summary>
    ///   The y-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    public int bottom;

    /// <summary>
    ///   Converts a native <see cref="RECT" /> structure to a Framework <see cref="Rectangle" /> type
    /// </summary>
    /// <returns></returns>
    public Rectangle ToRectangle() =>
      Rectangle.FromLTRB(this.left, this.top, this.right, this.bottom);
  }
}