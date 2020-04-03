using System;
using System.IO;
using Aperture;

// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Captain.Common {
  /// <inheritdoc />
  /// <summary>
  ///   Performs tasks after encoding a capture and handles the result accordingly
  /// </summary>
  public abstract class Handler : IDisposable {
    /// <summary>
    ///   Workflow originating the capture
    /// </summary>
    protected WorkflowBase Workflow { get; }

    /// <summary>
    ///   Capture codec
    /// </summary>
    protected Codec Codec { get; }

    /// <summary>
    ///   Capture stream
    /// </summary>
    protected Stream Stream { get; }

    /// <summary>
    ///   User options for this handler
    /// </summary>
    protected object Options { get; }

    /// <summary>
    ///   Class constructor
    /// </summary>
    /// <remarks>
    ///   If the media is not supported, throw a <see cref="NotSupportedException"/> in the constructor
    /// </remarks>
    /// <param name="workflow">Workflow originating the capture</param>
    /// <param name="codec">Capture codec</param>
    /// <param name="stream">Capture stream</param>
    /// <param name="options">User-provided options for this handler</param>
    protected Handler(WorkflowBase workflow, Codec codec, Stream stream, object options = null) {
      Workflow = workflow;
      Codec = codec;
      Stream = stream;
      Options = options;
    }

    /// <summary>
    ///   Handles captures
    /// </summary>
    public abstract void Handle();

    /// <inheritdoc />
    /// <summary>
    ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources
    /// </summary>
    public void Dispose() { }
  }
}