using System;

namespace Captain.Common {
  /// <summary>
  ///   Defines levels for log messages, in ascendant order of precedence
  /// </summary>
  public enum LogLevel : ushort {
    /// <summary>
    ///   Error message
    /// </summary>
    Error = 0,

    /// <summary>
    ///   Warning message
    /// </summary>
    Warn = 1,

    /// <summary>
    ///   Informational message
    /// </summary>
    Info = 2,
    
    /// <summary>
    ///   Message only shown when DEBUG is defined
    /// </summary>
    Debug = 3,
    
    /// <summary>
    ///   Verbose message
    /// </summary>
    Trace = 4
  }

  /// <summary>
  ///   Provides extension methods to the LogLevel struct
  /// </summary>
  public static class LogLevelExtensions {
    /// <summary>
    ///   Get the <see cref="ConsoleColor" /> associated to a particular log level
    /// </summary>
    /// <param name="level">This log level</param>
    /// <returns>
    ///   The <see cref="ConsoleColor" /> associated to this log level or <c>ConsoleColor.Gray</c> if no such level is
    ///   implemented
    /// </returns>
    public static ConsoleColor GetAssociatedConsoleColor(this LogLevel level) {
      switch (level) {
        case LogLevel.Error: return ConsoleColor.Red;
        case LogLevel.Warn: return ConsoleColor.Yellow;
        case LogLevel.Info: return ConsoleColor.Blue;
        case LogLevel.Debug: return ConsoleColor.Cyan;
        case LogLevel.Trace: return ConsoleColor.White;
      }

      return ConsoleColor.Gray;
    }
  }
}