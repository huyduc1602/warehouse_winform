using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUser.Text = "admin";
            txtPassword.Text = "admin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("admin") && txtPassword.Text.Equals("admin"))
            {
                Dashboard d = new Dashboard();
                d.Show();
                this.Hide();
            }
        }
    }
}
