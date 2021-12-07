using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using CourseSelectionApp.Commons;

namespace CourseSelectionApp.UserControls
{
    public partial class CourseDataGridComponent : UserControl
    {
        private const string DATA_PROPERTY_SEPARATOR = ".";
        private const string ARRAY_OF_STRINGS_SEPARATOR = " ";

        public CourseDataGridComponent(ControlCommons controlCommons)
        {
            InitializeComponent();
            _courseDataGridView.CellFormatting += MapCellDataToPropertyValue;
            _courseDataGridView.CellValueChanged += ListenDataGridViewOnCellValueChanged;
            _courseDataGridView.CellContentClick += ListenDataGridViewOnCellContentClick;
            _courseDataGridView.RowHeadersVisible = false;

            // 設定 DataGridView DoubleBuffered
            controlCommons.SetDoubleBuffered(_courseDataGridView, true);
        }

        public DataGridViewCellEventHandler DataGridViewCellValueChanged
        {
            get; set;
        }

        public DataGridViewCellEventHandler DataGridViewCellContentClick
        {
            get; set;
        }

        public object DataGridViewDataSource
        {
            get
            {
                return _courseDataGridView.DataSource;
            }
            set
            {
                _courseDataGridView.DataSource = value;
            }
        }

        /// <summary>
        /// 監聽 DataGridView 的 CellValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenDataGridViewOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewCellValueChanged != null)
            {
                DataGridViewCellValueChanged(sender, e);
            }
        }

        /// <summary>
        /// 監聽 DataGridView 的 CellContentClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenDataGridViewOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewCellContentClick != null)
            {
                DataGridViewCellContentClick(sender, e);
            }
        }

        /// <summary>
        /// Mapping 對應 Property 資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCellDataToPropertyValue(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((_courseDataGridView.Rows[e.RowIndex].DataBoundItem != null) &&
                (_courseDataGridView.Columns[e.ColumnIndex].DataPropertyName.Contains(DATA_PROPERTY_SEPARATOR)))
                {
                    e.Value = GetPropertyValue(
                        _courseDataGridView.Rows[e.RowIndex].DataBoundItem,
                        _courseDataGridView.Columns[e.ColumnIndex].DataPropertyName
                    );
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                // IBindingList will read data without updating when the data source is removed one row
                // Another option: Storing IBindingList in Form. After updating all data, then calling ResetBindings() method;
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// 取得 Property 對應資料
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetPropertyValue(object property, string propertyName)
        {
            if (propertyName.Contains(DATA_PROPERTY_SEPARATOR))
            {
                var leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(DATA_PROPERTY_SEPARATOR));
                foreach (var propertyInfo in property.GetType().GetProperties())
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        return GetPropertyValue(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(DATA_PROPERTY_SEPARATOR) + 1));
                    }
                }
            }

            return ConvertPropertyValue(property.GetType().GetProperty(propertyName), property);
        }

        /// <summary>
        /// 依照規則轉換數值顯示至 DataGridView
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private object ConvertPropertyValue(PropertyInfo propertyInfo, object property)
        {
            var type = propertyInfo.PropertyType;
            var value = propertyInfo.GetValue(property);

            if (type.IsSubclassOf(typeof(Collection<string>)))
            {
                value = string.Join(ARRAY_OF_STRINGS_SEPARATOR, (Collection<string>)value);
            }

            return value;
        }
    }
}
