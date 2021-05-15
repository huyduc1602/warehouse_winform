using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApp.Reports;

namespace WareHouseApp
{
    public partial class WareHouses : Form
    {
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        Color bgHover = Color.FromArgb(226, 201, 67);//default colour
        Color textHover = System.Drawing.Color.FromArgb(255, 255, 255);//default colour
        public string Table { get; set; }
        public static string Action { get; set; }
        public WareHouses()
        {
            InitializeComponent();
            dgvTable.AutoGenerateColumns = false;
            Table = "Product";
            pnlCustomerSearch.Visible = false;
            LoadTable();
        }

        private void WareHouses_Load(object sender, EventArgs e)
        {
                       
        }
        private void LoadTable()
        {
            switch (Table)
            {
                case "Product":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dgvTable.ColumnCount = 13;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "SKU";
                    dgvTable.Columns[1].DataPropertyName = "Sku";

                    dgvTable.Columns[2].HeaderText = "Tên";
                    dgvTable.Columns[2].DataPropertyName = "DisplayName";

                    dgvTable.Columns[3].HeaderText = "Số lượng";
                    dgvTable.Columns[3].DataPropertyName = "Quantity";

                    dgvTable.Columns[4].HeaderText = "Giá nhập";
                    dgvTable.Columns[4].DataPropertyName = "PurchasePrice";

                    dgvTable.Columns[5].HeaderText = "Giá bán";
                    dgvTable.Columns[5].DataPropertyName = "Price";

                    dgvTable.Columns[6].HeaderText = "Đơn vị";
                    dgvTable.Columns[6].DataPropertyName = "Unit";

                    dgvTable.Columns[7].HeaderText = "Danh mục";
                    dgvTable.Columns[7].DataPropertyName = "Category";

                    dgvTable.Columns[8].HeaderText = "Hãng";
                    dgvTable.Columns[8].DataPropertyName = "Brand";

                    dgvTable.Columns[9].HeaderText = "Nhà cung cấp";
                    dgvTable.Columns[9].DataPropertyName = "Supplier";

                    dgvTable.Columns[10].HeaderText = "Ảnh sản phẩm";
                    dgvTable.Columns[10].DataPropertyName = "Image";

                    dgvTable.Columns[11].HeaderText = "Ghi chú";
                    dgvTable.Columns[11].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[12].HeaderText = "Trạng thái";
                    dgvTable.Columns[12].DataPropertyName = "Status";

                    dgvTable.DataSource = from p in db.Products
                                          select new
                                          {
                                              Id = p.Id,
                                              Sku = p.Sku,
                                              DisplayName = p.DisplayName,
                                              Quantity = p.Quantity,
                                              PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                              Price = string.Format("{0:N0}", p.Price),
                                              Unit = p.Unit.DisplayName,
                                              Category = p.Category.DisplayName,
                                              Brand = p.Brand.DisplayName,
                                              Supplier = p.Suplier.DisplayName,
                                              Image = p.Image,
                                              MoreInfo = p.MoreInfo,
                                              Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                          };
                    break;
                case "Categories":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 4;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Ghi chú";
                    dgvTable.Columns[2].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[3].HeaderText = "Trạng thái";
                    dgvTable.Columns[3].DataPropertyName = "Status";

                    
                    dgvTable.DataSource = from c in db.Categories
                                          select new
                                          {
                                              Id = c.Id,
                                              DisplayName = c.DisplayName,
                                              MoreInfo = c.MoreInfo,
                                              Status = (bool)c.Status ? "Kích hoạt" : "Ẩn",
                                          };
                    break;
                case "Brand":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 4;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";
                    dgvTable.Columns[1].Width = 200;

                    dgvTable.Columns[2].HeaderText = "Ghi chú";
                    dgvTable.Columns[2].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[3].HeaderText = "Trạng thái";
                    dgvTable.Columns[3].DataPropertyName = "Status";

                    dgvTable.DataSource = from b in db.Brands
                                          select new
                                          {
                                              Id = b.Id,
                                              DisplayName = b.DisplayName,
                                              MoreInfo = b.MoreInfo,
                                              Status = (bool)b.Status ? "Kích hoạt" : "Ẩn"
                                          };
                    break;
                case "Supplier":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 9;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Mã số thuế";
                    dgvTable.Columns[2].DataPropertyName = "TaxCode";

                    dgvTable.Columns[3].HeaderText = "Số tài khoản";
                    dgvTable.Columns[3].DataPropertyName = "AccountNumber";

                    dgvTable.Columns[4].HeaderText = "Số điện thoại";
                    dgvTable.Columns[4].DataPropertyName = "Phone";

                    dgvTable.Columns[5].HeaderText = "Email";
                    dgvTable.Columns[5].DataPropertyName = "Email";

                    dgvTable.Columns[6].HeaderText = "Địa chỉ";
                    dgvTable.Columns[6].DataPropertyName = "Address";

                    dgvTable.Columns[7].HeaderText = "Ghi chú";
                    dgvTable.Columns[7].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[8].HeaderText = "Trạng thái";
                    dgvTable.Columns[8].DataPropertyName = "Status";

                    
                    dgvTable.DataSource = from s in db.Supliers
                                          select new
                                          {
                                              Id = s.Id,
                                              DisplayName = s.DisplayName,
                                              TaxCode = s.TaxCode,
                                              AccountNumber = s.AcountNumber,
                                              Phone = s.Phone,
                                              Email = s.Email,
                                              Address = s.Adress,
                                              MoreInfo = s.MoreInfo,
                                              Status = (bool)s.Status ? "Kích hoạt" : "Ẩn"
                                          };
                    break;
                case "Customer":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 8;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Số điện thoại";
                    dgvTable.Columns[2].DataPropertyName = "Phone";

                    dgvTable.Columns[3].HeaderText = "Email";
                    dgvTable.Columns[3].DataPropertyName = "Email";

                    dgvTable.Columns[4].HeaderText = "Địa chỉ";
                    dgvTable.Columns[4].DataPropertyName = "Address";

                    dgvTable.Columns[5].HeaderText = "Ghi chú";
                    dgvTable.Columns[5].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[6].HeaderText = "Ngày tạo";
                    dgvTable.Columns[6].DataPropertyName = "ContractDate";

                    dgvTable.Columns[7].HeaderText = "Trạng thái";
                    dgvTable.Columns[7].DataPropertyName = "Status";


                    dgvTable.DataSource = from c in db.Customers
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
                    break;
                case "Input":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;

                    dgvTable.ColumnCount = 6;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên phiếu";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Số lượng nhập";
                    dgvTable.Columns[2].DataPropertyName = "TotalQuantity";

                    dgvTable.Columns[3].HeaderText = "Tổng giá";
                    dgvTable.Columns[3].DataPropertyName = "TotalPrice";

                    dgvTable.Columns[4].HeaderText = "Ngày nhập";
                    dgvTable.Columns[4].DataPropertyName = "InputDate";

                    dgvTable.Columns[5].HeaderText = "Trạng thái";
                    dgvTable.Columns[5].DataPropertyName = "Status";


                    dgvTable.DataSource = from i in db.Inputs orderby i.Id descending
                                          select new
                                          {
                                              Id = i.Id,
                                              DisplayName = i.DisplayName,
                                              TotalQuantity = i.TotalQuantity,
                                              TotalPrice = i.TotalPrice,
                                              InputDate = i.InputDate,
                                              Status = (bool)i.Status ? "Đã nhập" : "Chờ Duyệt"
                                          };
                    break;
                case "Output":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;

                    dgvTable.ColumnCount = 7;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên phiếu";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Tên khách hàng";
                    dgvTable.Columns[2].DataPropertyName = "CustomerName";

                    dgvTable.Columns[3].HeaderText = "Số lượng xuất";
                    dgvTable.Columns[3].DataPropertyName = "TotalQuantity";

                    dgvTable.Columns[4].HeaderText = "Tổng giá";
                    dgvTable.Columns[4].DataPropertyName = "TotalPrice";

                    dgvTable.Columns[5].HeaderText = "Ngày xuát";
                    dgvTable.Columns[5].DataPropertyName = "OutputDate";

                    dgvTable.Columns[6].HeaderText = "Trạng thái";
                    dgvTable.Columns[6].DataPropertyName = "Status";


                    dgvTable.DataSource = from o in db.Outputs
                                          orderby o.Id descending
                                          select new
                                          {
                                              Id = o.Id,
                                              DisplayName = o.DisplayName,
                                              CustomerName = o.Customer.DisplayName,
                                              TotalQuantity = o.TotalQuantity,
                                              TotalPrice = o.TotalPrice,
                                              OutputDate = o.OutputDate,
                                              Status = (bool)o.Status ? "Đã xuất" : "Chờ Duyệt"
                                          };
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn 1 bảng");
                    break;
            }
        }
        private void lblProduct_Click(object sender, EventArgs e)
        {
            Table = "Product";
            tsbLabelAdd.Text = "Thêm";
            pnlProductCodeSearch.Visible = true;
            pnlProductNameSearch.Visible = true;
            pnlSuplierSearch.Visible = true;
            pnlBrandSearch.Visible = true;
            pnlCategorySearch.Visible = true;
            pnlCustomerSearch.Visible = false;
            LoadTable();
        }

