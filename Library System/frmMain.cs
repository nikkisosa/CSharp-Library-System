using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_System.View;
namespace Library_System
{
    public partial class frmMain : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public frmMain()
        {
            InitializeComponent();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            if (!pnlBody.Controls.Contains(ucCreateUser.Instance))
            {
                pnlBody.Controls.Add(ucCreateUser.Instance);
                ucCreateUser.Instance.Dock = DockStyle.Fill;
                ucCreateUser.Instance.BringToFront();
            }
            else
            {
                ucCreateUser.Instance.BringToFront();
            }
        }


    }
}
