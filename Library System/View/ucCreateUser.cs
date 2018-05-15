using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System.View
{
    public partial class ucCreateUser : UserControl
    {
        private static ucCreateUser _instance;
        public static ucCreateUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucCreateUser();
                return _instance;
            }
        }
        public ucCreateUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
