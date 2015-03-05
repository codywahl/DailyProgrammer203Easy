using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _203_Easy
{
    public partial class EasySquare : Form
    {
        #region Constants

        //Form Move data members
        private const int WM_NCLBUTTONDOWN = 0xA1;

        private const int HT_CAPTION = 0x2;

        private Random r = new Random();

        #endregion Constants

        #region Form Movement

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
        int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion Form Movement

        #region Constructor

        public EasySquare()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        #endregion Constructor

        #region Private Helpers

        private void SetNewBackgroundColor()
        {
            this.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        private void SetNewSize()
        {
            int size = r.Next(50, 1000);
            this.Size = new Size(size, size);
            AdjustTheXsPosition(size);
        }

        private void AdjustTheXsPosition(int formSize)
        {
            int location = (formSize / 2) - (CloseLabel.Width / 2);
            CloseLabel.Location = new Point(location, location);
        }

        #endregion Private Helpers

        #region Event Handler

        private void EasySquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                SetNewBackgroundColor();
                SetNewSize();
            }
        }

        #endregion Event Handler

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}