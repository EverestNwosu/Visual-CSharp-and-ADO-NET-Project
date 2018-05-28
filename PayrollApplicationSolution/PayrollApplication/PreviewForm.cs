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
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }
        //Method with Parameters
        public void PreviewEmployeeData(int EmployeeID, string FirstName, string LastName, string Gender, 
                                        string NationalInsurance, string DateOfBirth, string MaritalStatus, 
                                        bool IsMember, string Address, string City, string PostCode, 
                                        string Country, string PhoneNumber, string Email, string Notes)
        {
            _lblEmployeeID.Text = Convert.ToString(EmployeeID);
            _lblFirstName.Text = FirstName;
            _lblLastName.Text = LastName;
            _lblGender.Text = Gender;
            _lblNationalInsuranceNo.Text = NationalInsurance;
            _lblDOB.Text = DateOfBirth;
            _lblMaritalStatus.Text = MaritalStatus;
            _lblUnionMembership.Text = IsMember.ToString();
            _lblAddress.Text = Address;
            _lblCity.Text = City;
            _lblPostCode.Text = PostCode;
            _lblCountry.Text = Country;
            _lblPhoneNumber.Text = PhoneNumber;
            _lblEmail.Text = Email;
            _lblNotes.Text = Notes;
        }
        
    }
}
