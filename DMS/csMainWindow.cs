using System.ComponentModel;

namespace DMS
{
    public class CsMainWindow : INotifyPropertyChanged
    {
        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public CsMainWindow()
        {

        }

        private string _textBox1;
        public string stextBox
        {
            get { return _textBox1; }
            set
            {
                _textBox1 = value;
                Notify("stextBox");
            }
        }


        private string _label;
        public string slabel
        {
            get { return _label; }
            set
            {
                _label = value;
                Notify("slabel");
            }
        }


        private void Notify(string argument)
        {

            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(argument));
            }
        }

    }
}
