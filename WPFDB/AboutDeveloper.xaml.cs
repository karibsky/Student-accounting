using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace WPFDB
{
    /// <summary>
    /// Логика взаимодействия для AboutDeveloper.xaml
    /// </summary>
    public partial class AboutDeveloper : Window
    {
        public AboutDeveloper()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
