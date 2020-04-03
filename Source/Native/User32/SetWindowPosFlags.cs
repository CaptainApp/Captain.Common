using System;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  public partial class User32 {
    [Flags]
    public enum SetWindowPosFlags {
      /// <summary>
      ///   Retains the current size (ignores the cx and cy parameters).
      /// </summary>
      SWP_NOSIZE = 0x0001,

      /// <summary>
      ///   Retains the current position (ignores X and Y parameters).
      /// </summary>
      SWP_NOMOVE = 0x0002,

      /// <summary>
      ///   Does not activate the window. If this flag is not set, the window is activated and moved to the top of
      ///   either the topmost or non-topmost group (depending on the setting of the hwndInsertAfter member).
      /// </summary>
      SWP_NOACTIVATE = 0x0010
    }
  }
}