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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            WareHouses wareHouses = new WareHouses();
            wareHouses.MdiParent = this;
            wareHouses.FormBorderStyle = FormBorderStyle.None;
            wareHouses.Dock = DockStyle.Fill;
            wareHouses.StartPosition = FormStartPosition.Manual;
            wareHouses.Show();
        }

        private void menuSetting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputProducts input = new InputProducts();
            input.ShowDialog();
        }

        private void menuImport_Click(object sender, EventArgs e)
        {
            InputProducts input = new InputProducts();
            input.ShowDialog();
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            OutputProducts output = new OutputProducts();
            output.ShowDialog();
        }
    }
}
