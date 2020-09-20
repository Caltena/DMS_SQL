using System.ComponentModel;

namespace ToolPanel
{
    public class csToolPanel : INotifyPropertyChanged
    {
        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        public csToolPanel()
        {
            this.Import_IsEnabled = true;
            this.Search_IsEnabled = true;
            this.List_IsEnabled = true;
            this.Single_IsEnabled = true;
            this.Printer_IsEnabled = true;
            this.Mail_IsEnabled = true;
            this.Undo_IsEnabled = true;
            this.Delete_IsEnabled = true;
            this.Save_IsEnabled = true;

        }

        private bool _ADD_IsEnabled;
        public bool ADD_IsEnabled
        {
            get { return _ADD_IsEnabled; }
            set
            {
                _ADD_IsEnabled = value;
                Notify("ADD_IsEnabled");
            }
        }

        private bool _Import_IsEnabled;
        public bool Import_IsEnabled
        {
            get { return _Import_IsEnabled; }
            set
            {
                _Import_IsEnabled = value;
                Notify("Import_IsEnabled");
            }
        }

        private bool _Search_IsEnabled;
        public bool Search_IsEnabled
        {
            get { return _Search_IsEnabled; }
            set
            {
                _Search_IsEnabled = value;
                Notify("Search_IsEnabled");
            }
        }

        private bool _List_IsEnabled;
        public bool List_IsEnabled
        {
            get { return _List_IsEnabled; }
            set
            {
                _List_IsEnabled = value;
                Notify("List_IsEnabled");
            }
        }

        private bool _Single_IsEnabled;
        public bool Single_IsEnabled
        {
            get { return _Single_IsEnabled; }
            set
            {
                _Single_IsEnabled = value;
                Notify("Single_IsEnabled");
            }
        }

        private bool _Printer_IsEnabled;
        public bool Printer_IsEnabled
        {
            get { return _Printer_IsEnabled; }
            set
            {
                _Printer_IsEnabled = value;
                Notify("Printer_IsEnabled");
            }
        }

        private bool _Mail_IsEnabled;
        public bool Mail_IsEnabled
        {
            get { return _Mail_IsEnabled; }
            set
            {
                _Mail_IsEnabled = value;
                Notify("Mail_IsEnabled");
            }
        }

        private bool _Undo_IsEnabled;
        public bool Undo_IsEnabled
        {
            get { return _Undo_IsEnabled; }
            set
            {
                _Undo_IsEnabled = value;
                Notify("Undo_IsEnabled");
            }
        }

        private bool _Delete_IsEnabled;
        public bool Delete_IsEnabled
        {
            get { return _Delete_IsEnabled; }
            set
            {
                _Delete_IsEnabled = value;
                Notify("Delete_IsEnabled");
            }
        }

        private bool _Save_IsEnabled;
        public bool Save_IsEnabled
        {
            get { return _Save_IsEnabled; }
            set
            {
                _Save_IsEnabled = value;
                Notify("Save_IsEnabled");
            }
        }


        private void Notify(string argument)
        {

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(argument));
            }
        }
    }

}
