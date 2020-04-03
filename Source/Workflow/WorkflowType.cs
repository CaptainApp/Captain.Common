namespace Captain.Common {
  /// <summary>
  ///   Defines workflow types
  /// </summary>
  public enum WorkflowType {
    /// <summary>
    ///   Still image capture
    /// </summary>
    [FriendlyName("WorkflowType_Still")]
    Still,

    /// <summary>
    ///   Motion capture
    /// </summary>
    [FriendlyName("WorkflowType_Motion")]
    Motion
  }
}