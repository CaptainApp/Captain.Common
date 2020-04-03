// ReSharper disable All

namespace Captain.Common.Native {
  public static partial class DwmApi {
    /// <summary>
    ///   Flags used by the <see cref="DwmSetWindowAttribute" /> function to specify the non-client area rendering policy.
    /// </summary>
    public enum DwmNcRenderingPolicy {
      /// <summary>
      ///   The non-client area rendering is disabled; the window style is ignored.
      /// </summary>
      DWMNCRP_DISABLED = 2
    }
  }
}