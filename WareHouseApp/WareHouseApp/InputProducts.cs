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
    public partial class InputProducts : Form
    {
        List<InputDetail> inputDetails = new List<InputDetail>();
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        int maxIdInput;
        public InputProducts()
        {
            InitializeComponent();
            txtTitle.Text = "Nhập hàng ngày " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            //Tạo mơi input
            Input input = new Input();
            input.DisplayName = txtTitle.Text;
            input.InputDate = txtDate.Value;
            input.TotalQuantity = 0;
            input.TotalPrice = 0;
            db.Inputs.InsertOnSubmit(input);
            db.SubmitChanges();
            maxIdInput = db.Inputs.OrderByDescending(x => x.Id).First().Id;
        }       

        private void InputProducts_Load(object sender, EventArgs e)
        {
            loadTable();
                       
        }
        private void loadTable()
        {
            this.dgvInputDetail.DataSource = null;
            this.dgvInputDetail.Rows.Clear();
            this.dgvInputDetail.Columns.Clear();
            dgvInputDetail.ColumnCount = 6;

            dgvInputDetail.Columns[0].HeaderText = "SKU";
            dgvInputDetail.Columns[0].DataPropertyName = "Sku";

            dgvInputDetail.Columns[1].HeaderText = "Tên sản phẩm";
            dgvInputDetail.Columns[1].DataPropertyName = "DisplayName";

            dgvInputDetail.Columns[2].HeaderText = "Số lượng";
            dgvInputDetail.Columns[2].DataPropertyName = "Count";

            dgvInputDetail.Columns[3].HeaderText = "Giá nhập";
            dgvInputDetail.Columns[3].DataPropertyName = "PurchasePrice";

            dgvInputDetail.Columns[4].HeaderText = "Giá bán";
            dgvInputDetail.Columns[4].DataPropertyName = "Price";

            dgvInputDetail.Columns[5].HeaderText = "Đơn vị";
            dgvInputDetail.Columns[5].DataPropertyName = "Cái";

            foreach (var i in inputDetails)
            {
                var p = db.Products.SingleOrDefault(x => x.Id == i.ProductId);
                string[] row = new string[] {i.ProductId.ToString(),p.DisplayName,i.Quantity.ToString(),p.PurchasePrice.ToString(),i.Price.ToString(),p.Unit.DisplayName
                    };
                dgvInputDetail.Rows.Add(row);
            }

        }
        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }

        private void btnProductChoose_Click(object sender, EventArgs e)
        {
            ProductChoose productChoose = new ProductChoose();
            if (productChoose.ShowDialog() == DialogResult.OK)
            {
                txtProductId.Text = productChoose.Id.ToString();
                txtPrice.Text = productChoose.PurchasePrice.ToString();                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //tạo mới detail
            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                InputDetail inputDetail = new InputDetail();
                inputDetail.ProductId = Convert.ToInt32(txtProductId.Text);
                inputDetail.Price = Convert.ToDouble(txtPrice.Text);
                inputDetail.Quantity = Convert.ToInt32(txtQuantity.Value);
                inputDetail.InputId = maxIdInput;

                //thêm vào list detail
                inputDetails.Add(inputDetail);
                //dgvInputDetail.Rows.Add(inputDetail);
                loadTable();

                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 mã sản phẩm");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (inputDetails.Count > 0)
            {
                db.InputDetails.InsertAllOnSubmit(inputDetails);
                db.SubmitChanges();
                foreach (var ip in inputDetails)
                {
                    var p = ip.Product;
                    var input = ip.Input;
                    input.DisplayName = txtTitle.Text;
                    input.TotalQuantity += ip.Quantity;
                    input.TotalPrice += p.PurchasePrice * ip.Quantity;
                }
                db.SubmitChanges();
            }
            
            db.Connection.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var inputLast = db.Inputs.SingleOrDefault(x => x.Id == maxIdInput);
            db.Inputs.DeleteOnSubmit(inputLast);
            db.SubmitChanges();
            db.Connection.Close();
            this.Close();
        }


    }
}
