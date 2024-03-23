using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_PR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;

            var password = Password.Text;
            var context = new AppDbContext();
            
            var user = context.Users.SingleOrDefault(x => x.Login == login || x.Email == login && x.Password == password);
            if (user is null) 
            {
                Error.Text = ("Неправильный Логин или Пароль!");
                return;
            }

            Error.Text = ("Вы успешно вошли в аккаунт!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg reg = new Reg();
            reg.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Password_Copy = Password.Text;
            Password.Text = "";

            for (int i = Password.Text.Length; i > 0; i--)
            {
                Password.Text += '*';
            }
        }
    }
}