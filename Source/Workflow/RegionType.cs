namespace Captain.Common {
  /// <summary>
  ///   Contains different region types for workflows
  /// </summary>
  public enum RegionType {
    /// <summary>
    ///   Let the user manually select the region from the screen
    /// </summary>
    [FriendlyName("RegionType_Manual")]
    Manual,

    /// <summary>
    ///   Let the user fix a constant region to capture each time
    /// </summary>
    [FriendlyName("RegionType_Fixed")]
    Fixed,

    /// <summary>
    ///   Capture the active window
    /// </summary>
    [FriendlyName("RegionType_ActiveWindow")]
    ActiveWindow,

    /// <summary>
    ///   Capture the active monitor
    /// </summary>
    [FriendlyName("RegionType_ActiveMonitor")]
    ActiveMonitor,

    /// <summary>
    ///   Capture the entire virtual desktop
    /// </summary>
    [FriendlyName("RegionType_FullDesktop")]
    FullDesktop
  }
}