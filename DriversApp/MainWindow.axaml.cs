using Avalonia.Controls;
using System.Threading.Tasks;
using Avalonia.Media;

namespace DriversApp
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
 
        }

        //функция для кнопки входа 
        public async void EnterClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var input1 = LoginTextBox.Text;
            var input2 = PasswordTextBox.Text;

            //проверка логина и пароля
            if (input1 == "inspector" && input1 == input2)
            {
                StatusMessage.Text = "Успешно!";
                StatusMessage.Foreground = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Colors.Green); //смена цвета на зеленый

                await Task.Delay(2000);

                var newWindow = new Window1();
                newWindow.Show();

                this.Close();
            }
            else
            {
                StatusMessage.Text = "Данные не совпадают или неверны.";
                StatusMessage.Foreground = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Colors.Red); //смена цвета на красный
            }
        }
    }
}