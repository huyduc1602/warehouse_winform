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
    public partial class Categories : Form
    {
        public int Id { get; set; }
        public string Action { get; set; }
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
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
                    if (category.Status == true)
                    {
                        chkSatus.Checked = true;
                    }
                    txtMoreInfo.ReadOnly = true;

                }
                else if (Action.Equals("edit"))
                {
                    var category = (from c in db.Categories where c.Id == Id select c).First();
                    txtName.Text = category.DisplayName;
                    txtMoreInfo.Text = category.MoreInfo;
                    if (category.Status == true)
                    {
                        chkSatus.Checked = true;
                    }
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
            if (Action != null & Action.Equals("edit"))
            {
                var category = db.Categories.SingleOrDefault(x => x.Id == Id);

                category.DisplayName = txtName.Text;
                category.MoreInfo = txtMoreInfo.Text;
                category.Status = chkSatus.Checked;
                db.SubmitChanges();
                this.Close();

            }else
            {
                Category category = new Category();
                category.DisplayName = txtName.Text;
                category.MoreInfo = txtMoreInfo.Text;
                category.Status = chkSatus.Checked;
                db.Categories.InsertOnSubmit(category);

                db.SubmitChanges();
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
