using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   Exported functions from the kernel32.dll Windows library.
  /// </summary>
  public static class Kernel32 {
    #region Timing

    /// <summary>
    ///   Retrieves the frequency of the performance counter
    /// </summary>
    /// <param name="lpFrequency">
    ///   A pointer to a variable that receives the current performance-counter frequency.
    /// </param>
    /// <returns>
    ///   If the installed hardware supports a high-resolution performance counter, the return value is nonzero.
    /// </returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool QueryPerformanceFrequency(out long lpFrequency);

    #endregion

    #region Misc.

    /// <summary>
    ///   Closes an open object handle.
    /// </summary>
    /// <param name="hObject">A valid handle to an open object.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool CloseHandle([In] IntPtr hObject);

    #endregion

    #region Process utilities

    /// <summary>
    ///   Process access flags for the <see cref="OpenProcess" /> function.
    /// </summary>
    [Flags]
    public enum ProcessAccessRights {
      /// <summary>
      ///   Required to create a thread.
      /// </summary>
      PROCESS_CREATE_THREAD = 0x0002,

      /// <summary>
      ///   Required to perform an operation on the address space of a process.
      /// </summary>
      PROCESS_VM_OPERATION = 0x0008,

      /// <summary>
      ///   Required to read memory in a process using ReadProcessMemory.
      /// </summary>
      PROCESS_VM_READ = 0x0010,

      /// <summary>
      ///   Required to write to memory in a process using <see cref="WriteProcessMemory" />.
      /// </summary>
      PROCESS_VM_WRITE = 0x0020,

      /// <summary>
      ///   Required to retrieve certain information about a process, such as its token, exit code, and priority class.
      /// </summary>
      PROCESS_QUERY_INFORMATION = 0x0400
    }

    /// <summary>
    ///   Opens an existing local process object.
    /// </summary>
    /// <param name="dwDesiredAccess">The access to the process object.</param>
    /// <param name="bInheritHandle">
    ///   If this value is TRUE, processes created by this process will inherit the handle.
    /// </param>
    /// <param name="dwProcessId">The identifier of the local process to be opened.</param>
    /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern IntPtr OpenProcess(
      [In] ProcessAccessRights dwDesiredAccess,
      [In] bool bInheritHandle,
      [In] int dwProcessId);

    /// <summary>
    ///   Determines whether the specified process is running under WOW64.
    /// </summary>
    /// <param name="hProcess">A handle to the process.</param>
    /// <param name="pbWow64Process">
    ///   A pointer to a value that is set to TRUE if the process is running uner WOW64.
    /// </param>
    /// <returns>If the function succeeds, the return value is a nonzero value.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool IsWow64Process(
      [In] IntPtr hProcess,
      [Out] out bool pbWow64Process);

    #endregion

    #region Memory allocation

    /// <summary>
    ///   Memory allocation flags.
    /// </summary>
    [Flags]
    public enum AllocationType {
      /// <summary>
      ///   Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified
      ///   reserved memory pages.
      /// </summary>
      MEM_COMMIT = 0x00001000
    }

    /// <summary>
    ///   Memory freeing flags.
    /// </summary>
    [Flags]
    public enum FreeType {
      /// <summary>
      ///   Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
      /// </summary>
      MEM_DECOMMIT = 0x4000
    }

    /// <summary>
    ///   The following are the memory-protection options; you must specify one of the following values when allocating
    ///   or protecting a page in memory.
    /// </summary>
    [Flags]
    public enum MemoryProtectionFlags {
      /// <summary>
      ///   Enables read-only or read/write access to the committed region of pages.
      /// </summary>
      PAGE_READWRITE = 0x04
    }

    /// <summary>
    ///   Reserves, commits, or changes the state of a region of memory within the virtual address space of a specified
    ///   process.
    /// </summary>
    /// <param name="hProcess">The hanle to a process.</param>
    /// <param name="lpAddress">
    ///   The pointer that specifies a desired starting address for the region of pages that you want to allocate.
    /// </param>
    /// <param name="dwSize">The size of the region of memory to allocate, in bytes.</param>
    /// <param name="flAllocationType">The type of memory allocation.</param>
    /// <param name="flProtect">The memory protection for the region of pages to be allocated.</param>
    /// <returns>
    ///   If the function succeeds, the return value is the base address of the allocated region of pages.
    /// </returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern IntPtr VirtualAllocEx(
      [In] IntPtr hProcess,
      [In] [Optional] IntPtr lpAddress,
      [In] int dwSize,
      [In] AllocationType flAllocationType,
      [In] MemoryProtectionFlags flProtect);

    /// <summary>
    ///   Writes data to an area of memory in a specified process. The entire area to be written to must be accessible
    ///   or the operation fails.
    /// </summary>
    /// <param name="hProcess">
    ///   A handle to the process memory to be modified.
    ///   The handle must have PROCESS_VM_WRITE and PROCESS_VM_OPERATION access to the process.
    /// </param>
    /// <param name="lpBaseAddress">
    ///   A pointer to the base address in the specified process to which data is written.
    /// </param>
    /// <param name="lpBuffer">
    ///   A pointer to the buffer that contains data to be written in the address space of the specified process.
    /// </param>
    /// <param name="nSize">The number of bytes to be written to the specified process.</param>
    /// <param name="lpNumberOfBytesWritten">
    ///   A pointer to a variable that receives the number of bytes transferred into the specified process.
    /// </param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool WriteProcessMemory(
      [In] IntPtr hProcess,
      [In] IntPtr lpBaseAddress,
      [In] IntPtr lpBuffer,
      [In] int nSize,
      [Out] out int lpNumberOfBytesWritten);

    /// <summary>
    ///   Releases, decommits, or releases and decommits a region of memory within the virtual address space of a
    ///   specified process.
    /// </summary>
    /// <param name="hProcess">A handle to a process.</param>
    /// <param name="lpAddress">A pointer to the starting address of the region of memory to be freed.</param>
    /// <param name="dwSize">The size of the region of memory to free, in bytes. </param>
    /// <param name="dwFreeType">The type of free operation.</param>
    /// <returns>If the function succeeds, the return value is a nonzero value.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool VirtualFreeEx(
      [In] IntPtr hProcess,
      [In] IntPtr lpAddress,
      [In] int dwSize,
      [In] FreeType dwFreeType);

    #endregion

    #region Modules

    /// <summary>
    ///   Loads the specified module into the address space of the calling process. The specified module may case other
    ///   modules to be loaded.
    /// </summary>
    /// <param name="lpFileName">The name of the module.</param>
    /// <returns>If the function succeeds, the return value is a handle to the module.</returns>
    [DllImport(nameof(Kernel32), EntryPoint = "LoadLibraryW", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr LoadLibrary([In] string lpFileName);

    /// <summary>
    ///   Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.
    /// </summary>
    /// <param name="hLibModule">A handle to the loaded library module.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool FreeLibrary([In] IntPtr hLibModule);

    /// <summary>
    ///   Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
    /// </summary>
    /// <param name="hModule">A handle to the DLL module that contains the function or variable.</param>
    /// <param name="lpProcName">The function or variable name, or the function's ordinal value.</param>
    /// <returns>
    ///   If the function succeeds, the return value is the address of the exported function or variable.
    /// </returns>
    [DllImport(nameof(Kernel32), CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern IntPtr GetProcAddress([In] IntPtr hModule, [In] string lpProcName);

    #endregion

    #region Threading

    /// <summary>
    ///   Infinite timeout.
    /// </summary>
    public const uint Infinite = 0xFFFFFFFF;

    /// <summary>
    ///   Creates a thread that runs in the virtual address space of another process.
    /// </summary>
    /// <param name="hProcess">
    ///   A handle to the process in which the thread is to be created. The handle must have the PROCESS_CREATE_THREAD,
    ///   PROCESS_QUERY_INFORMATION, PROCESS_VM_OPERATION, PROCESS_VM_WRITE, and PROCESS_VM_READ access rights, and may
    ///   fail without these rights on certain platforms.
    /// </param>
    /// <param name="lpThreadAttributes">
    ///   A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread and
    ///   determines whether child processes can inherit the returned handle.
    /// </param>
    /// <param name="dwStackSize">The initial size of the stack, in bytes.</param>
    /// <param name="lpStartAddress">
    ///   A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread and
    ///   represents the starting address of the thread in the remote process.
    /// </param>
    /// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
    /// <param name="dwCreationFlags">The flags that control the creation of the thread.</param>
    /// <param name="lpThreadId">A pointer to a variable that receives the thread identifier. </param>
    /// <returns>If the function succeeds, the return value is a handle to the new thread.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern IntPtr CreateRemoteThread(
      [In] IntPtr hProcess,
      [In] [Optional] IntPtr lpThreadAttributes,
      [In] int dwStackSize,
      [In] IntPtr lpStartAddress,
      [In] [Optional] IntPtr lpParameter,
      [In] int dwCreationFlags,
      [Out] out int lpThreadId);

    /// <summary>
    ///   Waits until the specified object is in the signaled state or the time-out interval elapses.
    /// </summary>
    /// <param name="hHandle">A handle to the object.</param>
    /// <param name="dwMilliseconds">The timeout interval, in milliseconds.</param>
    /// <returns></returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern int WaitForSingleObject(
      [In] IntPtr hHandle,
      [In] int dwMilliseconds);

    /// <summary>
    ///   Retrieves the termination status of the specified thread.
    /// </summary>
    /// <param name="hThread">A handle to the thread.</param>
    /// <param name="lpExitCode">A pointer to a variable to receive the thread termination status.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(Kernel32), SetLastError = true)]
    public static extern bool GetExitCodeThread([In] IntPtr hThread, [Out] out int lpExitCode);

    #endregion
  }
}