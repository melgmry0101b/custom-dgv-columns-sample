/*-----------------------------------------------------------------*\
 *
 * DataGridViewDateTimePickerEditingControl.cs
 *   CustomDgvColumnsSample
 *     custom-dgv-columns-sample
 *
 * MIT License - See LICENSE at root directory
 *
 * CREATED: 2023-6-30 11:25 PM
 * AUTHORS: Mohammed Elghamry <elghamry.connect[at]outlook[dot]com>
 *
\*-----------------------------------------------------------------*/

// ****
// REFERENCE: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-host-controls-in-windows-forms-datagridview-cells?view=netframeworkdesktop-4.8
// ****

using System;
using System.Globalization;
using System.Windows.Forms;

namespace CustomDgvColumnsSample.Controls
{
    internal class DataGridViewDateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        // ======
        // Fields
        // ======

        private readonly CultureInfo m_cultureProvider = CultureInfo.InvariantCulture;

        // ======
        // ctor
        // ======

        public DataGridViewDateTimePickerEditingControl()
        {
            // Set DateTimePicker format
            Format = DateTimePickerFormat.Short;
        }

        // ======
        // Properties
        // ======

        public DataGridView EditingControlDataGridView { get; set; }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }

        public object EditingControlFormattedValue
        {
            get
            {
                switch (Format)
                {
                    case DateTimePickerFormat.Long:
                        return Value.ToLongDateString();

                    case DateTimePickerFormat.Short:
                        return Value.ToShortDateString();

                    case DateTimePickerFormat.Time:
                        return Value.ToLongTimeString();

                    case DateTimePickerFormat.Custom:
                        return Value.ToString(CustomFormat);

                    default:
                        return Value.ToLongDateString();
                }
            }

            set
            {
                if (value is string strValue)
                {
                    if (Format == DateTimePickerFormat.Custom)
                    {
                        Value = DateTime.ParseExact(strValue, CustomFormat, m_cultureProvider);
                    }
                    else
                    {
                        Value = DateTime.Parse(strValue);
                    }
                }
            }
        }

        public Cursor EditingPanelCursor => base.Cursor;

        public bool RepositionEditingControlOnValueChange => false;

        // ======
        // Methods
        // ======

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;

            if (dataGridViewCellStyle.Format != null)
            {
                Format = DateTimePickerFormat.Custom;
                CustomFormat = dataGridViewCellStyle.Format;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;

                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation is needed
        }
    }
}
