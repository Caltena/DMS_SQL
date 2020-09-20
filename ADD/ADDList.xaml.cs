using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Input;

namespace ADD
{
    /// <summary>
    /// Interaktionslogik für ADDList.xaml
    /// </summary>
    public partial class ADDList : UserControl
    {
        public ADDSearch cADDSearch { get; set; }
        public ADDSingle cADDSingle { get; set; }
        public SQLiteLoggin.SqliteInterface SQ_Log { get; set; }

        public ADDList()
        {
            InitializeComponent();

        }

        private void Next(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(cADDSingle);
            cADDSingle.ucToolPanelSingle.ShowSingle();
        }
        private void Back(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(cADDSearch);
            cADDSearch.ucToolPanelSearch.ShowSearch();
        }

        public string BuildWhereString()
        {
            int value;
            string CmdString = string.Empty;

            string connectionString = @"Data Source=NB-036;Initial Catalog=DMS_Master;Integrated Security=True";
            string sWhere = " WHERE 1 = 1 ";

            if (string.IsNullOrEmpty(cADDSearch.ADD_Name.ToString()) == false)
                sWhere += "AND  ADD_Match Like '%" + cADDSearch.ADD_Name.Text.ToString() + "%' ";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    CmdString = "SELECT  ADD_Key ,ADD_Match ," +
                                        "ADD_Street ," +
                                        "ADD_City ,ADD_Email  FROM dbo.CM_Address" +
                                         sWhere;

                    SQ_Log.Debug("ADDList", "BuildWhereString", CmdString.Replace("'", ""));
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("CM_Address");
                    sda.Fill(dt);
                    DTF.ItemsSource = dt.DefaultView;
                    SQ_Log.Debug("ADDList", "BuildWhereString Count", dt.Rows.Count.ToString());
                    if (dt.Rows.Count < 2)
                    {
                        string cellValue = (DTF.Items[0] as DataRowView).Row.ItemArray[0].ToString();
                        if (int.TryParse(cellValue, out value))
                        {
                            cADDSingle.ShowAddKey(value);
                            Switcher.Switch(cADDSingle);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                SQ_Log.Error("ADDList (Error)", "BuildWhereString", e.Message.ToString());
                Switcher.Switch(cADDSearch);
            }

            return sWhere;
        }

        private void MouseDownLeft(object sender, MouseButtonEventArgs e)
        {
            int value;
            try
            {
                int columnIndex = DTF.CurrentCell.Column.DisplayIndex;
                DataRowView row = (DataRowView)DTF.SelectedItem;
                string cellValue = row.Row.ItemArray[columnIndex].ToString();

                if (columnIndex == 0)
                {
                    if (int.TryParse(cellValue, out value))
                    {
                        cADDSingle.ShowAddKey(value);
                        SQ_Log.Debug("ADDList", "MouseDownLeft", cellValue);
                        Switcher.Switch(cADDSingle);
                        cADDSearch.ucToolPanelSearch.ShowSearch();
                    }

                }
            }
            catch (Exception exd)
            {
                SQ_Log.Error("ADDList (Error)", "MouseDownLeft", exd.Message.ToString());
            }

        }



    }
}
