// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  public partial class User32 {
    /// <summary>
    ///   Return values for WM_NCHITTEST window messages.
    /// </summary>
    public enum HitTestValues {
      /// <summary>
      ///   In a title bar
      /// </summary>
      HTCAPTION = 2,

      /// <summary>
      ///   In the left border of a resizable window
      /// </summary>
      HTLEFT = 10,

      /// <summary>
      ///   In the right border of a resizable window
      /// </summary>
      HTRIGHT = 11,

      /// <summary>
      ///   In the top border of a resizable window
      /// </summary>
      HTTOP = 12,

      /// <summary>
      ///   In the upper-left corner of a border of a resizable window
      /// </summary>
      HTTOPLEFT = 13,

      /// <summary>
      ///   In the upper-resizable corner of a border of a resizable window
      /// </summary>
      HTTOPRIGHT = 14,

      /// <summary>
      ///   In the bottom border of a resizable window
      /// </summary>
      HTBOTTOM = 15,

      /// <summary>
      ///   In the lower-left corner of a border of a resizable window
      /// </summary>
      HTBOTTOMLEFT = 16,

      /// <summary>
      ///   In the lower-right corner of a border of a resizable window
      /// </summary>
      HTBOTTOMRIGHT = 17
    }
  }
}