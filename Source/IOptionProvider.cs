using System;

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Defines common logic for plugin option providers
  /// </summary>
  public interface IOptionProvider : IDisposable {
    /// <summary>
    ///   Displays the UI for configuring this plugin
    /// </summary>
    /// <param name="options">The current plugin options</param>
    /// <returns>The new options for this plugin</returns>
    object DisplayOptionUi(object options);
  }
}