using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApp.ReportsView;

namespace WareHouseApp.Reports
{
    public partial class frmProductReport : Form
    {
        public string Table { get; set; }
        WARE_HOUSE_DBDataContext db = new WARE_HOUSE_DBDataContext();
        public int Id { get; set; }
        public frmProductReport()
        {
            InitializeComponent();
        }

        private void frmProductReport_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void LoadTable()
        {
            if (!String.IsNullOrEmpty(Table))
            {
                switch (Table)
                {
                    case "Product":
                        List<ProductModel> productModels = new List<ProductModel>();
                        ProductReport rpt = new ProductReport();
                        var data = from p in db.Products
                                   select new ProductModel
                                   {
                                       Sku = p.Sku,
                                       DisplayName = p.DisplayName,
                                       Quantity = (int)p.Quantity,
                                       PurcharePrice = p.PurchasePrice,
                                       Price = (double)p.Price,
                                       Unit = p.Unit.DisplayName,
                                       Brand = p.Brand.DisplayName,
                                       Category = p.Category.DisplayName,
                                       Supplier = p.Suplier.DisplayName,
                                       Status = p.Quantity == 0 ?"Hết hàng":"Còn hàng"
                                   };
                        rpt.SetDataSource(data);

                        crvReport.ReportSource = rpt;
                        crvReport.Show();
                        break;
                    case "Categories":
                        List<CategoriesModel> categoriesModels = new List<CategoriesModel>();
                        CategoriesReport rpc = new CategoriesReport();
                        var datac = from c in db.Categories
                                    select new CategoriesModel
                                    {
                                        Id = c.Id,
                                        DisplayName = c.DisplayName,
                                        Status = c.Status ? "Kích hoạt" : "Ẩn"
                                    };
                        rpc.SetDataSource(datac);

                        crvReport.ReportSource = rpc;
                        crvReport.Show();
                        break;
                    case "Brand":
                        List<BrandModel> brandModels = new List<BrandModel>();
                        BrandReport rpb = new BrandReport();
                        var datab = from b in db.Brands
                                    select new BrandModel
                                    {
                                        Id = b.Id,
                                        DisplayName = b.DisplayName,
                                        Status = b.Status ? "Kích hoạt" : "Ẩn"
                                    };
                        rpb.SetDataSource(datab);

                        crvReport.ReportSource = rpb;
                        crvReport.Show();
                        break;
                    case "Supplier":
                        List<SuplierModel> suplierModels = new List<SuplierModel>();
                        SuplierReport rps = new SuplierReport();
                        var datas = from s in db.Supliers
                                    select new SuplierModel
                                    {
                                        DisplayName = s.DisplayName,
                                        TaxCode = s.TaxCode,
                                        AccountNumber = s.AcountNumber,
                                        Phone = s.Phone,
                                        Email = s.Email,
                                        Adress = s.Adress,
                                        ContractDate = s.ContractDate,
                                        Status = s.Status ? "Kích hoạt" : "Ẩn"
                                    };
                        rps.SetDataSource(datas);

                        crvReport.ReportSource = rps;
                        crvReport.Show();
                        break;
                    case "Customer":
                        List<CustomerModel>  customerModels = new List<CustomerModel>();
                        CustomerReport rpcu = new CustomerReport();
                        var datacu = from cu in db.Customers
                                    select new CustomerModel
                                    {
                                        DisplayName = cu.DisplayName,
                                        Phone = cu.Phone,
                                        Email = cu.Email,
                                        Adress = cu.Adress,
                                        ContractDate = (DateTime)cu.ContractDate,
                                        Status = cu.Status ? "Kích hoạt" : "Ẩn"
                                    };
                        rpcu.SetDataSource(datacu);

                        crvReport.ReportSource = rpcu;
                        crvReport.Show();
                        break;
                    case "Input":
                        InputReport rpi = new InputReport();
                        var datai = from i in db.InputDetails
                                     select new
                                     {
                                         Id = i.Input.Id,
                                         DisplayName = i.Input.DisplayName,
                                         InputDate = i.Input.InputDate,
                                         Status = i.Input.Status ? "Đã nhập" : "Chờ duyệt",
                                         ProductId1 = i.ProductId,
                                         Quantity1 = i.Quantity,
                                         Price1 = i.Price
                                     };
                        rpi.SetDataSource(datai);

                        crvReport.ReportSource = rpi;
                        crvReport.Show();
                        break;
                    case "Output":
                        break;
                    default:
                         MessageBox.Show("Vui lòng chọn 1 bảng");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Lỗi thao tác", "Vui lòng chọn 1 bảng để in !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
    }
}
