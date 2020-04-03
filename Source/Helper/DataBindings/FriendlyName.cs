using System;

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Friendly name attribute for enum values
  /// </summary>
  public class FriendlyName : Attribute {
    /// <summary>
    ///   Friendly name
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///   Description for this value
    /// </summary>
    public string ExtendedDescription { get; }

    /// <inheritdoc />
    /// <summary>
    ///   Class constructor
    /// </summary>
    /// <param name="friendlyName">Friendly name</param>
    /// <param name="extendedDescription">Extended description</param>
    public FriendlyName(string friendlyName, string extendedDescription = null) {
      Name = friendlyName;
      ExtendedDescription = extendedDescription;
    }
  }
}