using RealtorAgency__Course_work_.Controllers.AddedClientControllers;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс для добавления клиентов
    /// Представляет собой диалоговое окно со всеми необходимыми полями для добавления нового клиента
    /// </summary>
    public partial class AddedClient : Window
    {
        //Поля
        private AddClientControll controll;


        //Методы
        public AddedClient (RiealtorAgencyDB riealtorAgency)
        {
            InitializeComponent();
            controll = new AddClientControll(this);
        }

        //Кнопка назад
        private void Back_Click (object sender, RoutedEventArgs e)
        {
            controll.AddClientControllBackClick();
        }

        /// <summary>
        /// кнопка Ок(добавить)
        /// Если все критерии ввода соблюдены, то 
        /// вызываются методы для создания клиента
        /// </summary>
        private void Ok_Click (object sender, RoutedEventArgs e)
        {
            controll.AddClientControllOkClick();
        }

        private void DataPreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controll.CheckSumbol(e);
        }

        private void Phone_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controll.CheckSubolNumber(e);
        }

    }

}
