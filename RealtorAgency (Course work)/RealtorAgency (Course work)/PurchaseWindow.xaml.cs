using RealtorAgency__Course_work_.Controllers.PurchaseWindowController;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Окно Покупка квартиры
    /// Окно отображает графический интерфейс для ввода информации
    /// и проследующей обработки
    /// </summary>
    public partial class PurchaseWindow : Window
    {

        //Поля
        private Clientas client;
        private string numOperations;
        private PurchaseController controller;


        //Методы
        public PurchaseWindow (Clientas client, string num)
        {
            InitializeComponent();
            this.client = client;
            numOperations = num;
            controller = new PurchaseController(this);
        }

        //По загрузке окна
        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            Number.Text = numOperations;
            Operations.Text = "Покупка";
        }

        /// <summary>
        /// Кнопка назад
        /// скрывает окно и отображает родительское
        /// </summary>
        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            controller.PurchaseGoClientClick();
        }

        /// <summary>
        /// Кнопка далее.
        /// Создает заявку с указанными полями.
        /// </summary>
        private void Next_Click (object sender, RoutedEventArgs e)
        {
            controller.PurchaseNextClick(client);
        }

        private void City_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controller.CheckSumbol(e);
        }

        private void NumRoom_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controller.CheckSubolNumber(e);
        }

    }

}
