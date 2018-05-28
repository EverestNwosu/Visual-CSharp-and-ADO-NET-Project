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
    public partial class AllPayments : Form
    {
        public AllPayments()
        {
            InitializeComponent();
        }

        private void AllPayments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PayrollSystemDBDataSet1.tblPayRecords' table. You can move, or remove it, as needed.
            this.tblPayRecordsTableAdapter.Fill(this.PayrollSystemDBDataSet1.tblPayRecords);

            this.reportViewer1.RefreshReport();
        }
    }
}
