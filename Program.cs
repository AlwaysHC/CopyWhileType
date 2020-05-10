using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CopyWhileType {
    static class Program {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static readonly LowLevelKeyboardProc PROC = HookCallback;
        private static IntPtr _HookID = IntPtr.Zero;

        [STAThread]
        static void Main() {
            _HookID = SetHook(PROC);
            Application.Run();
            UnhookWindowsHookEx(_HookID);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static Visualizzatore _Visualizzatore = null;

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                Keys VKCode = (Keys)Marshal.ReadInt32(lParam);

                if (_Visualizzatore != null) {
                    if (!_Visualizzatore.Visible) {
                        _Visualizzatore = null;
                    }
                }

                switch (VKCode) {
                    case Keys.Back:
                    case Keys.Delete:
                        if (_Visualizzatore != null) {
                            _Visualizzatore.TogliTesto();
                        }
                        break;
                    case Keys.X:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            if (_Visualizzatore != null) {
                                _Visualizzatore.Close();
                                _Visualizzatore = null;
                            }
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed(ancheCapsLock: true) ? "X" : "x");
                        }
                        break;
                    case Keys.C:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            if (_Visualizzatore == null) {
                                _Visualizzatore = new Visualizzatore();
                                _Visualizzatore.Show();
                            }
                            else {
                                _Visualizzatore.Copia();
                                _Visualizzatore.Close();
                                _Visualizzatore = null;
                            }
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed(ancheCapsLock: true) ? "C" : "c");
                        }
                        break;
                    case Keys.E:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "" : "€");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed(ancheCapsLock: true) ? "E" : "e");
                        }
                        break;
                    case Keys.A:
                    case Keys.B:
                    case Keys.D:
                    case Keys.F:
                    case Keys.G:
                    case Keys.H:
                    case Keys.I:
                    case Keys.J:
                    case Keys.K:
                    case Keys.L:
                    case Keys.M:
                    case Keys.N:
                    case Keys.O:
                    case Keys.P:
                    case Keys.Q:
                    case Keys.R:
                    case Keys.S:
                    case Keys.T:
                    case Keys.U:
                    case Keys.V:
                    case Keys.W:
                    case Keys.Y:
                    case Keys.Z:
                        VisualizzaTesto((GetShiftPressed(ancheCapsLock: true) ? (char)VKCode : char.ToLower((char)VKCode)).ToString());
                        break;
                    case Keys.D0:
                        VisualizzaTesto(GetShiftPressed() ? "=" : "0");
                        break;
                    case Keys.D1:
                        VisualizzaTesto(GetShiftPressed() ? "!" : "1");
                        break;
                    case Keys.D2:
                        VisualizzaTesto(GetShiftPressed() ? "\"" : "2");
                        break;
                    case Keys.D3:
                        VisualizzaTesto(GetShiftPressed() ? "£" : "3");
                        break;
                    case Keys.D4:
                        VisualizzaTesto(GetShiftPressed() ? "$" : "4");
                        break;
                    case Keys.D5:
                        VisualizzaTesto(GetShiftPressed() ? "%" : "5");
                        break;
                    case Keys.D6:
                        VisualizzaTesto(GetShiftPressed() ? "&" : "6");
                        break;
                    case Keys.D7:
                        VisualizzaTesto(GetShiftPressed() ? "/" : "7");
                        break;
                    case Keys.D8:
                        VisualizzaTesto(GetShiftPressed() ? "(" : "8");
                        break;
                    case Keys.D9:
                        VisualizzaTesto(GetShiftPressed() ? ")" : "9");
                        break;
                    case Keys.NumPad0:
                        VisualizzaTesto("0");
                        break;
                    case Keys.NumPad1:
                        VisualizzaTesto("1");
                        break;
                    case Keys.NumPad2:
                        VisualizzaTesto("2");
                        break;
                    case Keys.NumPad3:
                        VisualizzaTesto("3");
                        break;
                    case Keys.NumPad4:
                        VisualizzaTesto("4");
                        break;
                    case Keys.NumPad5:
                        VisualizzaTesto("5");
                        break;
                    case Keys.NumPad6:
                        VisualizzaTesto("6");
                        break;
                    case Keys.NumPad7:
                        VisualizzaTesto("7");
                        break;
                    case Keys.NumPad8:
                        VisualizzaTesto("8");
                        break;
                    case Keys.NumPad9:
                        VisualizzaTesto("9");
                        break;
                    case Keys.Oem5:
                        VisualizzaTesto(GetShiftPressed() ? "|" : "\\");
                        break;
                    case Keys.OemOpenBrackets:
                        VisualizzaTesto(GetShiftPressed() ? "?" : "'");
                        break;
                    case Keys.Oem6:
                        VisualizzaTesto(GetShiftPressed() ? "^" : "ì");
                        break;
                    case Keys.OemBackslash:
                        VisualizzaTesto(GetShiftPressed() ? ">" : "<");
                        break;
                    case Keys.Oemcomma:
                        VisualizzaTesto(GetShiftPressed() ? ";" : ",");
                        break;
                    case Keys.OemPeriod:
                        VisualizzaTesto(GetShiftPressed() ? ":" : ".");
                        break;
                    case Keys.OemMinus:
                        VisualizzaTesto(GetShiftPressed() ? "_" : "-");
                        break;
                    case Keys.Oem1:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "{" : "[");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed() ? "é" : "è");
                        }
                        break;
                    case Keys.Oemplus:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "}" : "}");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed() ? "*" : "+");
                        }
                        break;
                    case Keys.Oemtilde:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "" : "@");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed() ? "ç" : "ò");
                        }
                        break;
                    case Keys.Oem7:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "" : "#");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed() ? "°" : "à");
                        }
                        break;
                    case Keys.OemQuestion:
                        if (GetCtrlPressed() && GetAltPressed()) {
                            VisualizzaTesto(GetShiftPressed() ? "" : "");
                        }
                        else {
                            VisualizzaTesto(GetShiftPressed() ? "§" : "ù");
                        }
                        break;
                    case Keys.Add:
                        VisualizzaTesto("+");
                        break;
                    case Keys.Subtract:
                        VisualizzaTesto("-");
                        break;
                    case Keys.Multiply:
                        VisualizzaTesto("*");
                        break;
                    case Keys.Divide:
                        VisualizzaTesto("/");
                        break;
                    case Keys.RShiftKey:
                    case Keys.LShiftKey:
                    case Keys.LMenu:
                    case Keys.Shift:
                    case Keys.ShiftKey:
                    case Keys.RControlKey:
                    case Keys.LControlKey:
                    case Keys.Control:
                    case Keys.ControlKey:
                    case Keys.Alt:
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                    case Keys.LWin:
                    case Keys.RWin:
                    case Keys.Apps:
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                    case Keys.Print:
                    case Keys.PrintScreen:
                    case Keys.Escape:
                    case Keys.Pause:
                    case Keys.Return:
                    case Keys.Tab:
                    case Keys.NumLock:
                    case Keys.Capital:
                        break;
                    default:
                        VisualizzaTesto($"<{VKCode}>");
                        break;
                }

                //Console.WriteLine((Keys)VKCode);
                //using (StreamWriter SW = new StreamWriter(Application.StartupPath + @"\log.txt", true)) {
                //    SW.WriteLine((Keys)VKCode + " " + VKCode + " " + wParam + " " + lParam);
                //    SW.Close();
                //}
            }
            return CallNextHookEx(_HookID, nCode, wParam, lParam);
        }

        private static void VisualizzaTesto(string c) {
            if (_Visualizzatore != null) {
                _Visualizzatore.AggiungiTesto(c);
            }
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc) {
            using (Process CurProcess = Process.GetCurrentProcess()) {
                using (ProcessModule CurModule = CurProcess.MainModule) {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(CurModule.ModuleName), 0);
                }
            }
        }

        private static bool GetShiftPressed(bool ancheCapsLock = false) {
            int State = GetKeyState(Keys.ShiftKey);
            if (State > 1 || State < -1)
                return Control.IsKeyLocked(Keys.CapsLock) ? false : true;
            return Control.IsKeyLocked(Keys.CapsLock) ? true : false;
        }
        private static bool GetCtrlPressed() {
            int State = GetKeyState(Keys.ControlKey);
            if (State > 1 || State < -1)
                return true;
            return false;
        }
        private static bool GetAltPressed() {
            int State = GetKeyState(Keys.Menu);
            if (State > 1 || State < -1)
                return true;
            return false;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys nVirtKey);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetKeyboardLayout(uint dwLayout);

        [DllImport("User32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("User32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);

        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);
    }
}
