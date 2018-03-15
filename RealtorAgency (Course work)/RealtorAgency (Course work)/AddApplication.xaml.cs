using RealtorAgency__Course_work_.Controllers.AddApplicationControllers;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Окно для обратботки ввода заявки
    /// Указываем номер заявки и тип операции
    /// в соответсвии с выбором откроется то, или инное окно
    /// </summary>
    public partial class AddApplication : Window
    {
        //Поля
        private Clientas client = null;
        private AddApplicationController controller;

        public Clientas getcl
        {
            get { return client; }
        }

        //Методы
        public AddApplication (Clientas client, RiealtorAgencyDB riealtorAgency)
        {
            InitializeComponent();
            controller = new AddApplicationController(this);
            this.client = client;  
        }

        //получаем номер заявки
        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            FullName.Text = String.Format("{0} {1} {2}", client.name, client.lastName, client.patronymic);
            Num.Text = controller.GetManager.Agency.GetNextNum();
        }

        //Вернуться назад
        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            controller.AddApplicationGoClientClick();
        }

        /// <summary>
        /// Кнопка далее
        /// Отображает окно (обмен,покупка,продажа)
        /// в зависимости от выбора
        /// </summary>
        private void Next_Click (object sender, RoutedEventArgs e)
        {
            controller.AddApplicationNextClick(client);
        }

        private void Num_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controller.CheckSumbol(e);
        }

    }

}
