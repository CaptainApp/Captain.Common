// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Captain.Common {
  /// <summary>
  ///   Class to provide assistance for separation of concern over contents of combo box where the displayed value does
  ///   not match the ToString() support.
  /// </summary>
  /// <remarks>
  ///   This utility class was borrowed from the following StackOverflow answer: https://stackoverflow.com/a/16432931/2541873
  /// </remarks>
  /// <typeparam name="T">The type of the value the combo box supports</typeparam>
  public class ComboBoxLoader<T> {
    /// <summary>
    /// The value to display in the combo box
    /// </summary>
    public string Display { get; set; }

    /// <summary>
    /// The actual object associated with the combo box item
    /// </summary>
    public T Value { get; set; }
  }
}