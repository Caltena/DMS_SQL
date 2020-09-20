using System.Windows.Controls;

namespace ADD
{
    /// <summary>
    /// Interaktionslogik für ADDSingle.xaml
    /// </summary>
    public partial class ADDSingle : UserControl
    {
        public ADDList cADDList { get; set; }
        public ADDSearch cADDSearch { get; set; }
        public SQLiteLoggin.SqliteInterface SQ_Log { get; set; }

        IADDSingle iAddSingle = new IADDSingle();
        public cADD baseADDS = new cADD();

        #region Constructor
        public ADDSingle()
        {
            InitializeComponent();
            this.DataContext = iAddSingle;
            iAddSingle.ucToolPanelSingle = this.ucToolPanelSingle;
            this.ucToolPanelSingle.ShowSingle();
            iAddSingle.IsDirty = false;
        }

        public ADDSingle(int ADD_Key)
        {
            this.InitializeComponent();
            this.DataContext = iAddSingle;
            ShowAddKey(ADD_Key);
        }

        public ADDSingle(int ADD_Key, ADDMain pcADDMain)
        {
            this.InitializeComponent();
            this.DataContext = iAddSingle;
            this.cADDMain = pcADDMain;
            ShowAddKey(ADD_Key);
        }
        #endregion




        public void ShowAddKey(int Add_Key)
        {
            iAddSingle.Load(Add_Key);
            cCountry.ID = iAddSingle.CNT_Key.ToString();
            baseADDS.SetADDKey(Add_Key);


            SQ_Log.SetKey("ADD_Key", ADD_Key.ToString());
            SQ_Log.Debug("ADDSingle", "ShowAddKey", ADD_Key.ToString());
            iAddSingle.IsDirty = false;
            this.ucToolPanelSingle.ShowSingle();
        }

        public void SetBaseADD(cADD baseADD)
        {
            baseADDS = baseADD;
            SQ_Log.Debug("ADDSingle", "SetBaseADD", "");
        }

        private void Back(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Switch(cADDList);
            cADDList.ucToolPanelList.ShowList();
        }

        #region Var
        private ADDMain _cADDMain;
        public ADDMain cADDMain
        {
            get { return _cADDMain; }
            set { _cADDMain = value; }
        }

        private int _pADD_Key;
        public int pADD_Key
        {
            get { return _pADD_Key; }
            set
            {
                _pADD_Key = value;
                SQ_Log.SetKey("iADD_Key", _pADD_Key.ToString());
                SQ_Log.Debug("ADDSingle", "pADD_Key", _pADD_Key.ToString());
                this.iAddSingle.Load(_pADD_Key);
            }
        }


        #endregion



        private void cmdUndoClick(object sender, System.Windows.RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(this.ADD_Key.Text.ToString(), out value))
                ShowAddKey(value);
        }
    }


}
