using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   Contains information about a low-level mouse input event.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct MSLLHOOKSTRUCT {
    /// <summary>
    ///   The x- and y-coordinates of the cursor, in per-monitor-aware screen coordinates.
    /// </summary>
    public POINT pt;

    /// <summary>
    ///   Event-dependent mouse data.
    /// </summary>
    private readonly int mouseData;

    /// <summary>
    ///   The event-injected flags.
    /// </summary>
    private readonly int flags;

    /// <summary>
    ///   The time stamp for this message.
    /// </summary>
    private readonly int time;

    /// <summary>
    ///   Additional information associated with the message.
    /// </summary>
    private readonly UIntPtr dwExtraInfo;
  }
}