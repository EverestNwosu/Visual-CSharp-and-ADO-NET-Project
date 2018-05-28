using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollApplication
{
    class Users
    {
        //Class variables or Field Members
        private string userName;
        private string password; 
        private string role;
        private string description;
        
        //Default Constructor or Parameterless Constructor
        public Users()
        {

        }

        //Custom Constructor or Parameterised Constructor
        public Users(string userName, string password, string role, string description)
        {
            this.userName = userName;
            this.Password = password;
            this.Role = role;
            this.Description = description;
        }

        //UserName Property
        public string UserName
        {
            get { return userName; } //Read Only
            set { userName = value; } //Write Only
        }
        //Password Property
        public string Password
        {
            get
            {
                return password;
            }

            set
            {               
                 password = value;
            }
        }
        //Role Property
        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
        //RoleDescription Property
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        //Add User Method
        public void AddUser()
        {
            //ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            //Connection Object
            SqlConnection objSqlConnection = new SqlConnection(cs);
            //SqlCommand Object
            SqlCommand objSqlCommand = new SqlCommand("spInsertCommand", objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@UserName", UserName);
            objSqlCommand.Parameters.AddWithValue("@Password", Password);
            objSqlCommand.Parameters.AddWithValue("@Roles", Role);
            objSqlCommand.Parameters.AddWithValue("@Description", Description);
            try
            {
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message, "SQL Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                objSqlConnection.Close();
            }
            MessageBox.Show("New User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Update User Method
        public void UpdateUser()
        {

            //ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            //Connection Object
            SqlConnection objSqlConnection = new SqlConnection(cs);
            //SqlCommand Object
            SqlCommand objSqlCommand = new SqlCommand("spUpdateCommand", objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@UserName", UserName);
            objSqlCommand.Parameters.AddWithValue("@Password", Password);
            objSqlCommand.Parameters.AddWithValue("@Roles", Role);
            objSqlCommand.Parameters.AddWithValue("@Description", Description);
            try
            {
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message, "SQL Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                objSqlConnection.Close();
            }
            MessageBox.Show("User has been updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
   
        //Delete User Method
        public void DeleteUser()
        {

            //ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            //Connection Object
            SqlConnection objSqlConnection = new SqlConnection(cs);
            //SqlCommand Object
            SqlCommand objSqlCommand = new SqlCommand("spDeleteCommand", objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@UserName", UserName);
            
            try
            {
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message, "SQL Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                objSqlConnection.Close();
            }
            MessageBox.Show("User has been deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Authorised User Method
        public bool AuthorisedUser()
        {
            bool isUserAuthorised = false;
            //ConnectionString
            string cs = ConfigurationManager.ConnectionStrings["PayrollSystemDBConnectionString"].ConnectionString;
            //Connection Object
            SqlConnection objSqlConnection = new SqlConnection(cs);
            //SqlCommand Object
            SqlCommand objSqlCommand = new SqlCommand("spIsUserDetailsValid", objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.AddWithValue("@UserName", UserName);
            objSqlCommand.Parameters.AddWithValue("@Password", Password);
            objSqlCommand.Parameters.AddWithValue("@Roles", Role);
            try
            {
                objSqlConnection.Open();
                isUserAuthorised = (bool)objSqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message, "User Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objSqlConnection.Close();
            }

            return isUserAuthorised;
        }
    }
}
