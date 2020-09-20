using System;
using System.ComponentModel;
using System.Data.SqlClient;
using ToolPanel;

namespace ADD
{
    class IADDSingle : INotifyPropertyChanged
    {

        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public ucToolPanel ucToolPanelSingle;



        private Boolean _IsDirty;
        public Boolean IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                if (_IsDirty == true)
                {
                    ucToolPanelSingle.SaveIsEnabled = true;
                    ucToolPanelSingle.UndoIsEnabled = true;
                }
                else
                {
                    ucToolPanelSingle.SaveIsEnabled = false;
                    ucToolPanelSingle.UndoIsEnabled = false;
                }
            }
        }


        private Int32 _ADD_Key;
        public Int32 ADD_Key
        {
            get { return _ADD_Key; }
            set
            {
                _ADD_Key = value;

                Notify("ADD_Key");
            }
        }

        private String _ADD_cKey;
        public String ADD_cKey
        {
            get { return _ADD_cKey; }
            set
            {
                _ADD_cKey = value;
                Notify("ADD_cKey");
            }
        }

        private Int32? _CLI_Key;
        public Int32? CLI_Key
        {
            get { return _CLI_Key; }
            set
            {
                _CLI_Key = value;
                Notify("CLI_Key");
            }
        }

        private int _CNT_Key;
        public int CNT_Key
        {
            get { return _CNT_Key; }
            set
            {
                _CNT_Key = value;
                Notify("CNT_Key");
            }
        }

        private Int32 _SLT_Key;
        public Int32 SLT_Key
        {
            get { return _SLT_Key; }
            set
            {
                _SLT_Key = value;
                Notify("SLT_Key");
            }
        }

        private Int32 _TIT_Key;
        public Int32 TIT_Key
        {
            get { return _TIT_Key; }
            set
            {
                _TIT_Key = value;
                Notify("TIT_Key");
            }
        }

        private Int32? _IND_Key;
        public Int32? IND_Key
        {
            get { return _IND_Key; }
            set
            {
                _IND_Key = value;
                Notify("IND_Key");
            }
        }

        private Int32? _AKQ_Key;
        public Int32? AKQ_Key
        {
            get { return _AKQ_Key; }
            set
            {
                _AKQ_Key = value;
                Notify("AKQ_Key");
            }
        }

        private Int32? _CLR_Key;
        public Int32? CLR_Key
        {
            get { return _CLR_Key; }
            set
            {
                _CLR_Key = value;
                Notify("CLR_Key");
            }
        }

        private Int32? _CLO_Key;
        public Int32? CLO_Key
        {
            get { return _CLO_Key; }
            set
            {
                _CLO_Key = value;
                Notify("CLO_Key");
            }
        }

        private Int32? _CLS_Key;
        public Int32? CLS_Key
        {
            get { return _CLS_Key; }
            set
            {
                _CLS_Key = value;
                Notify("CLS_Key");
            }
        }

        private Int32? _CLT_Key;
        public Int32? CLT_Key
        {
            get { return _CLT_Key; }
            set
            {
                _CLT_Key = value;
                Notify("CLT_Key");
            }
        }

        private Int32? _STE_Key;
        public Int32? STE_Key
        {
            get { return _STE_Key; }
            set
            {
                _STE_Key = value;
                Notify("STE_Key");
            }
        }

        private Int32? _DVA_Key;
        public Int32? DVA_Key
        {
            get { return _DVA_Key; }
            set
            {
                _DVA_Key = value;
                Notify("DVA_Key");
            }
        }

        private Int32? _LNG_Key;
        public Int32? LNG_Key
        {
            get { return _LNG_Key; }
            set
            {
                _LNG_Key = value;
                Notify("LNG_Key");
            }
        }

        private Int32? _ADD_Key_Ref;
        public Int32? ADD_Key_Ref
        {
            get { return _ADD_Key_Ref; }
            set
            {
                _ADD_Key_Ref = value;
                Notify("ADD_Key_Ref");
            }
        }

        private Int32? _CLU_Key_Sales;
        public Int32? CLU_Key_Sales
        {
            get { return _CLU_Key_Sales; }
            set
            {
                _CLU_Key_Sales = value;
                Notify("CLU_Key_Sales");
            }
        }

        private Int32? _CLU_Key_V;
        public Int32? CLU_Key_V
        {
            get { return _CLU_Key_V; }
            set
            {
                _CLU_Key_V = value;
                Notify("CLU_Key_V");
            }
        }

        private String _ADD_Match;
        public String ADD_Match
        {
            get { return _ADD_Match; }
            set
            {
                _ADD_Match = value;
                Notify("ADD_Match");
            }
        }

        private Int16? _ADD_fPrivate;
        public Int16? ADD_fPrivate
        {
            get { return _ADD_fPrivate; }
            set
            {
                _ADD_fPrivate = value;
                Notify("ADD_fPrivate");
            }
        }

        private String _ADD_Line1;
        public String ADD_Line1
        {
            get { return _ADD_Line1; }
            set
            {
                _ADD_Line1 = value;
                IsDirty = true;
                Notify("ADD_Line1");
            }
        }

        private String _ADD_Line2;
        public String ADD_Line2
        {
            get { return _ADD_Line2; }
            set
            {
                _ADD_Line2 = value;
                Notify("ADD_Line2");
            }
        }

        private String _ADD_Line3;
        public String ADD_Line3
        {
            get { return _ADD_Line3; }
            set
            {
                _ADD_Line3 = value;
                Notify("ADD_Line3");
            }
        }

        private String _ADD_Street;
        public String ADD_Street
        {
            get { return _ADD_Street; }
            set
            {
                _ADD_Street = value;
                Notify("ADD_Street");
            }
        }

        private String _ADD_ZipCode;
        public String ADD_ZipCode
        {
            get { return _ADD_ZipCode; }
            set
            {
                _ADD_ZipCode = value;
                Notify("ADD_ZipCode");
            }
        }

        private String _ADD_City;
        public String ADD_City
        {
            get { return _ADD_City; }
            set
            {
                _ADD_City = value;
                Notify("ADD_City");
            }
        }

        private String _ADD_Zip_POBox;
        public String ADD_Zip_POBox
        {
            get { return _ADD_Zip_POBox; }
            set
            {
                _ADD_Zip_POBox = value;
                Notify("ADD_Zip_POBox");
            }
        }

        private String _ADD_POBox;
        public String ADD_POBox
        {
            get { return _ADD_POBox; }
            set
            {
                _ADD_POBox = value;
                Notify("ADD_POBox");
            }
        }

        private String _ADD_Internet;
        public String ADD_Internet
        {
            get { return _ADD_Internet; }
            set
            {
                _ADD_Internet = value;
                Notify("ADD_Internet");
            }
        }

        private String _ADD_EMail;
        public String ADD_EMail
        {
            get { return _ADD_EMail; }
            set
            {
                _ADD_EMail = value;
                Notify("ADD_EMail");
            }
        }

        private String _ADD_Fon_C;
        public String ADD_Fon_C
        {
            get { return _ADD_Fon_C; }
            set
            {
                _ADD_Fon_C = value;
                Notify("ADD_Fon_C");
            }
        }

        private String _ADD_Fon_A;
        public String ADD_Fon_A
        {
            get { return _ADD_Fon_A; }
            set
            {
                _ADD_Fon_A = value;
                Notify("ADD_Fon_A");
            }
        }

        private String _ADD_Fon_N;
        public String ADD_Fon_N
        {
            get { return _ADD_Fon_N; }
            set
            {
                _ADD_Fon_N = value;
                Notify("ADD_Fon_N");
            }
        }

        private String _ADD_Fon_E;
        public String ADD_Fon_E
        {
            get { return _ADD_Fon_E; }
            set
            {
                _ADD_Fon_E = value;
                Notify("ADD_Fon_E");
            }
        }

        private String _ADD_Fax_C;
        public String ADD_Fax_C
        {
            get { return _ADD_Fax_C; }
            set
            {
                _ADD_Fax_C = value;
                Notify("ADD_Fax_C");
            }
        }

        private String _ADD_Fax_A;
        public String ADD_Fax_A
        {
            get { return _ADD_Fax_A; }
            set
            {
                _ADD_Fax_A = value;
                Notify("ADD_Fax_A");
            }
        }

        private String _ADD_Fax_N;
        public String ADD_Fax_N
        {
            get { return _ADD_Fax_N; }
            set
            {
                _ADD_Fax_N = value;
                Notify("ADD_Fax_N");
            }
        }

        private String _ADD_Fax_E;
        public String ADD_Fax_E
        {
            get { return _ADD_Fax_E; }
            set
            {
                _ADD_Fax_E = value;
                Notify("ADD_Fax_E");
            }
        }

        private String _ADD_Mobile_C;
        public String ADD_Mobile_C
        {
            get { return _ADD_Mobile_C; }
            set
            {
                _ADD_Mobile_C = value;
                Notify("ADD_Mobile_C");
            }
        }

        private String _ADD_Mobile_A;
        public String ADD_Mobile_A
        {
            get { return _ADD_Mobile_A; }
            set
            {
                _ADD_Mobile_A = value;
                Notify("ADD_Mobile_A");
            }
        }

        private string _ADD_Email;
        public string ADD_Email
        {
            get { return _ADD_Email; }
            set
            {
                _ADD_Email = value;
                Notify("ADD_Email");
            }
        }

        private Boolean _ADD_fActive;
        public Boolean ADD_fActive
        {
            get { return _ADD_fActive; }
            set
            {
                _ADD_fActive = value;
                Notify("ADD_fActive");
            }
        }

        private void Notify(string argument)
        {

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(argument));
            }
        }



        public void Load(int pADD_key)
        {
            string connectionString = @"Data Source=NB-036;Initial Catalog=DMS_Master;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT  ADD_Key ,ADD_Match ,CNT_Key, " +
                    "ADD_Street ,ADD_Line1, ADD_Line2, ADD_Line3, " +
                    "ADD_City ,ADD_Email  FROM dbo.CM_Address WHERE ADD_Key = @ADDKey ", conn);
            command.Parameters.AddWithValue("@ADDKey", pADD_key.ToString());

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    this.ADD_Key = Convert.ToInt32(reader["ADD_Key"]);
                    this.ADD_Match = reader["ADD_Match"].ToString();
                    this.ADD_Street = reader["ADD_Street"].ToString();
                    this.ADD_City = reader["ADD_City"].ToString();
                    this.ADD_Email = reader["ADD_Email"].ToString();
                    this.ADD_Line1 = reader["ADD_Line1"].ToString();
                    this.ADD_Line2 = reader["ADD_Line2"].ToString();
                    this.ADD_Line3 = reader["ADD_Line3"].ToString();
                    this.CNT_Key = Convert.ToInt32(reader["CNT_Key"]);
                }
            }

            conn.Close();
            Notify("State");
        }

    }
}
