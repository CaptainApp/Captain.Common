// ReSharper disable InconsistentNaming

namespace Captain.Common.Native {
  public partial class User32 {
    /// <summary>
    ///   Windows Messages
    ///   Defined in winuser.h from Windows SDK v6.1
    ///   Documentation pulled from MSDN.
    /// </summary>
    public enum WindowMessage {
      /// <summary>
      ///   Sent by a window which requires repainting
      /// </summary>
      WM_PAINT = 0x000F,

      /// <summary>
      ///   Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
      /// </summary>
      WM_SETCURSOR = 0x0020,
      
      /// <summary>
      ///   The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about
      ///   to change as a result of a call to the SetWindowPos function or another window-management function.
      /// </summary>
      WM_WINDOWPOSCHANGING = 0x0046,

      /// <summary>
      ///   Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate.
      /// </summary>
      WM_NCHITTEST = 0x0084,

      /// <summary>
      ///   Posted to the window with the keyboard focus when a nonsystem key is pressed.
      ///   A nonsystem key is a key that is pressed when the ALT key is not pressed.
      /// </summary>
      WM_KEYDOWN = 0x0100,

      /// <summary>
      ///   Posted to the window with the keyboard focus when a nonsystem key is released.
      ///   A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed
      ///   when a window has the keyboard focus.
      /// </summary>
      WM_KEYUP = 0x0101,

      /// <summary>
      ///   Posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage
      ///   function.
      /// </summary>
      WM_CHAR = 0x0102,

      /// <summary>
      ///   Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu
      ///   bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has
      ///   the keyboard focus.
      /// </summary>
      WM_SYSKEYDOWN = 0x104,

      /// <summary>
      ///   Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT
      ///   key was held down.
      /// </summary>
      WM_SYSKEYUP = 0x105,

      /// <summary>
      ///   An application sends the WM_CHANGEUISTATE message to indicate that the UI state should be changed.
      /// </summary>
      WM_CHANGEUISTATE = 0x0127,

      #region Mouse events

      /// <summary>
      ///   Posted to a window when the cursor moves.
      /// </summary>
      WM_MOUSEMOVE = 0x0200,

      /// <summary>
      ///   Posted when the user presses the left mouse button while the cursor is in the client area of a window.
      /// </summary>
      WM_LBUTTONDOWN = 0x0201,

      /// <summary>
      ///   Posted when the user releases the left mouse button while the cursor is in the client area of a window.
      /// </summary>
      WM_LBUTTONUP = 0x0202,

      /// <summary>
      ///   Posted when the user presses the right mouse button while the cursor is in the client area of a window.
      /// </summary>
      WM_RBUTTONDOWN = 0x0204,

      /// <summary>
      ///   Posted when the user releases the right mouse button while the cursor is in the client area of a window.
      /// </summary>
      WM_RBUTTONUP = 0x0205,

      #endregion

      /// <summary>
      ///   Sent when the effective dots per inch (dpi) for a window has changed.
      /// </summary>
      WM_DPICHANGED = 0x02E0,

      /// <summary>
      ///   Informs all top-level windows that Desktop Window Manager (DWM) composition has been enabled or disabled.
      /// </summary>
      WM_DWMCOMPOSITIONCHANGED = 0x031E,

      /// <summary>
      ///   Informs all top-level windows that the colorization color has changed.
      /// </summary>
      WM_DWMCOLORIZATIONCHANGED = 0x0320,

      /// <summary>
      ///   Sets extended styles in list-view controls.
      /// </summary>
      LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1036,

      /// <summary>
      ///   Sets the HCURSOR value that the list-view control uses when the pointer is over an item while hot tracking
      ///   is enabled.
      /// </summary>
      LVM_SETHOTCURSOR = 0x103E,

      /// <summary>
      ///   Calculates a tab control's display area given a window rectangle, or calculates the window rectangle that
      ///   would correspond to a specified display area.
      /// </summary>
      TCM_ADJUSTRECT = 0x1328,

      /// <summary>
      ///   Sets the widths of the left and right margins for an edit control.
      /// </summary>
      EM_SETMARGINS = 0x00D3
    }
  }
}