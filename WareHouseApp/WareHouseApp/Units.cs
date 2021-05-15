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
    public partial class Units : Form
    {
        public int Id { get; set; }
        public string Action { get; set; }
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public Units()
        {
            InitializeComponent();
        }
        private void Units_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Action))
            {
                if (Action.Equals("add"))
                {
                    this.ActiveControl = txtName;
                }
                else if (Action.Equals("see"))
                {
                    var category = (from c in db.Categories where c.Id == Id select c).First();
                    txtName.Text = category.DisplayName;
                    txtMoreInfo.Text = category.MoreInfo;
                    txtMoreInfo.ReadOnly = true;

                }
                else if (Action.Equals("edit"))
                {
                    var category = (from c in db.Categories where c.Id == Id select c).First();
                    txtName.Text = category.DisplayName;
                    txtMoreInfo.Text = category.MoreInfo;
                }
                else
                {
                    MessageBox.Show("Chưa có hành dộng nào được chọn", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (Action.Equals("edit"))
            {
                var unit = db.Units.SingleOrDefault(x => x.Id == Id);

                unit.DisplayName = txtName.Text;

                db.SubmitChanges();
                this.Close();

            }
            else
            {
                Unit unit = new Unit();
                unit.DisplayName = txtName.Text;
                db.Units.InsertOnSubmit(unit);

                db.SubmitChanges();
                this.Close();
            }
        }

       
    }
}
