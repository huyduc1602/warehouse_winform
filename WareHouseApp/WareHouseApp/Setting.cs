using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApp.Properties;

namespace WareHouseApp
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            txtIp.Text = Settings.Default.Ip;
            txtPort.Text = Settings.Default.Port;
            txtAccount.Text = Settings.Default.Account;
            txtPassword.Text = Settings.Default.Password;

            //Load database
            GetDatabaseList();
            cboDatabase.SelectedIndex = 0;
        }
        public void GetDatabaseList()
        {
            try
            {
                string Conn = "server=.;User Id=sa;" + "pwd=1234$;";
                SqlConnection con = new SqlConnection(Conn);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                //   da = new SqlDataAdapter("SELECT * FROM sys.database", con);
                cmd = new SqlCommand("SELECT name FROM sys.databases", con);
                // comboBox1.Items.Add(cmd);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //comboBox2.Items.Add(dr[0]);
                        cboDatabase.Items.Add(dr[0]);
                    }
                }

                // .Items.Add(da);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
