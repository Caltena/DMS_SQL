using System.ComponentModel;

namespace ADD
{
    class IADDSearch
    {
        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private int _ADD_Key;
        public int ADD_Key
        {
            get { return _ADD_Key; }
            set
            {
                _ADD_Key = value;
                Notify("ADD_Key");
            }
        }

        private string _ADD_Name;
        public string ADD_Name
        {
            get { return _ADD_Name; }
            set
            {
                _ADD_Name = value;
                Notify("ADD_Name");
            }
        }

        private string _ADD_Street;
        public string ADD_Street
        {
            get { return _ADD_Street; }
            set
            {
                _ADD_Street = value;
                Notify("ADD_Street");
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

        private string _ADD_City;
        public string ADD_City
        {
            get { return _ADD_City; }
            set
            {
                _ADD_City = value;
                Notify("ADD_City");
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
