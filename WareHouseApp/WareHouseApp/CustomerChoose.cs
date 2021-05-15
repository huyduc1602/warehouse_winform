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
    public partial class CustomerChoose : Form
    {
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public int Id { get; set; }
        public CustomerChoose()
        {
            InitializeComponent();
        }

        private void CustomerChoose_Load(object sender, EventArgs e)
        {
            dgvCustomer.ColumnCount = 8;

            dgvCustomer.Columns[0].HeaderText = "Mã";
            dgvCustomer.Columns[0].DataPropertyName = "Id";

            dgvCustomer.Columns[1].HeaderText = "Tên";
            dgvCustomer.Columns[1].DataPropertyName = "DisplayName";

            dgvCustomer.Columns[2].HeaderText = "Số điện thoại";
            dgvCustomer.Columns[2].DataPropertyName = "Phone";

            dgvCustomer.Columns[3].HeaderText = "Email";
            dgvCustomer.Columns[3].DataPropertyName = "Email";

            dgvCustomer.Columns[4].HeaderText = "Địa chỉ";
            dgvCustomer.Columns[4].DataPropertyName = "Address";

            dgvCustomer.Columns[5].HeaderText = "Ghi chú";
            dgvCustomer.Columns[5].DataPropertyName = "MoreInfo";

            dgvCustomer.Columns[6].HeaderText = "Ngày tạo";
            dgvCustomer.Columns[6].DataPropertyName = "ContractDate";

            dgvCustomer.Columns[7].HeaderText = "Trạng thái";
            dgvCustomer.Columns[7].DataPropertyName = "Status";


            dgvCustomer.DataSource = from c in db.Customers
                                     select new
                                     {
                                         Id = c.Id,
                                         DisplayName = c.DisplayName,
                                         Phone = c.Phone,
                                         Email = c.Email,
                                         Address = c.Adress,
                                         MoreInfo = c.MoreInfo,
                                         ContractDate = c.ContractDate,
                                         Status = (bool)c.Status ? "Kích hoạt" : "Ẩn"
                                     };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                int id = (int)dgvCustomer.CurrentRow.Cells[0].Value;
                Id = id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
