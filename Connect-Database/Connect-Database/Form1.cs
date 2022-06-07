using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_Database
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        DbConnection Q = new DbConnection();

        private void employee_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String name, lastname, phone, email, address;
            name = txtFName.Text.ToString();
            lastname = txtLName.Text.ToString();
            phone = txtPhone.Text.ToString();
            email = txtEmail.Text.ToString();
            address = txtAddr.Text.ToString();
            Q.Query("insert into tbl_Employee(empID,empFName,empLName,empPhone,empEmail,empAddr)" +
                "values('" + name + "','" + lastname + "','" + phone + "','" + email + "','" + address + "')");
            MessageBox.Show("Employee added", "Imformation");
        }
    }
}
