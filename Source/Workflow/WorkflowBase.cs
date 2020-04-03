using System;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Captain.Common {
  /// <summary>
  ///   Workflows are the functional unit of the applicatiod and provide the user a great extent of flexibility when
  ///   performing and automating capture tasks
  /// </summary>
  [Serializable]
  public abstract class WorkflowBase {
    /// <summary>
    ///   Workflow type
    /// </summary>
    public WorkflowType Type { get; set; }

    /// <summary>
    ///   User-defined workflow name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   Array of handler type names and options
    /// </summary>
    public (string TypeName, object Options)[] Handlers { get; set; }

    /// <summary>
    ///   Array of transform type names and options
    /// </summary>
    public (string TypeName, object Options)[] Transforms { get; set; }

    /// <summary>
    ///   Codec type name and options
    /// </summary>
    public (string TypeName, object Options) Codec { get; set; }

    /// <summary>
    ///   Encoded hotkey associated to this workflow
    /// </summary>
    public ulong Hotkey { get; set; }

    /// <summary>
    ///   Whether the workflow will be displayed in the application menu
    /// </summary>
    public bool ShowInApplicationMenu { get; set; } = true;

    /// <summary>
    ///   Whether the hotkey will be translated to container-specific input events or not
    /// </summary>
    public bool CrossContainerHotkey { get; set; } = true;

    /// <summary>
    ///   Default capture region
    /// </summary>
    public Region Region { get; set; } = new Region();
  }
}