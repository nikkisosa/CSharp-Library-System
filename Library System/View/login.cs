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

namespace Library_System.View
{
    public partial class login : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public login()
        {
            InitializeComponent();
        }

        private void dragFormDown(MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void dragFormMove(MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void dragFormUp()
        {
            mouseDown = false;
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            dragFormDown(e);
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            dragFormMove(e);
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            dragFormUp();
        }

        private void pnlSide_MouseMove(object sender, MouseEventArgs e)
        {
            dragFormMove(e);
        }

        private void pnlSide_MouseUp(object sender, MouseEventArgs e)
        {
            dragFormUp();
        }

        private void pnlSide_MouseDown(object sender, MouseEventArgs e)
        {
            dragFormDown(e);
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            
        }

        private void lblForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPassword fp = new forgotPassword();
            fp.ShowDialog();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
