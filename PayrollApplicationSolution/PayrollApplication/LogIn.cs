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
using System.Configuration;

namespace PayrollApplication
{
    public partial class LogIn : Form
    {
        private Users objUser2;
        public LogIn()
        {
            InitializeComponent();
        }
        private void UserData()
        {
            objUser2.UserName = txtUserName.Text;
            objUser2.Password = txtPassword.Text;
            objUser2.Role = cmbRoles.Text;
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            GetRoles();
        }
        private void GetRoles()
        {
            //ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            //Connection Object
            SqlConnection objSqlConnection = new SqlConnection(cs);
            //SqlCommand Object
            SqlCommand objSqlCommand = new SqlCommand("spAllUsers", objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                objSqlConnection.Open();
                //Execute command
                SqlDataReader objDataReader = objSqlCommand.ExecuteReader();
                //While DataReader can read, add items to our combo box
                while (objDataReader.Read())
                {
                    cmbRoles.Items.Add(objDataReader[3]);
                }
                objDataReader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                objSqlConnection.Close();
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            objUser2 = new Users();
            UserData();
            try
            {
                if (objUser2.AuthorisedUser())
                {
                    PayrollMDI objPayrollMDI = new PayrollMDI();
                    this.Hide();
                    objPayrollMDI.Show();
                }
                else
                {
                    MessageBox.Show("Unauthorised Credentials Provided!!", "Unauthorised User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
