/*-----------------------------------------------------------------*\
 *
 * frmMain.cs
 *   CustomDgvColumnsSample
 *     custom-dgv-columns-sample
 *
 * MIT License - See LICENSE at root directory
 *
 * CREATED: 2023-6-30 09:24 PM
 * AUTHORS: Mohammed Elghamry <elghamry.connect[at]outlook[dot]com>
 *
\*-----------------------------------------------------------------*/

using System;
using System.Data;
using System.Windows.Forms;

using CustomDgvColumnsSample.Controls;

namespace CustomDgvColumnsSample
{
    public partial class MainForm : Form
    {
        private readonly DataGridViewDateTimePickerColumn colDateOfBirth;

        public MainForm()
        {
            InitializeComponent();

            colDateOfBirth = new DataGridViewDateTimePickerColumn();
            colDateOfBirth.DataPropertyName = "dob";
            colDateOfBirth.HeaderText = "Date Of Birth";
            colDateOfBirth.Name = "colDateOfBirth";

            UiDgvMain.Columns.Add(colDateOfBirth);

            // Populate the DGV with some sample data
            var sampleDt = new DataTable();
            sampleDt.Columns.Add("name");
            sampleDt.Columns.Add("age");
            sampleDt.Columns.Add("dob");

            sampleDt.Rows.Add("Ahmed", "25", DateTime.Now);
            sampleDt.Rows.Add("Saleh", "22", DateTime.Now);
            sampleDt.Rows.Add("Hassan", "27", DateTime.Now);
            sampleDt.Rows.Add("Yasser", "30", DateTime.Now);

            UiDgvMain.DataSource = sampleDt;
        }
    }
}
