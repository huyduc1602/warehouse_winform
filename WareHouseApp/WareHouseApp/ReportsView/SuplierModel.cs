using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApp.Reports
{
    class SuplierModel
    {
        public string DisplayName { get; set; }

        public string TaxCode { get; set; }
        public string AccountNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime ContractDate { get; set; }
        public string Status { get; set; }
        public SuplierModel()
        {

        }
        public SuplierModel(string displayName, string taxCode, string accountNumber, string phone, string email, string adress, DateTime contractDate, string status)
        {
            DisplayName = displayName;
            TaxCode = taxCode;
            AccountNumber = accountNumber;
            Phone = phone;
            Email = email;
            Adress = adress;
            ContractDate = contractDate;
            Status = status;
        }
    }
}