        private void lblCategories_Click(object sender, EventArgs e)
        {
            Table = "Categories";
            tsbLabelAdd.Text = "Thêm";
            pnlProductCodeSearch.Visible = false;
            pnlProductNameSearch.Visible = false;
            pnlSuplierSearch.Visible = false;
            pnlBrandSearch.Visible = false;
            pnlCategorySearch.Visible = true;
            pnlCustomerSearch.Visible = false;
            LoadTable();
        }

        private void lblBrand_Click(object sender, EventArgs e)
        {
            Table = "Brand";
            tsbLabelAdd.Text = "Thêm";
            pnlProductCodeSearch.Visible = false;
            pnlProductNameSearch.Visible = false;
            pnlSuplierSearch.Visible = false;
            pnlBrandSearch.Visible = true;
            pnlCategorySearch.Visible = false;
            pnlCustomerSearch.Visible = false;
            LoadTable();
        }

        private void lblSupplier_Click(object sender, EventArgs e)
        {
            Table = "Supplier";
            tsbLabelAdd.Text = "Thêm";
            pnlProductCodeSearch.Visible = false;
            pnlProductNameSearch.Visible = false;
            pnlSuplierSearch.Visible = true;
            pnlBrandSearch.Visible = false;
            pnlCategorySearch.Visible = false;
            pnlCustomerSearch.Visible = false;
            LoadTable();
        }
        private void lblCustomer_Click(object sender, EventArgs e)
        {
            Table = "Customer";
            tsbLabelAdd.Text = "Thêm";
            pnlProductCodeSearch.Visible = false;
            pnlProductNameSearch.Visible = false;
            pnlSuplierSearch.Visible = false;
            pnlBrandSearch.Visible = false;
            pnlCategorySearch.Visible = false;
            pnlCustomerSearch.Visible = true;
            LoadTable();
        }
        private void openFormTable(string tableName, DataGridViewRow row, string action)
        {
            switch (tableName)
            {
                case "Product":
                    Products product = new Products();
                    if (row != null)
                    {
                        product.Id = (int)row.Cells[0].Value;
                    }
                    product.Action = action;
                    if (product.ShowDialog() == DialogResult.OK)
                    {
                        LoadTable();
                    }
                    break;
                case "Categories":
                    Categories categories = new Categories();
                    if (row != null)
                    {
                        categories.Id = (int)row.Cells[0].Value;
                    }
                    categories.Action = action;
                    if (categories.ShowDialog() == DialogResult.OK)
                    {
                        LoadTable();
                    }
                    break;
                case "Brand":
                    Brands brand = new Brands();
                    if (row != null)
                    {
                        brand.Id = (int)row.Cells[0].Value;

                    }
                    brand.Action = action;
                    
                    if(brand.ShowDialog() == DialogResult.OK)
                    {
                        LoadTable();
                    }
                    break;
                case "Supplier":
                    Suppliers supplier = new Suppliers();
                    if (row != null)
                    {
                        supplier.Id = (int)row.Cells[0].Value;
                    }
                    supplier.Action = action;
                    if (supplier.ShowDialog() == DialogResult.OK)
                    {
                        LoadTable();
                    }
                    break;
                case "Customer":
                    Customers customer = new Customers();
                    if (row != null)
                    {
                        customer.Id = (int)row.Cells[0].Value;
                    }
                    customer.Action = action;
                    if (customer.ShowDialog() == DialogResult.OK)
                    {
                        LoadTable();
                    }
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn 1 bảng");
                    break;
            }
        }
        private void DeleteForm()
        {
            if (dgvTable.CurrentRow != null)
            {
                var row = dgvTable.CurrentRow;
                Action = "delete";
                if (MessageBox.Show("Bạn có chắc muốn xóa nó !", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {                                      
                    switch (Table)
                    {
                        case "Product":
                            var p = db.Products.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                           
                            bool checkDelete = true;
                            List<InputDetail> lip = db.InputDetails.ToList();
                            foreach (var item in lip)
                            {
                                if (item.ProductId == p.Id)
                                {
                                    checkDelete = false;
                                    MessageBox.Show("Sản phẩm được nhập từ phiếu không thể xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    break;
                                }
                            }
                            List<OutputDetail> lop = db.OutputDetails.ToList();
                            foreach (var item in lop)
                            {
                                if (item.ProductId == p.Id)
                                {
                                    checkDelete = false;
                                    MessageBox.Show("Sản phẩm được xuất từ phiếu không thể xóa","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    break;
                                }
                            }
                            if (checkDelete)
                            {
                                db.Products.DeleteOnSubmit(p);
                                db.SubmitChanges();
                            }
                            break;
                        case "Categories":
                            var ca = db.Categories.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            db.Categories.DeleteOnSubmit(ca);
                            db.SubmitChanges();
                            break;
                        case "Brand":
                            var b = db.Brands.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            db.Brands.DeleteOnSubmit(b);
                            db.SubmitChanges();
                            break;
                        case "Supplier":
                            var s = db.Supliers.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            db.Supliers.DeleteOnSubmit(s);
                            db.SubmitChanges();
                            break;
                        case "Customer":
                            var cu = db.Customers.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            db.Customers.DeleteOnSubmit(cu);
                            db.SubmitChanges();
                            break;
                        case "Input":
                            var ip = db.Inputs.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            List<InputDetail> inputDetails = ip.InputDetails.ToList();
                            db.InputDetails.DeleteAllOnSubmit(inputDetails);
                            db.Inputs.DeleteOnSubmit(ip);
                            db.SubmitChanges();
                            break;
                        case "Output":
                            var op = db.Outputs.SingleOrDefault(x => x.Id == (int)row.Cells[0].Value);
                            db.Outputs.DeleteOnSubmit(op);
                            db.SubmitChanges();
                            break;
                        default:
                            MessageBox.Show("Vui lòng chọn 1 bảng");
                            break;
                    }
                    
                    LoadTable();
                }

            }
            else
            {
                MessageBox.Show("Chưa có dòng nào được chọn", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
           
            if (Table == "Input")
            {
                ImportBill();
            }
            else if(Table == "Output")
            {
                ExportBill();
            }
            else
            {
                DataGridViewRow row = null;
                Action = "add";
                openFormTable(Table, row, Action);
            }
        }

        private void tsbSee_Click(object sender, EventArgs e)
        {
            if (dgvTable.CurrentRow != null)
            {
                var row = dgvTable.CurrentRow;
                Action = "see";
                openFormTable(Table, row, Action);
            }
            else
            {
                MessageBox.Show("Chưa có dòng nào được chọn", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvTable.CurrentRow != null)
            {
                var row = dgvTable.CurrentRow;
                Action = "edit";
                openFormTable(Table, row, Action);
            }else{
                MessageBox.Show("Chưa có dòng nào được chọn", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteForm();

        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            tsbLabelAdd.Text = "Nhập";
            Table = "Input";
            LoadTable();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            tsbLabelAdd.Text = "Xuất";
            Table = "Output";
            LoadTable();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmProductReport frmProductReport = new frmProductReport();
            frmProductReport.Table = Table;
            frmProductReport.ShowDialog();
        }

        private void tsbBillImport_Click(object sender, EventArgs e)
        {
            InputProducts inputProducts = new InputProducts();
            if (inputProducts.ShowDialog() == DialogResult.OK)
            {
                LoadTable();
            }
        }

        private void tsbBillExport_Click(object sender, EventArgs e)
        {
            OutputProducts outputProducts = new OutputProducts();
            if (outputProducts.ShowDialog() == DialogResult.OK)
            {
                LoadTable();
            }
        }

        private void ImportBill()
        {
            if (dgvTable.CurrentRow != null)
            {
                int inputId = (int)dgvTable.CurrentRow.Cells[0].Value;
                var input = db.Inputs.SingleOrDefault(x => x.Id == inputId);
                if (!input.Status)
                {
                    List<InputDetail> listDetail = db.InputDetails.Where(x => x.InputId == inputId).ToList();
                    foreach (var ipd in listDetail)
                    {
                        var proIp = db.Products.SingleOrDefault(x => x.Id == ipd.ProductId);
                        proIp.Quantity += ipd.Quantity;
                        db.SubmitChanges();
                    }
                    input.Status = true;
                    db.SubmitChanges();
                    if (input.Status)
                    {
                        MessageBox.Show("Cảm ơn bạn . Đơn hàng đã nhập thành công !", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTable();
                    }
                }
                else
                {
                    MessageBox.Show("Đơn hàng này đã được nhập. Không thể nhập lại đơn hàng !", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            else
            {
                MessageBox.Show("Chưa có dòng nào được chọn", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ExportBill()
        {
            if (dgvTable.CurrentRow != null)
            {
                int outputId = (int)dgvTable.CurrentRow.Cells[0].Value;                
                var output = db.Outputs.SingleOrDefault(x => x.Id == outputId);
                if (!output.Status)
                {
                    List<OutputDetail> listDetail = db.OutputDetails.Where(x => x.OutputId == outputId).ToList();
                    foreach (var opd in listDetail)
                    {
                        var proIp = db.Products.SingleOrDefault(x => x.Id == opd.ProductId);
                        if (proIp.Quantity < opd.Quantity)
                        {
                            MessageBox.Show("Sản phẩm " + proIp.DisplayName + "không đủ. Không thể xuất đơn hàng !", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            proIp.Quantity -= opd.Quantity;
                            output.Status = true;
                            db.SubmitChanges();
                        }
                        
                    }
                    if (output.Status)
                    {
                        MessageBox.Show("Cảm ơn bạn . Đơn hàng đã xuất thành công !", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTable();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Đơn hàng này đã xuất. Không thể xuất lại đơn hàng !", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có dòng nào được chọn", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SearchByOption(string option)
        {
            switch (Table)
            {
                case "Product":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dgvTable.ColumnCount = 13;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "SKU";
                    dgvTable.Columns[1].DataPropertyName = "Sku";

                    dgvTable.Columns[2].HeaderText = "Tên";
                    dgvTable.Columns[2].DataPropertyName = "DisplayName";

                    dgvTable.Columns[3].HeaderText = "Số lượng";
                    dgvTable.Columns[3].DataPropertyName = "Quantity";

                    dgvTable.Columns[4].HeaderText = "Giá nhập";
                    dgvTable.Columns[4].DataPropertyName = "PurchasePrice";

                    dgvTable.Columns[5].HeaderText = "Giá bán";
                    dgvTable.Columns[5].DataPropertyName = "Price";

                    dgvTable.Columns[6].HeaderText = "Đơn vị";
                    dgvTable.Columns[6].DataPropertyName = "Unit";

                    dgvTable.Columns[7].HeaderText = "Danh mục";
                    dgvTable.Columns[7].DataPropertyName = "Category";

                    dgvTable.Columns[8].HeaderText = "Hãng";
                    dgvTable.Columns[8].DataPropertyName = "Brand";

                    dgvTable.Columns[9].HeaderText = "Nhà cung cấp";
                    dgvTable.Columns[9].DataPropertyName = "Supplier";

                    dgvTable.Columns[10].HeaderText = "Ảnh sản phẩm";
                    dgvTable.Columns[10].DataPropertyName = "Image";

                    dgvTable.Columns[11].HeaderText = "Ghi chú";
                    dgvTable.Columns[11].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[12].HeaderText = "Trạng thái";
                    dgvTable.Columns[12].DataPropertyName = "Status";
                    if (option == "DisplayName")
                    {
                        dgvTable.DataSource = from p in db.Products
                                              where p.DisplayName.ToLower().Contains(txtProductName.Text.ToLower())
                                              select new
                                              {
                                                  Id = p.Id,
                                                  Sku = p.Sku,
                                                  DisplayName = p.DisplayName,
                                                  Quantity = p.Quantity,
                                                  PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                                  Price = string.Format("{0:N0}", p.Price),
                                                  Unit = p.Unit.DisplayName,
                                                  Category = p.Category.DisplayName,
                                                  Brand = p.Brand.DisplayName,
                                                  Supplier = p.Suplier.DisplayName,
                                                  Image = p.Image,
                                                  MoreInfo = p.MoreInfo,
                                                  Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                              };
                    }else if(option == "Sku"){
                        dgvTable.DataSource = from p in db.Products
                                              where p.Sku.ToLower().Contains(txtProductSku.Text.ToLower())
                                              select new
                                              {
                                                  Id = p.Id,
                                                  Sku = p.Sku,
                                                  DisplayName = p.DisplayName,
                                                  Quantity = p.Quantity,
                                                  PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                                  Price = string.Format("{0:N0}", p.Price),
                                                  Unit = p.Unit.DisplayName,
                                                  Category = p.Category.DisplayName,
                                                  Brand = p.Brand.DisplayName,
                                                  Supplier = p.Suplier.DisplayName,
                                                  Image = p.Image,
                                                  MoreInfo = p.MoreInfo,
                                                  Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                              };
                    } else if (option == "Brand"){
                        dgvTable.DataSource = from p in db.Products
                                              where p.Brand.DisplayName.ToLower().Contains(txtBrand.Text.ToLower())
                                              select new
                                              {
                                                  Id = p.Id,
                                                  Sku = p.Sku,
                                                  DisplayName = p.DisplayName,
                                                  Quantity = p.Quantity,
                                                  PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                                  Price = string.Format("{0:N0}", p.Price),
                                                  Unit = p.Unit.DisplayName,
                                                  Category = p.Category.DisplayName,
                                                  Brand = p.Brand.DisplayName,
                                                  Supplier = p.Suplier.DisplayName,
                                                  Image = p.Image,
                                                  MoreInfo = p.MoreInfo,
                                                  Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                              };
                    }else if (option == "Suplier")
                    {
                        dgvTable.DataSource = from p in db.Products
                                              where p.Suplier.DisplayName.ToLower().Contains(txtSuplier.Text.ToLower())
                                              select new
                                              {
                                                  Id = p.Id,
                                                  Sku = p.Sku,
                                                  DisplayName = p.DisplayName,
                                                  Quantity = p.Quantity,
                                                  PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                                  Price = string.Format("{0:N0}", p.Price),
                                                  Unit = p.Unit.DisplayName,
                                                  Category = p.Category.DisplayName,
                                                  Brand = p.Brand.DisplayName,
                                                  Supplier = p.Suplier.DisplayName,
                                                  Image = p.Image,
                                                  MoreInfo = p.MoreInfo,
                                                  Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                              };
                    }
                    else if (option == "Category")
                    {
                        dgvTable.DataSource = from p in db.Products
                                              where p.Category.DisplayName.ToLower().Contains(txtCategory.Text.ToLower())
                                              select new
                                              {
                                                  Id = p.Id,
                                                  Sku = p.Sku,
                                                  DisplayName = p.DisplayName,
                                                  Quantity = p.Quantity,
                                                  PurchasePrice = string.Format("{0:N0}", p.PurchasePrice),
                                                  Price = string.Format("{0:N0}", p.Price),
                                                  Unit = p.Unit.DisplayName,
                                                  Category = p.Category.DisplayName,
                                                  Brand = p.Brand.DisplayName,
                                                  Supplier = p.Suplier.DisplayName,
                                                  Image = p.Image,
                                                  MoreInfo = p.MoreInfo,
                                                  Status = p.Quantity == 0 ? "Hết hàng" : "Còn hàng"
                                              };
                    }

                    break;
                case "Categories":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 4;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Ghi chú";
                    dgvTable.Columns[2].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[3].HeaderText = "Trạng thái";
                    dgvTable.Columns[3].DataPropertyName = "Status";


                    dgvTable.DataSource = from c in db.Categories
                                          where c.DisplayName.ToLower().Contains(txtCategory.Text.ToLower())
                                          select new
                                          {
                                              Id = c.Id,
                                              DisplayName = c.DisplayName,
                                              MoreInfo = c.MoreInfo,
                                              Status = (bool)c.Status ? "Kích hoạt" : "Ẩn",
                                          };
                    break;
                case "Brand":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 4;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";
                    dgvTable.Columns[1].Width = 200;

                    dgvTable.Columns[2].HeaderText = "Ghi chú";
                    dgvTable.Columns[2].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[3].HeaderText = "Trạng thái";
                    dgvTable.Columns[3].DataPropertyName = "Status";

                    dgvTable.DataSource = from b in db.Brands
                                          where b.DisplayName.ToLower().Contains(txtBrand.Text.ToLower())
                                          select new
                                          {
                                              Id = b.Id,
                                              DisplayName = b.DisplayName,
                                              MoreInfo = b.MoreInfo,
                                              Status = (bool)b.Status ? "Kích hoạt" : "Ẩn"
                                          };
                    break;
                case "Supplier":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 9;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Mã số thuế";
                    dgvTable.Columns[2].DataPropertyName = "TaxCode";

                    dgvTable.Columns[3].HeaderText = "Số tài khoản";
                    dgvTable.Columns[3].DataPropertyName = "AccountNumber";

                    dgvTable.Columns[4].HeaderText = "Số điện thoại";
                    dgvTable.Columns[4].DataPropertyName = "Phone";

                    dgvTable.Columns[5].HeaderText = "Email";
                    dgvTable.Columns[5].DataPropertyName = "Email";

                    dgvTable.Columns[6].HeaderText = "Địa chỉ";
                    dgvTable.Columns[6].DataPropertyName = "Address";

                    dgvTable.Columns[7].HeaderText = "Ghi chú";
                    dgvTable.Columns[7].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[8].HeaderText = "Trạng thái";
                    dgvTable.Columns[8].DataPropertyName = "Status";


                    dgvTable.DataSource = from s in db.Supliers
                                          where s.DisplayName.ToLower().Contains(txtSuplier.Text.ToLower())
                                          select new
                                          {
                                              Id = s.Id,
                                              DisplayName = s.DisplayName,
                                              TaxCode = s.TaxCode,
                                              AccountNumber = s.AcountNumber,
                                              Phone = s.Phone,
                                              Email = s.Email,
                                              Address = s.Adress,
                                              MoreInfo = s.MoreInfo,
                                              Status = (bool)s.Status ? "Kích hoạt" : "Ẩn"
                                          };
                    break;
                case "Customer":
                    this.dgvTable.DataSource = null;
                    this.dgvTable.Rows.Clear();
                    this.dgvTable.Columns.Clear();
                    this.dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTable.ColumnCount = 8;
                    dgvTable.Columns[0].HeaderText = "Mã";
                    dgvTable.Columns[0].DataPropertyName = "Id";

                    dgvTable.Columns[1].HeaderText = "Tên";
                    dgvTable.Columns[1].DataPropertyName = "DisplayName";

                    dgvTable.Columns[2].HeaderText = "Số điện thoại";
                    dgvTable.Columns[2].DataPropertyName = "Phone";

                    dgvTable.Columns[3].HeaderText = "Email";
                    dgvTable.Columns[3].DataPropertyName = "Email";

                    dgvTable.Columns[4].HeaderText = "Địa chỉ";
                    dgvTable.Columns[4].DataPropertyName = "Address";

                    dgvTable.Columns[5].HeaderText = "Ghi chú";
                    dgvTable.Columns[5].DataPropertyName = "MoreInfo";

                    dgvTable.Columns[6].HeaderText = "Ngày tạo";
                    dgvTable.Columns[6].DataPropertyName = "ContractDate";

                    dgvTable.Columns[7].HeaderText = "Trạng thái";
                    dgvTable.Columns[7].DataPropertyName = "Status";


                    dgvTable.DataSource = from c in db.Customers
                                          where c.DisplayName.ToLower().Contains(txtCustomer.Text.ToLower())
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
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn 1 bảng để tìm kiếm", "Lỗi thao tác" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("DisplayName");
        }

        private void txtProductSku_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("Sku");
        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("Brand");
        }

        private void txtSuplier_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("Suplier");
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("Category");
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            SearchByOption("Customer");
        }
    }
}
