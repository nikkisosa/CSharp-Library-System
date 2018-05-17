using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Library_System.View
{
    public partial class forgotPassword : Form
    {
        //code size 283, 159
        //new pass size 283, 191
        //default location 18, 31

        private string port;
        Random rnd = new Random();
        public forgotPassword()
        {
            InitializeComponent();
        }

        private void checkPort()
        {
            SerialPort _serial = new SerialPort();
            port = _serial.PortName;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(txtNumber.Text != string.Empty)
            {
                SerialPort _serial = new SerialPort();
                _serial.BaudRate = 115200;
                _serial.Parity = Parity.None;
                _serial.StopBits = StopBits.One;
                _serial.DataBits = 8;
                _serial.Handshake = Handshake.None;
                _serial.RtsEnable = true;
                _serial.NewLine = "\n";
                _serial.PortName = "COM5";
                _serial.Open();
                _serial.WriteLine("AT\r");
                Thread.Sleep(100);
                _serial.WriteLine("AT+CMGF=1\r");
                Thread.Sleep(100);
                _serial.WriteLine("AT+CMGS=\"" + txtNumber.Text + "\"\r");
                Thread.Sleep(100);
                _serial.WriteLine(rnd.Next(111111, 999999) + "\r");
                Thread.Sleep(100);
                _serial.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);
                _serial.Close();
                pnlSend.SendToBack();
                pnlCode.BringToFront();
                pnlCode.Visible = true;
                pnlSend.Visible = false;
            }
            else
            {
                customMessage cm = new customMessage();
                cm.icon = "information";
                cm.custom_message("Message","Please enter your registered mobile number",MessageBoxButtons.OK);
                cm.ShowDialog();
                
            }
            
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            pnlSend.SendToBack();
            pnlCode.BringToFront();
            pnlCode.Visible = false;
            pnlSend.Visible = false;
            pnlCreateNew.Visible = true;
            pnlCreateNew.BringToFront();
            pnlCreateNew.Location = new Point(18, 31);
        }

        private void forgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
