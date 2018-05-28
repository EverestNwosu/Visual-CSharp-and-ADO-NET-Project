namespace PayrollApplication
{
    partial class CurrentMonthPayments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PayrollSystemDBDataSet1 = new PayrollApplication.PayrollSystemDBDataSet1();
            this.tblPayRecordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblPayRecordsTableAdapter = new PayrollApplication.PayrollSystemDBDataSet1TableAdapters.tblPayRecordsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PayrollSystemDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPayRecordsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblPayRecordsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PayrollApplication.CurrentMonthPayments.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1298, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // PayrollSystemDBDataSet1
            // 
            this.PayrollSystemDBDataSet1.DataSetName = "PayrollSystemDBDataSet1";
            this.PayrollSystemDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblPayRecordsBindingSource
            // 
            this.tblPayRecordsBindingSource.DataMember = "tblPayRecords";
            this.tblPayRecordsBindingSource.DataSource = this.PayrollSystemDBDataSet1;
            // 
            // tblPayRecordsTableAdapter
            // 
            this.tblPayRecordsTableAdapter.ClearBeforeFill = true;
            // 
            // CurrentMonthPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CurrentMonthPayments";
            this.ShowIcon = false;
            this.Text = "CurrentMonthPayments";
            this.Load += new System.EventHandler(this.CurrentMonthPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PayrollSystemDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPayRecordsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblPayRecordsBindingSource;
        private PayrollSystemDBDataSet1 PayrollSystemDBDataSet1;
        private PayrollSystemDBDataSet1TableAdapters.tblPayRecordsTableAdapter tblPayRecordsTableAdapter;
    }
}