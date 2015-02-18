using System;
using System.Windows.Forms;

namespace BSViewer
{
    public partial class frmLogin : Form
    {
        public String Password { get; private set; }
        public String Username { get; private set; }



        public frmLogin()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Username = txtUser.Text;
            Password = txtPasswort.Text;
        }
    }
}
