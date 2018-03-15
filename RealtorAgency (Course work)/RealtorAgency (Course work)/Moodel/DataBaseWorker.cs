using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RealtorAgency__Course_work_.Moodel
{
    public class DataBaseWorker
    {
        //Поля 
        private DataSet dataSet;
        private string connectStr;
        private RiealtorAgencyDB agency;

        //свойства
        public DataSet GetDataSet
        {
            get
            {
                return dataSet;
            }
        }


        //Методы
        public DataBaseWorker(string connectionStr, RiealtorAgencyDB rA)
        {
            connectStr = connectionStr;
            agency = rA;
        }

        public void FillDataSet()
        {
            //Адаптеры 
            SqlDataAdapter sqlDAClient = new SqlDataAdapter("Select * from Клиенты", connectStr);
            SqlDataAdapter sqlDAApplication = new SqlDataAdapter("Select * from Заявки", connectStr);
            SqlDataAdapter sqlDAApartment = new SqlDataAdapter("Select * from Квартиры", connectStr);

            //Автоматически сгенерировать команды
            SqlCommandBuilder sqlCBClient = new SqlCommandBuilder(sqlDAClient);
            SqlCommandBuilder sqlCBApplication = new SqlCommandBuilder(sqlDAApplication);
            SqlCommandBuilder sqlCBApartment = new SqlCommandBuilder(sqlDAApartment);

            //Заполнить таблицы в DataSet
            dataSet = new DataSet("RiealtorAgency");
            sqlDAClient.Fill(dataSet, "Клиенты");
            sqlDAApplication.Fill(dataSet, "Заявки");
            sqlDAApartment.Fill(dataSet, "Квартиры");

            BuildTableRelationship();
        }

        private void BuildTableRelationship ()
        {
            dataSet.Relations.Add(dataSet.Tables["Заявки"].Columns["Заявка"],
               dataSet.Tables["Квартиры"].Columns["Id_Заявки"]);

            dataSet.Relations.Add(dataSet.Tables["Клиенты"].Columns["ID"],
               dataSet.Tables["Заявки"].Columns["Id_Клиента"]);
        }

        public void UpdateDBandList ()
        {
            //Обновление таблиц Клиенты,Заявки,Квартиры
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from Заявки", connectStr);
            SqlDataAdapter adapter3 = new SqlDataAdapter("Select * from Квартиры", connectStr);
         
            SqlCommandBuilder build2 = new SqlCommandBuilder(adapter2);
            SqlCommandBuilder build3 = new SqlCommandBuilder(adapter3);


            adapter3.InsertCommand = new SqlCommand("sp_DeleteAppartament");
            adapter3.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter3.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, "ID"));

            adapter3.Update(dataSet.Tables["Квартиры"]);


            adapter2.InsertCommand = new SqlCommand("sp_DeleteApplication");
            adapter2.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 0, "ID"));

            adapter2.Update(dataSet.Tables["Заявки"]);

            ClientUpdate();
           
        }

        public void ClientUpdate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Клиенты", connectStr);
            SqlCommandBuilder build = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = new SqlCommand("sp_InsertClient");
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Имя", SqlDbType.VarChar, 25, "Имя"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Фамилия", SqlDbType.VarChar, 25, "Фамилия"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Отчество", SqlDbType.VarChar, 25, "Отчество"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Дата_регистрации", SqlDbType.Date, 0, "Дата регистрации"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Телефон", SqlDbType.VarChar, 25, "Телефон"));
            SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "Id");
            parameter.Direction = ParameterDirection.Output;//выходной параметр

            adapter.Update(dataSet.Tables["Клиенты"]);
            //заполнение и дозапись списка clientList
            agency.FillClient();
        }

        public void UpdateDBAppartamentApplication ()
        { 
            //Обновление ЗАЯВКИ
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from Заявки", connectStr);
            SqlCommandBuilder build2 = new SqlCommandBuilder(adapter2);

            adapter2.InsertCommand = new SqlCommand("sp_InsertAppl");
            adapter2.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@Заявка", SqlDbType.Int, 0, "Заявка"));
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@Id_клиента", SqlDbType.Int, 0, "Id_клиента"));
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@Тип_операции", SqlDbType.VarChar, 10, "Тип операции"));
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@О_предложении", SqlDbType.VarChar, 350, "О предложении"));
            adapter2.InsertCommand.Parameters.Add(new SqlParameter("@Пожелания", SqlDbType.VarChar, 255, "Пожелания"));

            adapter2.Update(dataSet.Tables["Заявки"]);

            //Обновление КВАРТИРЫ
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Квартиры", connectStr);
            SqlCommandBuilder build = new SqlCommandBuilder(adapter);

            adapter.InsertCommand = new SqlCommand("sp_InsertAppartamentas");
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Id_Заявки", SqlDbType.Int, 0, "Id_Заявки"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Тип_операции", SqlDbType.VarChar, 10, "Тип операции"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Количество_комнат_им", SqlDbType.Int, 0, "Количество комнат(им)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Стоимость_им", SqlDbType.VarChar, 50, "Стоимость(им)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Площадь_им", SqlDbType.Float, 0, "Площадь(им)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Адрес_им", SqlDbType.VarChar, 255, "Адрес(им)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Количество_комнат_жел", SqlDbType.Int, 0, "Количество комнат(жел)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Стоимость_жел", SqlDbType.VarChar, 50, "Стоимость(жел)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Площадь_жел", SqlDbType.Float, 0, "Площадь(жел)"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Адрес_жел", SqlDbType.VarChar, 255, "Адрес(жел)"));

            adapter.Update(dataSet.Tables["Квартиры"]);

        }

        public void DelDBApplication (string id, string iDClient)
        {
            //Удаление заявки из таблицы Квартиры вБД
            string command = String.Format("Delete from Квартиры Where Id_Заявки={0}", id);
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            //Удаление из таблицы Заявки в БД
            command = String.Format("Delete from Заявки Where Заявка={0}", id);
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            //Удаление из Table[Заявки]
            DataRow[] rowToDel = dataSet.Tables["Заявки"].Select(string.Format("Заявка={0}", id));
            //ОШИБКА?!
            rowToDel.First().Delete();
            dataSet.Tables["Заявки"].AcceptChanges();

            //Удаление из Table[Квартиры]
            rowToDel = dataSet.Tables["Квартиры"].Select(string.Format("Id_Заявки={0}", id));
            for (int i = 0; i < rowToDel.Length; i++)
                rowToDel[i].Delete();
            dataSet.Tables["Квартиры"].AcceptChanges();
        }

        public void AddApplication (Clientas client)
        {
            DataRow newRow;
            DataTable dt = dataSet.Tables["Квартиры"];
            DataTable dt2 = dataSet.Tables["Заявки"];
            //Тип операции
            string tpy;

            if (client.application.Last().GetTypeApplication() == Operation.EXCHANGE)
                tpy = "Обмен";
            else if (client.application.Last().GetTypeApplication() == Operation.SALE)
                tpy = "Продажа";
            else if (client.application.Last().GetTypeApplication() == Operation.PURCHASE)
                tpy = "Покупка";
            else tpy = null;


            string q = client.application.Last().ToString();
            //Добавить запись в DataTable Заявки
            newRow = dt2.NewRow();
            newRow["Заявка"] = client.application.Last().number;
            newRow["Id_Клиента"] = client.ID;
            newRow["Тип операции"] = tpy;
            newRow["О предложении"] = client.application.Last().ToString();
            newRow["Пожелания"] = client.application.Last().Desire;
            dt2.Rows.Add(newRow);

            //Добавить запись в DataTable Квартиры
            if (tpy.Equals("Обмен"))
            {
                //случай с обменом
                newRow = dt.NewRow();
                newRow["Id_Заявки"] = client.application.Last().number;
                newRow["Тип операции"] = tpy;
                newRow["Количество комнат(им)"] = client.application.Last().Home.NumRoom;
                newRow["Стоимость(им)"] = client.application.Last().Home.Price;
                newRow["Площадь(им)"] = client.application.Last().Home.Area;
                newRow["Адрес(им)"] = client.application.Last().Home.Adress;
                newRow["Количество комнат(жел)"] = ((Exchange) client.application.Last()).Home2.NumRoom;
                newRow["Стоимость(жел)"] = ((Exchange) client.application.Last()).Home2.Price;
                newRow["Площадь(жел)"] = ((Exchange) client.application.Last()).Home2.Area;
                newRow["Адрес(жел)"] = ((Exchange) client.application.Last()).Home2.Adress;
                dt.Rows.Add(newRow);
            }
            else if (tpy.Equals("Продажа"))
            {
                //случай с продажей
                tpy = "Продажа";
                newRow = dt.NewRow();
                newRow["Id_Заявки"] = client.application.Last().number;
                newRow["Тип операции"] = tpy;
                newRow["Количество комнат(им)"] = client.application.Last().Home.NumRoom;
                newRow["Стоимость(им)"] = client.application.Last().Home.Price;
                newRow["Площадь(им)"] = client.application.Last().Home.Area;
                newRow["Адрес(им)"] = client.application.Last().Home.Adress;
                dt.Rows.Add(newRow);
            }
            else if (tpy.Equals("Покупка"))
            {
                //случай с покупкой
                tpy = "Покупка";
                newRow = dt.NewRow();
                newRow["Id_Заявки"] = client.application.Last().number;
                newRow["Тип операции"] = tpy;
                newRow["Количество комнат(жел)"] = client.application.Last().Home.NumRoom;
                newRow["Стоимость(жел)"] = client.application.Last().Home.Price;
                newRow["Площадь(жел)"] = client.application.Last().Home.Area;
                newRow["Адрес(жел)"] = client.application.Last().Home.Adress;
                dt.Rows.Add(newRow);
            }
            else tpy = null;

            //обновить бд
            UpdateDBAppartamentApplication();
        }

    }
}
