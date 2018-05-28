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
    public partial class PayrollMDI : Form
    {
        public PayrollMDI()
        {
            InitializeComponent();
        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm objEmployeeForm = new EmployeeForm();
            objEmployeeForm.MdiParent = this;
            objEmployeeForm.Show();
        }

        private void payrollCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollCalculator objPayrollCalculator = new PayrollCalculator();
            objPayrollCalculator.MdiParent = this;
            objPayrollCalculator.Visible = true;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageEmployeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeeForm objEmployeeForm = new EmployeeForm();
            objEmployeeForm.MdiParent = this;
            objEmployeeForm.Show();
        }
        PayrollCalculator objPayrollCalculator = null;
        private void payrollCalculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (objPayrollCalculator == null)
            {
                objPayrollCalculator = new PayrollCalculator();
                objPayrollCalculator.MdiParent = this;
                objPayrollCalculator.FormClosed += ObjPayrollCalculator_FormClosed;
                objPayrollCalculator.Visible = true;
            }
            else
            {
                objPayrollCalculator.Activate();
            }
            
        }

        private void ObjPayrollCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPayrollCalculator = null;
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void aboutPayrollApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPayrollSystem objAbout = new AboutPayrollSystem();
            objAbout.MdiParent = this;
            objAbout.Show();
        }

        private void allEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllEmployee objAllEmployee = new AllEmployee();
            objAllEmployee.MdiParent = this;
            objAllEmployee.Visible = true;
        }

        private void allPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllPayments objAllPayments = new AllPayments();
            objAllPayments.MdiParent = this;
            objAllPayments.Show();
        }

        private void currentMonthPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentMonthPayments objCurrentMonth = new CurrentMonthPayments();
            objCurrentMonth.MdiParent = this;
            objCurrentMonth.Show();
        }

        private void registerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterUser objRegisterUser = new RegisterUser();
            objRegisterUser.MdiParent = this;
            objRegisterUser.Show();
        }

        private void PayrollMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult objDialog = MessageBox.Show("Are you sure you want to exit this application", "Form Closing....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (objDialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                LogIn objLogIn = new LogIn();
                objLogIn.Visible = true;
            }
        }
    }
}
