using System;
using System.IO;
using System.Reflection;

namespace Captain.Common {
  /// <summary>
  ///   Manages directories and files and ensures file system access is allowed
  /// </summary>
  public sealed class FsManager {
    /// <summary>
    ///   Add-in path
    /// </summary>
    public const string PluginPath = "Plugins";

    /// <summary>
    ///   Temporary path
    /// </summary>
    public const string TemporaryPath = "Temporary";

    /// <summary>
    ///   Logger path
    /// </summary>
    public const string LogsPath = "Logs";

    /// <summary>
    ///   Root application data directory
    /// </summary>
    private string RootDirectoryPath { get; }

    /// <summary>
    ///   Whether or not the application directory is usable and permanent.
    /// </summary>
    public bool IsFeatureAvailable { get; }

    /// <summary>
    ///   Instantiates a filesystem manager
    /// </summary>
    public FsManager() {
      RootDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                       Assembly.GetCallingAssembly().GetCustomAttribute<AssemblyProductAttribute>()
                                               .Product);

      try {
        Directory.CreateDirectory(RootDirectoryPath);
        IsFeatureAvailable = true;
      } catch {
        // can not bootstrap local application directory - use temporary path
        RootDirectoryPath = Path.GetTempPath();
      }
    }


    /// <summary>
    ///   Cleanups filesystem
    /// </summary>
    ~FsManager() {
      try {
        Directory.Delete(Path.Combine(RootDirectoryPath, TemporaryPath), true);
      } catch {
        // something went wrong
      }
    }

    /// <summary>
    ///   Returns a directory path that is almost-certainly guaranteed to be writable
    /// </summary>
    /// <remarks>If the user doesn't have write permissions to the temporary directory, this may fail</remarks>
    /// <param name="name">Relative path name</param>
    /// <returns>The full path to the directory</returns>
    public string GetSafePath(string name = "") {
      try {
        return Directory.CreateDirectory(Path.Combine(RootDirectoryPath, name)).FullName;
      } catch {
        // requested path could not be created
        return Path.GetTempPath();
      }
    }
  }
}