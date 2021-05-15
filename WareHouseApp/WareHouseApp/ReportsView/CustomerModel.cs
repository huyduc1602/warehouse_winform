using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApp.Reports
{
    class CustomerModel
    {
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime ContractDate { get; set; }
        public string Status { get; set; }
        public CustomerModel()
        {

        }
        public CustomerModel(string name, string phone, string email, string adress, DateTime contractDate, string status)
        {
            DisplayName = name;
            Phone = phone;
            Email = email;
            Adress = adress;
            ContractDate = contractDate;
            Status = status;
        }
    }
}
