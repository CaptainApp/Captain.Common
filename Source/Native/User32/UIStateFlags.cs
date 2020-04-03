
// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  public partial class User32 {
    /// <summary>
    ///   Represents UI state flags
    /// </summary>
    public enum UIStateFlags {
      /// <summary>
      ///   The UI state flags specified by the high-order word should be set.
      /// </summary>
      UIS_SET = 1,

      /// <summary>
      ///   Focus indicators are hidden.
      /// </summary>
      UISF_HIDEFOCUS = 1
    }
  }
}