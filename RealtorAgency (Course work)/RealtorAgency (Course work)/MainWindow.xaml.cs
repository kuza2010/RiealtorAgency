using System.Windows;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ABSOLUTE_CONTROLL MAIN_CONTROLL;

        public MainWindow ()
        {
            InitializeComponent();
            MAIN_CONTROLL = new ABSOLUTE_CONTROLL();
        }

        private void Exit_Click (object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            Client windowClient = new Client();
            windowClient.Show();
            this.Close();
        }
    }
}
