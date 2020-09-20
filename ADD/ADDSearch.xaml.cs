using System.Windows.Controls;

namespace ADD
{
    /// <summary>
    /// Interaktionslogik für ADDSearch.xaml
    /// </summary>
    public partial class ADDSearch : UserControl
    {
        public ADDList cADDList { get; set; }
        public ADDSingle cADDSingle { get; set; }
        public SQLiteLoggin.SqliteInterface SQ_Log { get; set; }
        IADDSearch cIAddSearch = new IADDSearch();

        public ADDSearch()
        {
            InitializeComponent();
            this.DataContext = cIAddSearch;
            this.ucToolPanelSearch.ShowSearch();
        }

        private void Next(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(cADDList);
            cADDList.ucToolPanelList.ShowList();
            cADDList.BuildWhereString();
        }
    }
}
