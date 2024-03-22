using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;

            var email = Email.Text;

            var pass = Password.Text;

            var pass1 = Password1.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует.");
                return;
            }

            if (login.Length == 0)
            {
                MessageBox.Show("Логин не может быть пустым.");
            }
            else if (email.Length == 0)
            {
                MessageBox.Show("Почта не может быть пустой.");
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@(mail\.ru|gmail\.com|yandex\.ru)$"))
            {
                MessageBox.Show("Пожалуйста, введите электронную почту в формате '123@mail.ru' и тому подобное.");
            }
            else if (pass.Length < 8)
            {
                MessageBox.Show("Пароль не может быть меньше 8 символов.");
            }
            else if (pass != pass1)
            {
                MessageBox.Show("Пароли не совпадают.");
            }
            else
            {
                var user = new User { Login = login, Email = email, Password = pass };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Вы зарегестрировались!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow log = new MainWindow();
            log.Show();
        }
    }
}
