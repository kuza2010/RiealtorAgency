using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using RealtorAgency__Course_work_.Controllers.AboutControllers;
using System.Configuration;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Логика работы с клиентом
    /// отображаются все заявки и все предложения
    /// </summary>
    public partial class About : Window
    {
        //Поля
        private AboutController controll;

        private DataTable dataTable = null;                                    //Таблица заявок клиента
        private DataTable dataOffers = null;                                   //Таблица предложений 
        private Clientas client = null;                                        //Сам клиент


        //Методы
        public About (Clientas client)
        {
            InitializeComponent();
            this.client = client;
            controll = new AboutController(this);
            //заполнение таблицы
            FillDataTables();
        }

        //по загрузке
        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            FullName.Text = String.Format("{0} {1} {2}", client.lastName, client.name, client.patronymic);  
            applications.ItemsSource = dataTable.DefaultView;
            offers.ItemsSource = dataOffers.DefaultView;
        }

        /// <summary>
        /// Заполняет таблицу данными из бд
        /// для определенного клиента
        /// </summary>
        private void FillDataTables ()
        {
            dataOffers = new DataTable("List offers");

            dataOffers.Columns.Add("Тип операции", typeof(string));
            dataOffers.Columns.Add("Информация о заявке", typeof(string));
            dataOffers.Columns.Add("Номер заявки", typeof(string));


            dataTable = new DataTable("Application's");
            SqlDataAdapter sqlDAApplication = new SqlDataAdapter(String.Format("Select * from Заявки WHERE id_Клиента={0}", client.ID), ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommandBuilder sqlCBClient = new SqlCommandBuilder(sqlDAApplication);

            //Заполнили таблицу датаТейбл
            sqlDAApplication.Fill(dataTable);
        }

        //Кнопка назад
        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка Удалить
        /// Удаление заявки из списка и Бд
        /// </summary>
        private void Delete_Click (object sender, RoutedEventArgs e)
        {
            controll.AboutDeleteClick(applications);
        }

        /// <summary>
        /// Кнопка добавить
        /// Открытие окна для добавления заявки
        /// </summary>
        private void Add_Click (object sender, RoutedEventArgs e)
        {
            controll.AboutAddClick(client);
        }

        /// <summary>
        /// Обновление представления данных в датаГрид
        /// </summary>
        public void Refresh ()
        {
            dataTable.Clear();
            SqlDataAdapter sqlDAApplication = new SqlDataAdapter(String.Format("Select * from Заявки WHERE id_Клиента={0}", client.ID), ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommandBuilder sqlCBClient = new SqlCommandBuilder(sqlDAApplication);

            //Заполнили таблицу датаТейбл
            sqlDAApplication.Fill(dataTable);
        }

        /// <summary>
        /// Осуществляется вызов и вывод на эеран
        /// списка предложенных квартир
        /// </summary>
        private void applications_MouseDoubleClick (object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            controll.AboutApplicationDoubleClick(applications);
        }

        /// <summary>
        /// Заполнение дата грида (предложения)
        /// </summary>
        /// <param name="dataRow">Строка из датагрид</param>
        public void FillOffers (DataRow dataRow)
        {
            string idApplication = dataRow.ItemArray[0].ToString();
            string idClient = dataRow.ItemArray[1].ToString();

            controll.GetManager.Agency.GetListOffers(idClient, idApplication, dataOffers);
        }

        /// <summary>
        /// Вызов окна дополнительной информации
        /// </summary>
        private void offers_MouseDoubleClick (object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            controll.AboutOffersDoubleClick(offers, applications, client);
        }

    }

}
