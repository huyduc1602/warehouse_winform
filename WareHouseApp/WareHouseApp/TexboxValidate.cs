using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseApp
{
    public partial class TexboxValidate : UserControl
    {
        public string FieldName { get; set; }
        public string Pattern { get; set; }
        public TexboxValidate()
        {
            InitializeComponent();
            lblValidate.Text = "";
        }

        public override string Text { get => txtValidate.Text; set => txtValidate.Text = value; }


        private void txtValidate_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtValidate.Text))
            {
                e.Cancel = true;
                lblValidate.Text = $"{FieldName} không được bỏ trống";
                return;
            }
            if (!String.IsNullOrEmpty(Pattern))
            {
                if (!Regex.IsMatch(txtValidate.Text,Pattern))
                {
                    e.Cancel = true;
                    lblValidate.Text = $"{FieldName} không hợp lệ";
                    return;
                }
               
            }
        }

        private void TexboxValidate_Load(object sender, EventArgs e)
        {

        }
    }
}
