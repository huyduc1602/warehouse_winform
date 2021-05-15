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
    public partial class Brands : Form
    {
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public int Id { get; set; }
        public string Action { get; set; }
        public Brands()
        {
            InitializeComponent();
        }

        private void Brands_Load(object sender, EventArgs e)
        {
                if (!String.IsNullOrEmpty(Action))
                {
                    if (Action.Equals("add"))
                    {
                    this.ActiveControl = txtName;
                    }
                    else if (Action.Equals("see"))
                    {
                        var brand = (from b in db.Brands where b.Id == Id select b).First();
                        txtName.Text = brand.DisplayName;
                        txtMoreInfo.Text = brand.MoreInfo;
                        if (brand.Status == true)
                        {
                            chkSatus.Checked = true;
                        }
                        txtMoreInfo.ReadOnly = true;

                    }
                    else if (Action.Equals("edit"))
                    {
                        var brand = (from b in db.Brands where b.Id == Id select b).First();
                        txtName.Text = brand.DisplayName;
                        txtMoreInfo.Text = brand.MoreInfo;
                        if (brand.Status == true)
                        {
                            chkSatus.Checked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có hành động nào được chọn", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }                  

        }
        private void FiledValid()
        {
            foreach (Control control in this.Controls)
            {
                 // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
                if (!Validate())
                {
                    return;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
                    this.DialogResult = DialogResult.OK;
                    if (Action.Equals("edit"))
                    {
                        var b = db.Brands.SingleOrDefault(x => x.Id == Id);

                        b.DisplayName = txtName.Text;
                        b.MoreInfo = txtMoreInfo.Text;
                        b.Status = chkSatus.Checked;
                        db.SubmitChanges();

                    }
                    else
                    {
                        Brand b = new Brand();
                        b.DisplayName = txtName.Text;
                        b.MoreInfo = txtMoreInfo.Text;
                        b.Status = chkSatus.Checked;
                        db.Brands.InsertOnSubmit(b);

                        db.SubmitChanges();
                    }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
