using System;

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Specifies a configuration provider for this object
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public sealed class OptionProvider : Attribute {
    /// <summary>
    ///   Option provider type
    /// </summary>
    public Type Type { get; }

    /// <inheritdoc />
    /// <summary>
    ///   Associates an option provider to a plugin type
    /// </summary>
    /// <param name="type">Option provider type</param>
    public OptionProvider(Type type) {
      if (!type.IsClass) {
        throw new ArgumentException("The option provider type must be a class", nameof(type));
      }

      if (type.GetInterface(typeof(IOptionProvider).FullName) is null) {
        throw new ArgumentException("The option provider must implement the IOptionProvider interface", nameof(type));
      }

      Type = type;
    }
  }
}