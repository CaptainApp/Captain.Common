using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  /// <summary>
  ///   Exported functions from the user32.dll Windows library.
  /// </summary>
  public static partial class User32 {
    #region Windows

    #region Window styles

    [Flags]
    public enum ClassStyles {
      /// <summary>
      ///   Enables the drop shadow effect on a window
      /// </summary>
      CS_DROPSHADOW = 0x20000
    }

    [Flags]
    public enum WindowStylesEx : uint {
      /// <summary>
      ///   The window should not be painted until siblings beneath the window (that were created by the same thread)
      ///   have been painted.
      /// </summary>
      WS_EX_TRANSPARENT = 0x00000020,

      /// <summary>
      ///   The window is intended to be used as a floating toolbar.
      /// </summary>
      WS_EX_TOOLWINDOW = 0x00000080,

      /// <summary>
      ///   Paints via double-buffering, which reduces flicker. This extended style also enables alpha-blended marquee
      ///   selection on systems where it is supported.
      /// </summary>
      LVS_EX_DOUBLEBUFFER = 0x00010000,

      /// <summary>
      ///   This window is a layered window.
      /// </summary>
      WS_EX_LAYERED = 0x00080000,

      /// <summary>
      ///   Paints all descendants of a window in bottom-to-top painting order using double-buffering.
      /// </summary>
      WS_EX_COMPOSITED = 0x02000000,

      /// <summary>
      ///   A  top-level window created with this style does not become the foreground window when the user clicks it.
      /// </summary>
      WS_EX_NOACTIVATE = 0x08000000
    }

    #endregion

    #region Window procedures/messages

    /// <summary>
    ///   Sends the specified message to a window or windows. The SendMessage function calls the window procedure for
    ///   the specified window and does not return until the window procedure has processed the message.
    ///   To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post
    ///   a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage
    ///   function.
    /// </summary>
    /// <param name="hWnd">
    ///   A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST
    ///   ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible
    ///   unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
    ///   Message sending is subject to UIPI. The thread of a process can send messages only to message queues of
    ///   threads in processes of lesser or equal integrity level.
    /// </param>
    /// <param name="uiMsg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>
    ///   The return value specifies the result of the message processing; it depends on the message sent.
    /// </returns>
    [DllImport(nameof(User32), SetLastError = true)]
    public static extern IntPtr SendMessage(
      [In] IntPtr hWnd,
      [In] uint uiMsg,
      [In] IntPtr wParam,
      [In] IntPtr lParam);

    #region CallWindowProc

    #endregion

    #endregion

    #region GetWindowLong(Ptr)/SetWindowLong(Ptr)

    public enum WindowLongParam {
      /// <summary>Sets a new extended window style.</summary>
      GWL_EXSTYLE = -20
    }

    /// <summary>
    ///   Retrieves information about the specified window. The function also retrieves the value at a specified offset
    ///   into the extra window memory.
    /// </summary>
    /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
    /// <param name="nIndex">
    ///   The zero-based offset to the value to be retrieved. Valid values are in the range zero
    ///   through the number of bytes of extra window memory, minus the size of a LONG_PTR. To retrieve any other value,
    ///   specify one of the following values.
    /// </param>
    /// <returns>If the function succeeds, the return value is the requested value.</returns>
#if WIN32
    [DllImport(nameof(User32), EntryPoint = "GetWindowLong")]
    public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex);
#elif WIN64
    [DllImport(nameof(User32), EntryPoint = "GetWindowLongPtr")]
    public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex);
#endif

    /// <summary>
    ///   Changes an attribute of the specified window. The function also sets a value at the specified offset in the
    ///   extra window memory.
    /// </summary>
    /// <param name="hWnd">
    ///   A handle to the window and, indirectly, the class to which the window belongs.
    ///   The SetWindowLongPtr function fails if the process that owns the window specified by the hWnd parameter is
    ///   at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.
    /// </param>
    /// <param name="nIndex">
    ///   The zero-based offset to the value to be set. Valid values are in the range zero through
    ///   the number of bytes of extra window memory, minus the size of a LONG_PTR.
    /// </param>
    /// <param name="dwNewLong">The replacement value.</param>
    /// <returns>If the function succeeds, the return value is the previous value of the specified offset.</returns>
#if WIN32
    [DllImport(nameof(User32), EntryPoint = "SetWindowLong")]
    public static extern int SetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex, IntPtr dwNewLong);
