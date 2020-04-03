using System;

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Wraps event arguments with extended data in a single <see cref="T:System.EventArgs" /> instance
  /// </summary>
  /// <typeparam name="TA">Underlying <see cref="T:System.EventArgs" /> type</typeparam>
  /// <typeparam name="TE">Type of the extended data</typeparam>
  public class ExtendedEventArgs<TA, TE> : EventArgs where TA : EventArgs {
    /// <summary>
    ///   Underlying event arguments
    /// </summary>
    public TA EventArgs { get; }

    /// <summary>
    ///   Extended data for this event
    /// </summary>
    public TE ExtendedData { get; set; }

    /// <inheritdoc />
    /// <summary>
    ///   Class constructor
    /// </summary>
    /// <param name="eventArgs">Underlying event arguments</param>
    /// <param name="extendedData">Extended data</param>
    public ExtendedEventArgs(TA eventArgs, TE extendedData = default) =>
      (EventArgs, ExtendedData) = (eventArgs, extendedData);
  }
}