using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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

            var password = Password.Password;

            var context = new AppDbContext();
            
            var user = context.Users.SingleOrDefault(x => (x.Login == login || x.Email == login)  && (x.Password == password || (x.Password == Password_Tb.Text)));
            if (user is null) 
            {
                Errorpass.Text = ("Неправильный Логин или Пароль!");
                return;
            }

            Errorpass.Text = ("Вы успешно вошли в аккаунт!");
            this.Hide();
            Success success = new Success();
            success.Show();
            success.Hello.Text = "Здравствуйте," + login + "!";
            Kabinet kabinet = new Kabinet();
            kabinet.Imya.Text = login;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Reg reg = new Reg();
            reg.Show();
        }
        bool schet = true;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (schet == true)
            {
                Password.Visibility = Visibility.Visible;
                Password.Password = Password_Tb.Text;
                Password_Tb.Visibility = Visibility.Collapsed;
                Button button = (Button)sender;
                button.Content = new Image { Source = new BitmapImage(new Uri("Image/5.png", UriKind.Relative)) };
                schet = false;
            }
            else
            {
                Password.Visibility = Visibility.Collapsed;
                Password_Tb.Text = Password.Password;
                Password_Tb.Visibility = Visibility.Visible;
                Button button = (Button)sender;
                button.Content = new Image { Source = new BitmapImage(new Uri("Image/3.png", UriKind.Relative)) };
                schet = true;
            }
        }
    }
}