#elif WIN64
    [DllImport(nameof(User32))]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex, IntPtr dwNewLong);
#endif

    #endregion

    [DllImport(nameof(User32), SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    /// <summary>
    ///   Retrieves a handle to the window that contains the specified point.
    /// </summary>
    /// <param name="Point">The point to be checked.</param>
    /// <returns>
    ///   The return value is a handle to the window that contains the point. If no window exists at the given point,
    ///   the return value is <see cref="IntPtr.Zero" />. If the point is over a static text control, the return value
    ///   is a handle to the window under the static text control.
    /// </returns>
    [DllImport(nameof(User32))]
    public static extern IntPtr WindowFromPoint(POINT Point);

    /// <summary>
    ///   Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is
    ///   the area on top of which other windows are painted.
    /// </summary>
    /// <returns>The return value is a handle to the desktop window.</returns>
    [DllImport(nameof(User32))]
    public static extern IntPtr GetDesktopWindow();

    /// <summary>
    ///   Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to
    ///   deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, flushe
    ///   the thread message queue, destroys timers, removes clipboard ownership, and breaks the clipboard viewer chain
    ///   (if the window is at the top of the viewer chain).
    /// </summary>
    /// <param name="hWnd">A handle to the window to be destroyed.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(User32))]
    public static extern bool DestroyWindow([In] IntPtr hWnd);
    
    #region Drawing contexts

    /// <summary>
    ///   The GetWindowDC function retrieves the device context (DC) for the entire window, including title bar,
    ///   menus, and scroll bars. A window device context permits painting anywhere in a window, because the origin
    ///   of the device context is the upper-left corner of the window instead of the client area. GetWindowDC
    ///   assigns default attributes to the window device context each time it retrieves the device context. Previous
    ///   attributes are lost.
    /// </summary>
    /// <param name="hWnd">
    ///   A handle to the window with a device context that is to be retrieved. If this value is
    ///   <see cref="IntPtr.Zero"/>, GetWindowDC retrieves the device context for the entire screen.
    ///   If this parameter is <see cref="IntPtr.Zero"/>, GetWindowDC retrieves the device context for the primary
    ///   display monitor.
    /// </param>
    /// <returns>
    ///   If the function succeeds, the return value is a handle to a device context for the specified window.
    ///   If the function fails, the return value is <see cref="IntPtr.Zero"/>, indicating an error or an invalid hWnd
    ///   parameter.
    /// </returns>
    [DllImport(nameof(User32), SetLastError = true)]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    /// <summary>
    ///   The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect
    ///   of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect
    ///   on class or private DCs.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
    /// <param name="hDC">A handle to the DC to be released.</param>
    /// <returns>
    ///   The return value indicates whether the DC was released. If the DC was released, the return value is 1.
    ///   If the DC was not released, the return value is zero.
    /// </returns>
    [DllImport(nameof(User32), SetLastError = false)]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    #endregion

    #endregion

    #region DPI

    /// <summary>
    ///   Returns the dots per inch (dpi) value for the associated window.
    /// </summary>
    /// <param name="hWnd">The window you want to get information about.</param>
    /// <returns>
    ///   The DPI for the window which depends on the DPI_AWARENESS of the window.
    /// </returns>
    [DllImport(nameof(User32))]
    public static extern int GetDpiForWindow([In] IntPtr hWnd);

    /// <summary>
    ///   Returns the dots per inch (dpi) value for the system.
    /// </summary>
    /// <returns>The system DPI value.</returns>
    [DllImport(nameof(User32))]
    public static extern int GetDpiForSystem();

    /// <summary>
    ///   Values for the <c>nIndex</c> parameter in <see cref="GetSystemMetricsForDpi" />
    /// </summary>
    public enum SystemMetrics {
      /// <summary>
      ///   The recommended height of a small icon, in pixels.
      /// </summary>
      SM_CYSMICON = 50
    }

    /// <summary>
    ///   Retrieves the specified system metric or system configuration setting taking into account a provided DPI.
    /// </summary>
    /// <param name="nIndex">The system metric or configuration setting to be retrieved.</param>
    /// <param name="dpi">The DPI to use for scaling the metric.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(User32))]
    public static extern int GetSystemMetricsForDpi([In] int nIndex, [In] uint dpi);

    #endregion

    #region Cursors

    /// <summary>
    ///   System hand cursor
    /// </summary>
    public const int OCR_HAND = 32649;

    /// <summary>
    ///   Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
    /// </summary>
    /// <param name="hInstance">
    ///   A handle to an instance of the module whose executable file contains the cursor to be loaded.
    /// </param>
    /// <param name="lpCursorName">
    ///   The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource
    ///   identifier in the low-order word and zero in the high-order word.
    /// </param>
    /// <returns>If the function succeeds, the return value is the handle to the newly loaded cursor.</returns>
    [DllImport(nameof(User32))]
    public static extern IntPtr LoadCursor([In] [Optional] IntPtr hInstance, [In] IntPtr lpCursorName);

    /// <summary>
    ///   Sets the cursor shape.
    /// </summary>
    /// <param name="hCursor">
    ///   A handle to the cursor. The cursor must have been created by the CreateCursor function or loaded by the
    ///   <see cref="LoadCursor(IntPtr,IntPtr)" /> or LoadImage function.
    /// </param>
    /// <returns>The return value is the handle to the previous cursor, if there was one.</returns>
    [DllImport(nameof(User32))]
    public static extern IntPtr SetCursor([In] IntPtr hCursor);

    #endregion

    #region Hooks

    /// <summary>
    ///   The type of hook procedure to be installed by
    ///   <see cref="SetWindowsHookEx(WindowsHookType,WindowsHookDelegate,IntPtr,Int32)" />.
    /// </summary>
    public enum WindowsHookType {
      /// <summary>Installs a hook procedure that monitors low-level keyboard input events.</summary>
      WH_KEYBOARD_LL = 13,

      /// <summary>Installs a hook procedure that monitors low-level mouse input events.</summary>
      WH_MOUSE_LL = 14
    }

    /// <summary>
    ///   An application-defined or library-defined callback function used with the
    ///   <see cref="SetWindowsHookEx(WindowsHookType,WindowsHookDelegate,IntPtr,Int32)" /> function.
    ///   This is a generic function to Hook callbacks. For specific callback functions see this
    ///   <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632589(v=vs.85).aspx">
    ///     API documentation
    ///     on MSDN
    ///   </see>
    ///   .
    /// </summary>
    /// <param name="nCode">
    ///   An action code for the callback. Can be used to indicate if the hook procedure must process the message or
    ///   not.
    /// </param>
    /// <param name="wParam">First message parameter</param>
    /// <param name="lParam">Second message parameter</param>
    /// <returns>
    ///   An LRESULT. Usually if nCode is less than zero, the hook procedure must return the value returned by
    ///   CallNextHookEx.
    ///   If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx and return
    ///   the value it returns;
    ///   otherwise, other applications that have installed hooks will not receive hook notifications and may behave
    ///   incorrectly as a result.
    ///   If the hook procedure does not call CallNextHookEx, the return value should be zero.
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int WindowsHookDelegate([In] int nCode, [In] IntPtr wParam, [In] IntPtr lParam);

    /// <summary>
    ///   Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to
    ///   monitor the system for certain types of events. These events are associated either with a specific thread or
    ///   with all threads in the same desktop as the calling thread.
    /// </summary>
    /// <param name="idHook">The type of hook procedure to be installed.</param>
    /// <param name="lpfn">
    ///   A pointer to the hook procedure. If the <paramref name="dwThreadId" /> parameter is zero or
    ///   specifies the identifier of a thread created by a different process, the <paramref name="lpfn" /> parameter
    ///   must point to a hook procedure in a DLL. Otherwise, <paramref name="lpfn" /> can point to a hook procedure in
    ///   the code associated with the current process.
    /// </param>
    /// <param name="hMod">
    ///   A handle to the DLL containing the hook procedure pointed to by the <paramref name="lpfn" />
    ///   parameter. The <paramref name="hMod" /> parameter must be set to <see cref="IntPtr.Zero" /> if the
    ///   <paramref name="dwThreadId" /> parameter specifies a thread created by the current process and if the hook
    ///   procedure is within the code associated with the current process.
    /// </param>
    /// <param name="dwThreadId">
    ///   The identifier of the thread with which the hook procedure is to be associated. For desktop
    ///   apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the
    ///   same desktop as the calling thread. For Windows Store apps, see the Remarks section.
    /// </param>
    /// <returns>
    ///   If the function succeeds, the return value is the handle to the hook procedure.
    ///   <para>
    ///     If the function fails, the return value is an invalid handle. To get extended error information, call
    ///     GetLastError.
    ///   </para>
    /// </returns>
    [DllImport(nameof(User32), SetLastError = true)]
    public static extern IntPtr SetWindowsHookEx(
      [In] WindowsHookType idHook,
      [In] WindowsHookDelegate lpfn,
      [In] [Optional] IntPtr hMod,
      [In] [Optional] int dwThreadId);

    /// <summary>
    ///   Removes a hook procedure installed in a hook chain by the
    ///   <see cref="SetWindowsHookEx(WindowsHookType,WindowsHookDelegate,IntPtr,Int32)" /> function.
    /// </summary>
    /// <param name="hhk">
    ///   A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
    ///   <see cref="SetWindowsHookEx(WindowsHookType,WindowsHookDelegate,IntPtr,Int32)" />.
    /// </param>
    /// <returns>
    ///   If the function succeeds, the return value is true.
    ///   <para>
    ///     If the function fails, the return value is false. To get extended error information, call
    ///     GetLastError.
    ///   </para>
    /// </returns>
    [DllImport(nameof(User32), SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnhookWindowsHookEx([In] IntPtr hhk);

    /// <summary>
    ///   Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call
    ///   this function either before or after processing the hook information.
    /// </summary>
    /// <param name="hhk">This parameter is ignored.</param>
    /// <param name="nCode">
    ///   The hook code passed to the current hook procedure. The next hook procedure uses this code to determine how
    ///   to process the hook information.
    /// </param>
    /// <param name="wParam">
    ///   The wParam value passed to the current hook procedure. The meaning of this parameter depends on the type of
    ///   hook associated with the current hook chain.
    /// </param>
    /// <param name="lParam">
    ///   The lParam value passed to the current hook procedure. The meaning of this parameter depends on the type of
    ///   hook associated with the current hook chain.
    /// </param>
    /// <returns>
    ///   This value is returned by the next hook procedure in the chain. The current hook procedure must also return
    ///   this value. The meaning of the return value depends on the hook type. For more information, see the
    ///   descriptions of the individual hook procedures.
    /// </returns>
    [DllImport(nameof(User32), SetLastError = true)]
    public static extern int CallNextHookEx(
      [In] IntPtr hhk,
      [In] int nCode,
      [In] IntPtr wParam,
      [In] IntPtr lParam);

    #endregion

    #region Undocumented Windows 10 composition features

    [StructLayout(LayoutKind.Sequential)]
    public struct WindowCompositionAttributeData {
      public WindowCompositionAttribute Attribute;
      public IntPtr Data;
      public int SizeOfData;
    }

    public enum WindowCompositionAttribute {
      WCA_ACCENT_POLICY = 19
    }

    public enum AccentState {
      ACCENT_ENABLE_BLURBEHIND = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AccentPolicy {
      public AccentState AccentState;
      private readonly int AccentFlags;
      private readonly int GradientColor;
      private readonly int AnimationId;
    }

    [DllImport(nameof(User32))]
    public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

    #endregion

    #region Keyboard stuff

    /// <summary>
    ///   Retrieves the state of a virtual key.
    /// </summary>
    /// <param name="nVirtKey">A virtual key.</param>
    /// <returns>The return value specifies the status of the specified virtual key.</returns>
    [DllImport(nameof(User32))]
    public static extern short GetKeyState([In] int nVirtKey);

    /// <summary>
    ///   Retrieves the string that represents the name of a key.
    /// </summary>
    /// <param name="lParam">Key code</param>
    /// <param name="lpString">String pointer</param>
    /// <param name="nSize">Buffer size</param>
    /// <returns></returns>
    [DllImport(nameof(User32))]
    public static extern int GetKeyNameText(
      [In] int lParam,
      [Out] StringBuilder lpString,
      [In] int nSize);

    /// <summary>
    ///   Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a
    ///   virtual-key code.
    /// </summary>
    /// <param name="uCode">The virtual key code or scan code for a key.</param>
    /// <param name="uMapType">The translation to be performed.</param>
    /// <returns>The return value is either a scan code, a virtual-key code, or a character value.</returns>
    [DllImport(nameof(User32))]
    public static extern int MapVirtualKey(
      [In] int uCode,
      [In] MapType uMapType);

    /// <summary>
    ///   Removes the caret from the screen.
    /// </summary>
    /// <param name="hWnd">A handle to the window that owns the caret.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport(nameof(User32))]
    public static extern bool HideCaret([In] IntPtr hWnd);

    #endregion
  }
}