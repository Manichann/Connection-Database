using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Connect_Database
{
    public partial class employee : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnection dbcon = new DbConnection();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public employee()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }


        private void employee_Load(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from tbRole",cn);
                dr= cmd.ExecuteReader();
                dt.Columns.Add("Role", typeof(string));
                dt.Load(dr);
                cmbRole.ValueMember = "Role";
                cmbRole.DataSource= dt;
                cn.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Employee values(@empID,@empFName,@empLName,@empPhone,@empEmail,@empAddr)",cn);
            cmd.Parameters.AddWithValue("@empID", txtID.Text);
            cmd.Parameters.AddWithValue("@empFName", txtFName.Text);
            cmd.Parameters.AddWithValue("@empLName", txtLName.Text);
            cmd.Parameters.AddWithValue("@empPhone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@empEmail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@empAddr", txtAddr.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Employee added", "Imformation");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            cn.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Employee set empFName=@empFName,empLName=@empLName,empPhone=@empPhone,empEmail=@empEmail,empAddr=@empAddr where empID=@empID", cn);
            cmd.Parameters.AddWithValue("@empID", txtID.Text);
            cmd.Parameters.AddWithValue("@empFName", txtFName.Text);
            cmd.Parameters.AddWithValue("@empLName", txtLName.Text);
            cmd.Parameters.AddWithValue("@empPhone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@empEmail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@empAddr", txtAddr.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Employee updated", "Imformation");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete tbl_Employee where empID=@empID",cn);
            cmd.Parameters.AddWithValue("@empID", txtID.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee deleted", "Imformation");
        }
    }
}
