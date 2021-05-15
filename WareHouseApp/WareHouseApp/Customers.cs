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
    public partial class Customers : Form
    {
        public int Id { get; set; }
        public string Action { get; set; }
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {           
            if (!String.IsNullOrEmpty(Action))
            {
                if (Action.Equals("add"))
                {
                    this.ActiveControl = txtName;
                }
                else if (Action.Equals("see"))
                {
                    var customer = (from c in db.Customers where c.Id == Id select c).First();
                    txtName.Text = customer.DisplayName;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                    txtAdress.Text = customer.Adress;
                    txtMoreInfo.Text = customer.MoreInfo;
                    txtContractDate.Value = (DateTime)customer.ContractDate;
                    chkSatus.Checked = customer.Status;
                    txtMoreInfo.ReadOnly = true;

                }
                else if (Action.Equals("edit"))
                {
                    var customer = (from c in db.Customers where c.Id == Id select c).First();
                    txtName.Text = customer.DisplayName;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                    txtAdress.Text = customer.Adress;
                    txtMoreInfo.Text = customer.MoreInfo;                    
                    txtContractDate.Value = (DateTime)customer.ContractDate;
                    chkSatus.Checked = customer.Status;
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
                var customer = db.Customers.SingleOrDefault(x => x.Id == Id);

                customer.DisplayName = txtName.Text;
                customer.Phone = txtPhone.Text;
                customer.Email = txtEmail.Text;
                customer.Adress = txtAdress.Text;
                customer.ContractDate = txtContractDate.Value;
                customer.MoreInfo = txtMoreInfo.Text;
                customer.Status = chkSatus.Checked;
                db.SubmitChanges();
                this.Close();

            }
            else
            {
                Customer customer = new Customer();
                customer.DisplayName = txtName.Text;
                customer.Phone = txtPhone.Text;
                customer.Email = txtEmail.Text;
                customer.Adress = txtAdress.Text;
                customer.ContractDate = txtContractDate.Value;
                customer.MoreInfo = txtMoreInfo.Text;
                customer.Status = chkSatus.Checked;
                db.Customers.InsertOnSubmit(customer);

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
