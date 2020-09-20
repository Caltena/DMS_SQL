using System.Windows.Controls;

namespace ADD
{
    public static class Switcher
    {
        public static ADDMain pageSwitcher;


        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
