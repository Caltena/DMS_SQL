using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TSQLtoCS
{


    public class iInterface
    {
        public string GetA2(string a0, string a1)
        {
            return " \n\t  private " + a1 + "  _" + a0 + "; " +
                            "\n\t   public " + a1 + " " + a0 + " " +
                            "\n \t  { " +
                            "\n \t      get { return _" + a0 + "; } " +
                            "\n \t      set " +
                            "\n \t     { " +
                            "\n \t          _" + a0 + " = value;       " +
                            "\n \t           Notify(" + a0 + "); " +
                            "\n \t      } " +
                            "\n \t   } ;\n";
        }

        public string a1 = "\n class iXXX : INotifyPropertyChanged " +
                            "\n \t{ " +
                            "\n \t     public event PropertyChangedEventHandler PropertyChanged;\n\n";


        public string a3 = "\n \t    private void Notify(string argument) " +
                            "\n \t   { " +
                            "\n \t       if (this.PropertyChanged != null) " +
                            "\n \t       { " +
                            "\n \t       this.PropertyChanged(this, new PropertyChangedEventArgs(argument)); " +
                            "\n \t       } " +
                            "\n \t   }\n}\n\n";
    }


    public class iStoredProcedure
    {
        private List<cFields> lTable = new List<cFields>();
        public string sText;

        private cFields _PrimaryKey;
        public cFields PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }

        public string GetSP()
        {
            return GetParameter();
        }

        private string GetParameter()
        {
            string s = "";
            foreach (cFields cf in lTable)
            {
                s += "\n \t @" + cf.Column_Name.ToString() + " as " + cf.cSP;
            }

            return s;
        }

        public iStoredProcedure(List<cFields> iT)
        {
            sText = "";
            lTable = iT;
            PrimaryKey = GetPK();
        }

        private cFields GetPK()
        {
            cFields gPK = lTable.Where(p => p.constraint_name == "*").FirstOrDefault();
            return gPK;
        }

    }
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<cFields> lTable = new List<cFields>();
        string currentFileName;


        public MainWindow()
        {
            cConnectDB db = new cConnectDB();
            InitializeComponent();
            this.cmdShowInterface.IsEnabled = false;
            this.cmdShowStoredProc.IsEnabled = false;
            db.BindComboBoxTable(this.ComboBoxZone);

        }

        void openFileClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            if (dlg.ShowDialog() ?? false)
            {
                currentFileName = dlg.FileName;
                TextEditor.Load(currentFileName);
            }
        }

        void saveFileClick(object sender, RoutedEventArgs e)
        {
            if (currentFileName == null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".txt";
                if (dlg.ShowDialog() ?? false)
                {
                    currentFileName = dlg.FileName;
                }
                else
                {
                    return;
                }
            }
            TextEditor.Save(currentFileName);
        }


        private void ComboBoxZone_Selected(object sender, RoutedEventArgs e)
        {
            if (ComboBoxZone.SelectedIndex >= 0)
            {
                this.cmdShowInterface.IsEnabled = true;
                this.cmdShowStoredProc.IsEnabled = true;

            }
        }

        private void ShowInterface(string sTableName)
        {
            string st = "";
            cConnectDB cb = new cConnectDB();
            iInterface inter = new iInterface();
            lTable = cb.ReadTable(sTableName);
            st += inter.a1;
            foreach (cFields cf in lTable)
            {
                st += inter.GetA2(cf.Column_Name, cf.cC);
            }
            this.TextEditor.Text = st + inter.a3;
        }

        private void CmdShowInterface_Click(object sender, RoutedEventArgs e)
        {
            ShowInterface(this.ComboBoxZone.SelectedValue.ToString());
        }

        private void CmdShowStoredProc_Click(object sender, RoutedEventArgs e)
        {
            cConnectDB cb = new cConnectDB();
            lTable = cb.ReadTable(this.ComboBoxZone.SelectedValue.ToString());
            iStoredProcedure iSP = new iStoredProcedure(lTable);
            this.TextEditor.Text = iSP.GetSP();
        }
    }
}
