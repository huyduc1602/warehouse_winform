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
    public partial class Suppliers : Form
    {
        public int Id { get; set; }
        public string Action { get; set; }
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public Suppliers()
        {
            InitializeComponent();
        }
        private void FiledValid()
        {
            foreach (Control control in this.Controls)
            {
                // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
            }
        }
        private void Suppliers_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Action))
            {
                if (Action.Equals("add"))
                {
                    this.ActiveControl = txtName;
                }
                else if (Action.Equals("see"))
                {
                    var suplier = (from c in db.Supliers where c.Id == Id select c).First();
                    txtName.Text = suplier.DisplayName;
                    txtTaxCode.Text = suplier.TaxCode;
                    txtAccountNumber.Text = suplier.AcountNumber;
                    txtPhone.Text = suplier.Phone;
                    txtEmail.Text = suplier.Email;
                    txtAdress.Text = suplier.Adress;
                    txtMoreInfo.Text = suplier.MoreInfo;
                    txtContractDate.Value = (DateTime)suplier.ContractDate;
                    if (suplier.Status == true)
                    {
                        chkSatus.Checked = true;
                    }
                    txtMoreInfo.ReadOnly = true;

                }
                else if (Action.Equals("edit"))
                {
                    var suplier = (from c in db.Supliers where c.Id == Id select c).First();
                    txtName.Text = suplier.DisplayName;
                    txtTaxCode.Text = suplier.TaxCode;
                    txtAccountNumber.Text = suplier.AcountNumber;
                    txtPhone.Text = suplier.Phone;
                    txtEmail.Text = suplier.Email;
                    txtAdress.Text = suplier.Adress;
                    txtMoreInfo.Text = suplier.MoreInfo;
                    txtContractDate.Value = (DateTime)suplier.ContractDate;
                    if (suplier.Status == true)
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
            FiledValid();
            this.DialogResult = DialogResult.OK;
            if (Action.Equals("edit"))
            {
                var suplier = db.Supliers.SingleOrDefault(x => x.Id == Id);

                suplier.DisplayName = txtName.Text;
                suplier.TaxCode = txtTaxCode.Text;
                suplier.AcountNumber = txtAccountNumber.Text;
                suplier.Phone = txtPhone.Text;
                suplier.Email = txtEmail.Text;
                suplier.Adress = txtAdress.Text;
                suplier.ContractDate = txtContractDate.Value;
                suplier.MoreInfo = txtMoreInfo.Text;
                suplier.Status = chkSatus.Checked;
                db.SubmitChanges();
                this.Close();

            }
            else
            {
                Suplier suplier = new Suplier();
                suplier.DisplayName = txtName.Text;
                suplier.TaxCode = txtTaxCode.Text;
                suplier.AcountNumber = txtAccountNumber.Text;
                suplier.Phone = txtPhone.Text;
                suplier.Email = txtEmail.Text;
                suplier.Adress = txtAdress.Text;
                suplier.ContractDate = txtContractDate.Value;
                suplier.MoreInfo = txtMoreInfo.Text;
                suplier.Status = chkSatus.Checked;
                db.Supliers.InsertOnSubmit(suplier);

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
