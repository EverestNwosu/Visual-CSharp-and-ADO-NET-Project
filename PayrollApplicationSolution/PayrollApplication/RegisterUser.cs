using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class RegisterUser : Form
    {
        //Class Variable
        private Users objUser;
        public RegisterUser()
        {
            InitializeComponent();
        }
        //Method Validate Controls Data
        private bool isRegisterControlsValid()
        {
            const int minimumLenghtRequired = 8;       
            //UserName Validation
            if (txtRegisterUserName.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter UserName.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterUserName.Focus();
                return false;
            }
            //The password must be a minimum of 8 characters long.
            //The password must contain at least one uppercase letter.
            //The password must contain at least one lowercase letter.
            //The password must contain at least one numeric digit.

            //Pasword Validation
            if (txtRegisterPassword.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter Password.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterPassword.Focus();
                return false;
            }
            else
            {
                //Check if the password characters entered is less than 8 characters
                if (txtRegisterPassword.Text.Length < minimumLenghtRequired  || 
                    //Check the number of Uppercase Characters
                    CheckUpperCase(txtRegisterPassword.Text) < 1 ||
                    //Check the number of Lowercase Characters
                    CheckLowerCase(txtRegisterPassword.Text) < 1 ||
                    //Check the number of Numeric digits
                    CheckNumeric(txtRegisterPassword.Text) < 1)
                {
                    MessageBox.Show("Please, Enter a valid Password. \n\n Hint: \n\t The password must be a minimum of 8 characters long. \n\t The password must contain at least one uppercase letter. \n\t The password must contain at least one lowercase letter. \n\tThe password must contain at least one numeric digit.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return false;
                }
            }
         
            //Confirm Password validation
            if (txtConfirmPassword.Text.Length == 0)
            {
                MessageBox.Show("Please, Confirm Password.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return false;
            }
            else
            {
                //Compare the values of both passwords
                if (txtConfirmPassword.Text != txtRegisterPassword.Text)
                {
                    MessageBox.Show("Both passwords do not match pls, try again!", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return false;
                }
            }
            //Role Validation
            if (txtRoles.Text.Length == 0)
            {
                MessageBox.Show("Please, Enter Role.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRoles.Focus();
                return false;
            }
            return true;
        }
        //Check the number of Numeric digits
        private int CheckNumeric(string strPassword)
        {
            //Variable to hold the number of numeric digits
            int numberOfDigits = 0;
            //Count the number of numeric digits
            foreach (char ch in strPassword)
            {
                //for each numeric character you find
                if (char.IsNumber(ch))
                {
                    //increment the value of numberOfDigits Variable by 1
                    numberOfDigits++;
                }
            }
            //finally return the total number of digits found.
            return numberOfDigits;
        }

        //Check the number of Lowercase
        private int CheckLowerCase(string strPassword)
        {
            //Variable to hold the number of lower case
            int numberOfLowercase = 0;
            //Count the number of lower case
            foreach (char ch in strPassword)
            {
                //for each lowercase character you find
                if (char.IsLower(ch))
                {
                    //increment the value of numberOfLowercase Variable by 1
                    numberOfLowercase++;
                }
            }
            //finally return the total number of lowercase found.
            return numberOfLowercase;
        }
        //Check the number of Uppercase
        private int CheckUpperCase(string strPassword)
        {
            //Variable to hold the number of upper case
            int numberOfUppercase = 0;
            //Count the number of Upper case
            foreach (char ch in strPassword)
            {
                //for each uppercase character you find
                if (char.IsUpper(ch))
                {
                    //increment the value of numberOfUppercase Variable by 1
                    numberOfUppercase++;
                }
            }
            //finally return the total number of uppercase found.
            return numberOfUppercase;
        }

        //Clear Controls Method
        private void ClearControls()
        {
            txtRegisterUserName.Text = "";
            txtRegisterPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtRoles.Text = "";
            txtDescription.Text = "";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult objDialog = MessageBox.Show("Are you sure you want to delete this user's record", "Confirm Record Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (objDialog == DialogResult.Yes)
            {
                objUser = new Users();
                this.UserData();
                if (isRegisterControlsValid())
                {
                    objUser.DeleteUser();

                }
                // TODO: This line of code loads data into the 'payrollSystemDBDataSet2.tblUsers' table. You can move, or remove it, as needed.
                this.tblUsersTableAdapter.Fill(this.payrollSystemDBDataSet2.tblUsers);
                ClearControls();
            }
           
        }
        private void UserData()
        {
            objUser.UserName = txtRegisterUserName.Text;
            objUser.Password = txtRegisterPassword.Text;
            objUser.Role = txtRoles.Text;
            objUser.Description = txtDescription.Text;
        }
        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            objUser = new Users();
            this.UserData();
            if (isRegisterControlsValid())
            {
                objUser.AddUser();

            }
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet2.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.payrollSystemDBDataSet2.tblUsers);
            ClearControls();

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            objUser = new Users();
            this.UserData();
            if (isRegisterControlsValid())
            {
                objUser.UpdateUser();

            }
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet2.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.payrollSystemDBDataSet2.tblUsers);
            ClearControls();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'payrollSystemDBDataSet2.tblUsers' table. You can move, or remove it, as needed.
            this.tblUsersTableAdapter.Fill(this.payrollSystemDBDataSet2.tblUsers);

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = dataGridView1.CurrentRow.Cells;
            txtRegisterUserName.Text = cells[1].Value.ToString();
            txtRegisterPassword.Text = cells[2].Value.ToString();
            txtConfirmPassword.Text = cells[2].Value.ToString();
            txtRoles.Text = cells[3].Value.ToString();
            txtDescription.Text = (string)cells[4].Value;
        }
    }
}
