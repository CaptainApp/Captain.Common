// ReSharper disable All

namespace Captain.Common.Native {
  public static partial class DwmApi {
    /// <summary>
    ///   Flags used by the DwmGetWindowAttribute and DwmSetWindowAttribute functions to specify window attributes for
    ///   non-client rendering.
    /// </summary>
    public enum DwmWindowAttribute {
      /// <summary>
      ///   Use with <see cref="DwmSetWindowAttribute" />. Sets the non-client rendering policy. The
      ///   <c>pvAttribute</c> parameter points to a value from the DWMNCRENDERINGPOLICY enumeration.
      /// </summary>
      DWMWA_NCRENDERING_POLICY = 2,

      /// <summary>
      ///   Use with <see cref="DwmGetWindowAttribute" />. Retrieves the extended frame bounds rectangle in screen
      ///   space. The retrieved value is of type <see cref="RECT" />.
      /// </summary>
      DWMWA_EXTENDED_FRAME_BOUNDS = 9
    }
  }
}