using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System.View
{
    public partial class customMessage : Form
    {
        //lblTitle properties
        //color = white
        //location = 12, 3
        //font size = 15pt
        //font family = bell mt
        
        //lblMessage properties
        //color = 0, 175, 240
        //backColor = white

        //button properties
        //size = 78, 31
        //location = 294, 3 right
        //location = 210, 3 left
        //backColor = 0, 175, 240
        //
        public string icon;
        private Label lblTitle, lblMessage;
        private Button btnRight, btnLeft;
        private Timer timer;
        private int counter = 0;
        public customMessage()
        {
            InitializeComponent();

            btnRight = new Button();
            btnRight.Click += btnRight_Click;

            btnLeft = new Button();
            btnLeft.Click += btnLeft_Click;
            timer = new Timer();
            timer.Interval = 200;
            timer.Start();
            timer.Tick += timer_Tick;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {   
            if (counter == 0)
            {
                try
                {
                    pbIcon.Image = new System.Drawing.Bitmap(System.IO.Path.GetFullPath(@"..\..\Resources\" + icon + "_skype_color_1_md.png"));
                }
                catch(Exception)
                {
                    pbIcon.Image = new System.Drawing.Bitmap(System.IO.Path.GetFullPath(@"..\..\Resources\warning_skype_color_1_md.png"));
                }
                counter++;
            }
            else
            {
                try
                {
                    pbIcon.Image = new System.Drawing.Bitmap(System.IO.Path.GetFullPath(@"..\..\Resources\" + icon + "_skype_color_md.png"));
                }
                catch (Exception)
                {
                    pbIcon.Image = new System.Drawing.Bitmap(System.IO.Path.GetFullPath(@"..\..\Resources\warning_skype_color_md.png"));
                }
                counter = 0;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnLeft = (Button)sender;
            this.Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
           btnRight = (Button)sender;
           this.Close();
        }

        public void custom_message()
        {
            custom_message("Message", "Please check your code and update message parameter.", MessageBoxButtons.OKCancel);
        }


        public void custom_message(string title,string message)
        {
            if (title != string.Empty)
            {
                if (message != string.Empty)
                {
                    titleStyle(title);

                    messageStyle(message);

                    buttonRightStyle();

                    btnRight.Text = "Ok";
                    pnlFooter.Controls.Add(btnRight);
                }
                else
                {
                    custom_message("Message", "Empty message", MessageBoxButtons.OK);
                }
            }
            else
            {
                custom_message("Message","Empty title",MessageBoxButtons.OK);
            }
        }

        public void custom_message(string title, string message, MessageBoxButtons button)
        {
            if (title != string.Empty)
            {
                if (message != string.Empty)
                {
                    titleStyle(title);

                    messageStyle(message);

                    buttonRightStyle();

                    buttonLeftStyle();
                    switch (button)
                    {
                        case MessageBoxButtons.AbortRetryIgnore:
                            break;
                        case MessageBoxButtons.OK:
                            btnRight.Text = "Ok";
                            pnlFooter.Controls.Add(btnRight);
                            break;
                        case MessageBoxButtons.OKCancel:
                            btnRight.Text = "Ok";
                            btnLeft.Text = "Cancel";
                            pnlFooter.Controls.Add(btnRight);
                            pnlFooter.Controls.Add(btnLeft);
                            break;
                        case MessageBoxButtons.RetryCancel:
                            break;
                        case MessageBoxButtons.YesNo:
                            break;
                        case MessageBoxButtons.YesNoCancel:
                            break;
                        default:
                            break;
                    }

                    
                }
                else
                {
                    custom_message("Message", "Empty message", MessageBoxButtons.OK);
                }
            }
            else
            {
                custom_message("Message", "Empty title", MessageBoxButtons.OK);
            }
        }

        public void custom_message(string title, string message, MessageBoxButtons button, MessageBoxIcon icon)
        {

        }

        private void titleStyle(string title)
        {
            lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Location = new Point(12, 3);
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Bell MT", 15);
            pnlHeader.Controls.Add(lblTitle);
        }

        private void messageStyle(string message)
        {
            lblMessage = new Label();
            lblMessage.AutoSize = false;
            lblMessage.Text = message;
            lblMessage.Size = new Size(339, 26);
            lblMessage.Location = new Point(3, 0);
            lblMessage.BackColor = Color.White;
            lblMessage.ForeColor = Color.FromArgb(110,110,110);
            lblMessage.Font = new Font(FontFamily.GenericSansSerif, Convert.ToInt32(8.25),FontStyle.Bold);
            flpMessage.Controls.Add(lblMessage);
        }

        private void buttonRightStyle()
        {
            btnRight.Location = new Point(294, 3);
            btnRight.BackColor = Color.FromArgb(0, 175, 240);
            btnRight.ForeColor = Color.White;
            btnRight.Size = new Size(78, 31);
            btnRight.FlatAppearance.BorderSize = 0;
            btnRight.FlatStyle = FlatStyle.Flat;
        }

        private void buttonLeftStyle()
        {
            btnLeft.Location = new Point(210, 3);
            btnLeft.BackColor = Color.FromArgb(0, 175, 240);
            btnLeft.ForeColor = Color.White;
            btnLeft.Size = new Size(78, 31);
            btnLeft.FlatAppearance.BorderSize = 0;
            btnLeft.FlatStyle = FlatStyle.Flat;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
