using System.ComponentModel;

namespace ToolComboBox
{
    class ITComboBox : INotifyPropertyChanged
    {
        private int _TCBWidth;
        public int TCBWidth
        {
            get { return _TCBWidth; }
            set
            {
                _TCBWidth = value;
                Notify("TCBWidth");
            }
        }

        private int _TCBHeight;
        public int TCBHeight
        {
            get { return _TCBHeight; }
            set
            {
                _TCBHeight = value;
                Notify("TCBHeight");
            }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                Notify("ID");
            }
        }

        private string _CNT_Key;
        public string CNT_Key
        {
            get { return _CNT_Key; }
            set
            {
                _CNT_Key = value;
                Notify("CNT_Key");
            }
        }

        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify(string argument)
        {

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(argument));
            }
        }

    }
}
