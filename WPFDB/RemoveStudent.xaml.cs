using System.Windows;
using MySql.Data.MySqlClient;

namespace WPFDB
{

    public partial class RemoveStudent : Window
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            bool res = Remove(parametr.Text, mw.connection, mw.command, mw);
            if (res)
            {
                mw.Show();
                this.Close();
            }
            else MessageBox.Show("Error, student dont added (check connection and input data)");
        }

        private bool Remove(string parametr, MySqlConnection connection, MySqlCommand command, MainWindow mw)
        {
            if (string.IsNullOrWhiteSpace(parametr)) return false;
            else
            {
                try
                {
                    connection.Open();

                    command = new MySqlCommand("DELETE FROM students WHERE id = @parametr", connection);
                    command.Parameters.AddWithValue("@parametr", parametr);
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
