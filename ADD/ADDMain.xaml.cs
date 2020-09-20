using System;
using System.Windows;
using System.Windows.Controls;

namespace ADD
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ADDMain : UserControl
    {
        public ADDSearch ADD_Search = new ADDSearch();
        public ADDList ADD_List = new ADDList();
        public ADDSingle ADD_Single = new ADDSingle();

        public cADD baseADD = new cADD();
        public SQLiteLoggin.SqliteInterface SQ_Log = new SQLiteLoggin.SqliteInterface();

        public ADDMain()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            SetLanguageDictionary();

            SQ_Log.Debug("SetLanguageDictionary", "Initialisiert");

            ADD_Search.cADDList = ADD_List;
            ADD_Search.cADDSingle = ADD_Single;
            ADD_Search.SQ_Log = SQ_Log;
            SQ_Log.Debug("ADD_Search", "Initialisiert");

            ADD_List.cADDSearch = ADD_Search;
            ADD_List.cADDSingle = ADD_Single;
            ADD_List.SQ_Log = SQ_Log;
            SQ_Log.Debug("ADD_List", "Initialisiert");

            ADD_Single.cADDSearch = ADD_Search;
            ADD_Single.cADDList = ADD_List;
            ADD_Single.SQ_Log = SQ_Log;
            SQ_Log.Debug("ADD_Single", "Initialisiert");

            ADD_Single.SetBaseADD(baseADD);
            SQ_Log.Debug("baseADD", "Initialisiert");

            Switcher.Switch(ADD_Search);
            SQ_Log.Read();

        }

        public int GetPrimaryKey()
        {
            return this.baseADD.GetADDKey();
        }


        /// <summary>
        /// Sets the language dictionary.
        /// </summary>
        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (System.Threading.Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "en-US":
                    dict.Source = new Uri("..\\Resources\\German.xaml", UriKind.Relative);
                    break;
                case "fr-CA":
                    dict.Source = new Uri("..\\Resources\\German.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("pack://application:,,,/ADD;component/Resources/German.xaml", UriKind.Absolute);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }



        //public static readonly RoutedEvent ChangeKey =
        //   EventManager.RegisterRoutedEvent("aktChangeKey", RoutingStrategy.Bubble,
        //   typeof(RoutedEventHandler), typeof(ADDMain));

        //public event RoutedEventHandler aktChangeKey
        //{
        //    add { AddHandler(ChangeKey, value); }
        //    remove { RemoveHandler(ChangeKey, value); }
        //}

        //protected virtual void RaiseChangeKey()
        //{
        //    RoutedEventArgs args = new RoutedEventArgs(baseADD.Add_Key.ToString().);
        //    RaiseEvent(args);
        //}


        //public void cmdChangeKey()
        //{
        //    RaiseChangeKey();
        //}

    }
    public interface ISwitchable
    {
        void UtilizeState(object state);
    }


}
