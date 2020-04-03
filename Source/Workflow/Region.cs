namespace Captain.Common {
  /// <summary>
  ///   Represents the default region of a capture workflow
  /// </summary>
  public sealed class Region {
    /// <summary>
    ///   Workflow region type
    /// </summary>
    public RegionType Type = RegionType.Manual;

    /// <summary>
    ///   Region location
    /// </summary>
    public (int X, int Y) Location = (0, 0);

    /// <summary>
    ///   Region size
    /// </summary>
    public (int Width, int Height) Size = (0, 0);
  }
}