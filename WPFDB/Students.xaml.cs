using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace WPFDB
{
    public partial class MainWindow : Window
    {
        public MySqlConnection connection  = new MySqlConnection("server=localhost;database=testdb;user=root;password=");
        public MySqlCommand command;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayStudents();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Connection error");
            }
        }
        private void DisplayStudents()
        {
            try
            {
                connection.Open();

                command = new MySqlCommand("SELECT * FROM students", connection);

                MySqlDataAdapter da = new MySqlDataAdapter(command);

                DataSet ds = new DataSet();
                da.Fill(ds, "Loading");

                dataGrid.DataContext = ds;

            }
            catch(MySqlException)
            {
                MessageBox.Show("Error loading data");
            }
            finally
            {
                connection.Close();
            }
                
        }

        private void power_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddStudent add = new AddStudent();
            add.Show();
            this.Close();
        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            RemoveStudent rs = new RemoveStudent();
            rs.Show();
            this.Close();
        }

        private void button_About_Click(object sender, RoutedEventArgs e)
        {
            AboutDeveloper ad = new AboutDeveloper();
            ad.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
