/*-----------------------------------------------------------------*\
 *
 * DataGridViewDateTimePickerColumn.cs
 *   CustomDgvColumnsSample
 *     custom-dgv-columns-sample
 *
 * MIT License - See LICENSE at root directory
 *
 * CREATED: 2023-7-1 12:38 AM
 * AUTHORS: Mohammed Elghamry <elghamry.connect[at]outlook[dot]com>
 *
\*-----------------------------------------------------------------*/

using System;
using System.Windows.Forms;

namespace CustomDgvColumnsSample.Controls
{
    internal class DataGridViewDateTimePickerColumn : DataGridViewColumn
    {
        public DataGridViewDateTimePickerColumn()
            : base(new DataGridViewDateTimePickerCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }

            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDateTimePickerCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewDateTimePickerCell");
                }

                base.CellTemplate = value;
            }
        }
    }
}
