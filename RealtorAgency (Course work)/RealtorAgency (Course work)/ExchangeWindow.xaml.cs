using RealtorAgency__Course_work_.Controllers.ExchangeWindowControllers;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Окно обмена квартиры
    /// Окно отображает графический интерфейс для ввода информации
    /// и проследующей обработки
    /// </summary>
    public partial class ExchangeWindow : Window
    {
        //Поля
        private Clientas client = null;
        private string numOperations;
        private ExchangeControll controll;


        //Методы
        public ExchangeWindow (Clientas client,string num)
        {
            InitializeComponent();
            numOperations = num;
            this.client = client;
            controll = new ExchangeControll(this);
             
        }
        
        /// <summary>
        /// При загрузке окна
        /// </summary>
        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            Number.Text = numOperations;
            Operations.Text = "Обмен";
        }

        /// <summary>
        /// Кнопка назад
        /// </summary>
        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            controll.ExchangeGoClientClick();
        }

        /// <summary>
        /// Кнопка далее.
        /// Создание новой заявки с заданными полями
        /// </summary>
        private void Next_Click (object sender, RoutedEventArgs e)
        {
            controll.ExchangeNextClick(client);
        }   

        private void City_PreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controll.CheckSumbol(e);
        }

        private void NumPreviewTextInput (object sender, TextCompositionEventArgs e)
        {
            controll.CheckSubolNumber(e);
        }

    }

}
