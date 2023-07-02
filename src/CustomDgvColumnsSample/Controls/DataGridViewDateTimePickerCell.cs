/*-----------------------------------------------------------------*\
 *
 * DataGridViewDateTimePickerCell.cs
 *   CustomDgvColumnsSample
 *     custom-dgv-columns-sample
 *
 * MIT License - See LICENSE at root directory
 *
 * CREATED: 2023-7-1 12:26 AM
 * AUTHORS: Mohammed Elghamry <elghamry.connect[at]outlook[dot]com>
 *
\*-----------------------------------------------------------------*/

using System;
using System.Windows.Forms;

namespace CustomDgvColumnsSample.Controls
{
    internal class DataGridViewDateTimePickerCell : DataGridViewTextBoxCell
    {
        public DataGridViewDateTimePickerCell()
        {
            Style.Format = null;
        }

        public override void InitializeEditingControl(
            int rowIndex,
            object initialFormattedValue,
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            DataGridViewDateTimePickerEditingControl ctl
                = DataGridView.EditingControl as DataGridViewDateTimePickerEditingControl;

            if (Value == null)
            {
                ctl.Value = (DateTime)DefaultNewRowValue;
            }
            else
            {
                // HACK!
                ctl.Value = DateTime.Parse((string)Value);
            }
        }

        public override Type EditType => typeof(DataGridViewDateTimePickerEditingControl);

        public override Type ValueType => typeof(DateTime);

        public override object DefaultNewRowValue => DateTime.Now;
    }
}
