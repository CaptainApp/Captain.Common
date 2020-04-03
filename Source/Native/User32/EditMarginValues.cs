using System;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  public partial class User32 {
    /// <summary>
    ///   Flags for the EM_SETMARGINS window message
    /// </summary>
    [Flags]
    public enum EditMarginValues {
      /// <summary>
      ///   Sets the right margin.
      /// </summary>
      EC_RIGHTMARGIN = 0x2
    }
  }
}