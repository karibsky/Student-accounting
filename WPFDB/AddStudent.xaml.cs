using System.Windows;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WPFDB
{
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            bool res = Add(name.Text, lastname.Text, course.Text, mw.connection, mw.command, mw);
            if (res)
            {
                mw.Show();
                this.Close();
            }
            else MessageBox.Show("Error, student dont added (check connection and input data)");
        }

        private bool Add(string name, string lastname, string course, MySqlConnection connection, MySqlCommand command, MainWindow mw)
        {
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(lastname)) return false; 
            else
            {
                try
                {

                    connection.Open();

                    command = new MySqlCommand("INSERT INTO students (id, name, lastname, course) VALUES (@, @name, @lastname, @course)", connection);

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@lastname", lastname);
                    command.Parameters.AddWithValue("@course", course);

                    command.Prepare();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (MySqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
