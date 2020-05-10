using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyWhileType {
    public partial class Visualizzatore: Form {
        public Visualizzatore() {
            InitializeComponent();
        }

        protected override bool ShowWithoutActivation {
            get {
                return true;
            }
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams BaseParams = base.CreateParams;

                BaseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);

                return BaseParams;
            }
        }

        public void AggiungiTesto(string testo) {
            if (!tbTesto.Focused) {
                if (testo.Length == 1) {
                    char C = testo[0];
                    if (char.IsWhiteSpace(C) || char.IsLetterOrDigit(C) || char.IsPunctuation(C) || char.IsNumber(C) || char.IsSymbol(C)) {
                        tbTesto.Text += C;
                    }
                }
                else {
                    tbTesto.Text += testo;
                }
            }
        }

        public void TogliTesto() {
            if (!tbTesto.Focused) {
                if (tbTesto.Text.Length > 0) {
                    tbTesto.Text = tbTesto.Text.Substring(0, tbTesto.Text.Length - 1);
                }
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e) {
            Close();
        }

        private void Visualizzatore_Shown(object sender, EventArgs e) {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width - 30,
                                 Screen.PrimaryScreen.Bounds.Height - Height - 150);
        }

        public void Copia() {
            if (tbTesto.Text.Length > 0) {
                Clipboard.SetText(tbTesto.Text);
            }
        }

        private void btnCopia_Click(object sender, EventArgs e) {
            Copia();
        }

        const int GWL_EXSTYLE = -20;
        const int WS_EX_NOACTIVATE = 0x08000000;
        const int WS_EX_TOOLWINDOW = 0x00000080;

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private void tbTesto_Enter(object sender, EventArgs e) {
            int Stile = GetWindowLong(Handle, GWL_EXSTYLE) & ~WS_EX_NOACTIVATE;
            SetWindowLong(Handle, GWL_EXSTYLE, Stile);
        }

        private void tbTesto_Leave(object sender, EventArgs e) {
            int Stile = GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_NOACTIVATE;
            SetWindowLong(Handle, GWL_EXSTYLE, Stile);
        }
    }
}
