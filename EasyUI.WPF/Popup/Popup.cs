using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace EasyUI.WPF.Popups
{
    public class EasyPopup : Popup
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetActiveWindow(IntPtr hWnd);
        static EasyPopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EasyPopup), new FrameworkPropertyMetadata(typeof(EasyPopup)));
            EventManager.RegisterClassHandler(
            typeof(EasyPopup),
            Popup.PreviewGotKeyboardFocusEvent,
            new KeyboardFocusChangedEventHandler(OnPreviewGotKeyboardFocus),
            true);
        }
        private static void OnPreviewGotKeyboardFocus(Object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.NewFocus is TextBoxBase textBox)
            {
                if (PresentationSource.FromVisual(textBox) is HwndSource hwndSource)
                {
                    SetActiveWindow(hwndSource.Handle);
                }
            }
        }
    }
}
