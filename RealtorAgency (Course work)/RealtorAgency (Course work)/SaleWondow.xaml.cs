using RealtorAgency__Course_work_.Controllers.SaleWindowControllers;
using System.Windows;
using System.Windows.Input;


namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Окно продажи квартиры
    /// Окно отображает графический интерфейс для ввода информации
    /// и проследующей обработки
    /// </summary>
    public partial class SaleWondow : Window
    {
        //Поля
        private Clientas client;
        private string numOperations;
        private SaleWindowController controller;


        //Методы
        public SaleWondow (Clientas client , string num)
        {
            InitializeComponent();
            this.client = client;
            numOperations = num;
            controller = new SaleWindowController(this);
        }

        //По загрузке окна
        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            Number.Text = numOperations;
            Operations.Text = "Продажа";
        }

        /// <summary>
        /// Кнопка назад
        /// скрывает окно и отображает родительское
        /// </summary>
        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            controller.SaleGoClientClick();
        }

        /// <summary>
        /// Кнопка далее.
        /// Создает заявку с указанными полями.
        /// </summary>
        private void Next_Click (object sender, RoutedEventArgs e)
        {
            controller.SaleNextClick(client);
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
