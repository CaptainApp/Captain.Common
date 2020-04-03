using System;
using System.Drawing;

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Specifies a custom icon for this object
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public sealed class DisplayIcon : Attribute {
    /// <summary>
    ///   Type of the Resources class in the assembly
    /// </summary>
    private Type ResourcesType { get; }

    /// <summary>
    ///   Resource name
    /// </summary>
    private string ResourceName { get; }

    /// <summary>
    ///   Retrieves the actual icon from the assembly resources
    /// </summary>
    public Icon Icon =>
      new Icon(ResourcesType.Assembly.GetManifestResourceStream(ResourcesType.FullName + '.' + ResourceName + ".ico") ??
               throw new InvalidOperationException());

    /// <inheritdoc />
    /// <summary>
    ///   Sets a display icon for this object
    /// </summary>
    /// <param name="resourcesType">Type of the Resources class</param>
    /// <param name="resourceName">Name of the icon resource</param>
    public DisplayIcon(Type resourcesType, string resourceName) =>
      (ResourcesType, ResourceName) = (resourcesType, resourceName);
  }
}