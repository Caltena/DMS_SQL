using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ToolComboBox
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class TComboBox : UserControl
    {
        ITComboBox ITC = new ITComboBox();

        public TComboBox()
        {
            InitializeComponent();
            ITC.TCBWidth = 120;
            ITC.TCBHeight = 22;
            this.DataContext = ITC;
            BindComboBox(ComboBoxZone);
        }


        public string ID
        {
            get { return ITC.CNT_Key.ToString(); }
            set
            {
                ITC.CNT_Key = value;
                this.ComboBoxZone.SelectedValue = ITC.CNT_Key.ToString();
            }
        }

        public void BindComboBox(ComboBox comboBoxName)
        {

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = @"Data Source=NB-036;Initial Catalog=DMS_Master;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select CNT_Key,CNT_Name FROM LK_Country";
            SqlDataAdapter sqlDa = new SqlDataAdapter();
            sqlDa.SelectCommand = cmd;
            DataSet ds = new DataSet();
            try
            {
                sqlDa.Fill(ds, "LK_Country");
                DataRow nRow = ds.Tables["LK_Country"].NewRow();
                nRow["CNT_Name"] = "List All";
                nRow["CNT_Key"] = "0";
                ds.Tables["LK_Country"].Rows.InsertAt(nRow, 0);

                comboBoxName.DataContext = ds.Tables["LK_Country"].DefaultView;

                comboBoxName.DisplayMemberPath =
                    ds.Tables["LK_Country"].Columns["CNT_Name"].ToString();

                comboBoxName.SelectedValuePath =
                    ds.Tables["LK_Country"].Columns["CNT_Key"].ToString();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occurred while loading categories." + ex.Message.ToString());
            }
            finally
            {
                sqlDa.Dispose();
                cmd.Dispose();
                sqlCon.Dispose();
            }
        }

        #region ClickEvent

        public static readonly RoutedEvent SelectedEvent =
           EventManager.RegisterRoutedEvent("SelectionChanged",
                                            RoutingStrategy.Bubble,
                                            typeof(RoutedEventHandler),
                                            typeof(TComboBox));

        public event RoutedEventHandler Selected
        {
            add { AddHandler(SelectedEvent, value); }
            remove { RemoveHandler(SelectedEvent, value); }
        }

        protected virtual void RaiseSelectedEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(TComboBox.SelectedEvent);
            RaiseEvent(args);
        }

        #endregion

        private void ComboBoxZone_Selected(object sender, RoutedEventArgs e)
        {
            RaiseSelectedEvent();
        }
    }
}
