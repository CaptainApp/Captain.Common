using System;

namespace Captain.Common {
  /// <summary>
  ///   Implemented by file handlers that can provide a URI for the handled capture
  /// </summary>
  public interface IUriProvider {
    /// <summary>
    ///   Gets and Uniform Resource Identifier (URI) for the handled capture
    /// </summary>
    /// <returns>An URI representing the captured object</returns>
    Uri GetUri();
  }
}
