using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_PR
{
    /// <summary>
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Window
    {
        public Kabinet()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow log = new MainWindow();
            log.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var email = Email.Text;
            var pass = Password.Text;

            var context = new AppDbContext();

            var user = new User { Login = login, Email = email, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
