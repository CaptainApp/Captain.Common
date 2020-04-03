using System.IO;

namespace Captain.Common {
  /// <summary>
  ///   <see cref="Handler" />s inheriting from this interface can stream codec output directly
  /// </summary>
  public interface IStreamWrapper {
    /// <summary>
    ///   Wrapped stream
    /// </summary>
    /// <remarks>
    ///   Captain will write to this stream as the encoder yields output.
    ///   Keep in mind that some codecs may require seeking through the stream to properly work
    ///   (i.e. many popular video codecs which need to set video metadata at the beginning of the stream). So this
    ///   may not be quite suitable for usages such as network streaming of encoder output in many cases
    /// </remarks>
    Stream OutputStream { get; }
  }
}