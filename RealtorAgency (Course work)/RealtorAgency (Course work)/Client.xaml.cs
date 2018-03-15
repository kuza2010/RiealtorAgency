using System;
using System.Windows;
using System.Data;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Главная окно Клиентов.Содержит в себе
    ///  DataGrid со всеми клиентами, входящими в бд
    /// </summary>
    public partial class Client : Window
    {
        //Поля
        private ClientController controll;

        //Методы
        public Client ()
        {
            InitializeComponent();
            controll = new ClientController(this);
        }

        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            //Заполнение датаГРида
            clientsGrid.ItemsSource=controll.GetManager.Agency.GetWorkerBD.GetDataSet.Tables["Клиенты"].DefaultView;
        }
       
        /// <summary>
        /// Удаление клиента и всех его заявок
        /// Удаляет выделенного в dataGrid клиента
        /// </summary>
        private void deleteButton_Click (object sender, RoutedEventArgs e)
        {
            controll.PushButtonDelete();
        }

        /// <summary>
        /// Вызов окна добавления клиента
        /// </summary>
        private void AddClientas_Click (object sender, RoutedEventArgs e)
        {
            controll.PushButtonAddClientas();
        }

        /// <summary>
        /// Вывод окна информации о клиенте
        /// Визуальное представление всех заявок и предложений клиента
        /// </summary>
        private void Info_Click (object sender, RoutedEventArgs e)
        {
            controll.PushButtonInfo();
        }

    }

}
