using System;
using System.Collections.Generic;
using System.Data;


namespace RealtorAgency__Course_work_.Moodel
{
    public class MngrClient
    {
        private List<Clientas> clientList = null;
        private RiealtorAgencyDB agency;


        //Свойства 
        public Clientas this[int index]                         //индексирующее свойство
        {
            get
            {
                return clientList[index];
            }
        }

        public List<Clientas> GetListClient
        {
            get
            {
                return clientList;
            }
        }


        //Методы 
        public MngrClient(RiealtorAgencyDB agency)
        {
            clientList = new List<Clientas>();
            this.agency = agency;
        }

        /// <summary>
        /// Получить следующий номер заявки
        /// </summary>
        /// <returns>номер заявки</returns>
        public string GetNextNum ()
        {
            int maxNum = -1;
            foreach (Clientas i in clientList)
                foreach (Operations j in i.application)
                    if (j.number > maxNum)
                        maxNum = j.number;
            return string.Format("{0}", maxNum + 1);
        }

        /// <summary>
        /// Удалить выбранный контакт
        /// </summary>
        /// <param name="client">Контак для удаления</param>
        public void DeleteClientList (Clientas client)
        {
            ////Если клиент есть в листе
            if (clientList.Contains(client))
                for (int i = 0; i < clientList.Count; i++)
                {
                    if (clientList[i].Equals(client))
                    {
                        clientList.RemoveAt(i);     //Удалили его и все его заявки
                    }
                }
        }

        /// <summary>
        /// Вернуть клиента с таким ID
        /// </summary>
        /// <param name="id">ID нужного клиента</param>
        /// <returns>Клиента с нужным ID</returns>
        public Clientas GetClientID (int id)
        {
            foreach (Clientas i in clientList)
            {
                if (i.ID == id)
                    return i;
            }
            return null;
        }

        /// <summary>
        /// Получить клиента с указанным номером заявки
        /// </summary>
        /// <param name="id">Номер заявки</param>
        /// <returns>Клмент с указанным номером заявки</returns>
        public Clientas GetClientIDbyAppl (int id)
        {
            foreach (Clientas i in clientList)
            {
                foreach (Operations j in i.application)
                {
                    if (j.number == id)
                        return i;
                }
            }
            return null;
        }

        /// <summary>
        /// Содержится ли в конторе заявка
        /// с номером num
        /// </summary>
        /// <param name="num">Номер заявки</param>
        /// <returns> Истина если заявка с таким номером есть</returns>
        public bool ContainsApplicationNum (int num)
        {
            foreach (Clientas i in clientList)
                foreach (Operations j in i.application)
                {
                    if (j.number == num)
                        return true;
                }
            return false;
        }

        /// <summary>
        /// Вернуть список клиентов без клиента с указанным ID
        /// </summary>
        /// <param name="id">Клиент для исключения</param>
        /// <returns> новый список клиентов</returns>
        public List<Clientas> ClientsExceptID (int id)
        {
            List<Clientas> tList = new List<Clientas>();
            if (clientList.Count == 0)
                return null;
            foreach (Clientas i in clientList)
            {
                if (i.ID != id)
                    tList.Add(i);
            }
            return tList;
        }

        public void DeleteApplication(string id, string iDClient)
        {
            GetClientID(int.Parse(iDClient)).application.RemoveAt
               (GetClientID(int.Parse(iDClient)).GetApplication(int.Parse(id)));
        }

        /// <summary>
        /// Начальное заполение clientList
        /// </summary>
        public void StartClientList ()
        {
            //Заполнить ФИО клиентов
            DataTableReader dtReader = agency.GetWorkerBD.GetDataSet.Tables["Клиенты"].CreateDataReader();
            while (dtReader.Read())
            {
                clientList.Add(new Clientas((int) dtReader["ID"], (string) dtReader["Фамилия"],
                     (string) dtReader["Имя"], (string) dtReader["Отчество"], (string) dtReader["Телефон"]));
            }


            dtReader = agency.GetWorkerBD.GetDataSet.Tables["Заявки"].CreateDataReader();
            while (dtReader.Read())
            {
                //ПРОДАЖА
                if (((string) dtReader["Тип операции"]).Equals("Продажа"))
                {
                    //Выбрать все строки из таблицы Квартиры со связанным id (ну вообще она одна)
                    DataRow[] row = agency.GetWorkerBD.GetDataSet.Tables["Квартиры"].
                        Select(String.Format("id_Заявки={0}", (int) dtReader["Заявка"]));

                    //Создать дом для продажи
                    Home[] myHome = new Home[]
                        { new Home(row[0]["Количество комнат(им)"].ToString(),
                        row[0]["Площадь(им)"].ToString(), row[0]["Стоимость(им)"].ToString(),
                        row[0]["Адрес(им)"].ToString())
                        };

                    //Номер заявки
                    string num = dtReader["Заявка"].ToString();

                    //Добавить щапись о продаже
                    GetClientID((int) dtReader["Id_Клиента"]).AddOperation(myHome, Operation.SALE, num, (string) dtReader["Пожелания"]);

                }
                //ПОКУПКА
                else if (((string) dtReader["Тип операции"]).Equals("Покупка"))
                {
                    //Выбрать все строки из таблицы Квартиры со связанным id (ну вообще она одна)
                    DataRow[] row = agency.GetWorkerBD.GetDataSet.Tables["Квартиры"].
                        Select(String.Format("id_Заявки={0}", (int) dtReader["Заявка"]));

                    //Создать дом для покупки
                    Home[] myHome = new Home[]
                        { new Home(row[0]["Количество комнат(жел)"].ToString(),
                        row[0]["Площадь(жел)"].ToString(), row[0]["Стоимость(жел)"].ToString(),
                        row[0]["Адрес(жел)"].ToString())
                        };

                    //Номер заявки
                    string num = dtReader["Заявка"].ToString();

                    //Добавить щапись о покупке
                    GetClientID((int) dtReader["Id_Клиента"]).AddOperation(myHome, Operation.PURCHASE, num, (string) dtReader["Пожелания"]);

                }
                //ОБМЕН 
                else if (((string) dtReader["Тип операции"]).Equals("Обмен"))
                {
                    //Выбрать все строки из таблицы Квартиры со связанным id (ну вообще она одна)
                    DataRow[] row = agency.GetWorkerBD.GetDataSet.Tables["Квартиры"].
                        Select(String.Format("id_Заявки={0}", (int) dtReader["Заявка"]));

                    //Создать 2дома для обмена
                    Home[] myHome = new Home[]
                        {
                        new Home(row[0]["Количество комнат(им)"].ToString(),
                        row[0]["Площадь(им)"].ToString(), row[0]["Стоимость(им)"].ToString(),
                        row[0]["Адрес(им)"].ToString()),
                        new Home(row[0]["Количество комнат(жел)"].ToString(),
                        row[0]["Площадь(жел)"].ToString(), row[0]["Стоимость(жел)"].ToString(),
                        row[0]["Адрес(жел)"].ToString())

                        };

                    //Номер заявки
                    string num = dtReader["Заявка"].ToString();

                    //Добавить щапись о Обмене
                    GetClientID((int) dtReader["Id_Клиента"]).AddOperation(myHome, Operation.EXCHANGE, num, (string) dtReader["Пожелания"]);
                }

            }
        }

        /// <summary>
        /// ДОзавпись клиентов
        /// </summary>
        public void FillClient ()
        {
            //Сколько строк столько и клиентов
            if (clientList.Count <agency.GetWorkerBD.GetDataSet.Tables["Клиенты"].Rows.Count)
            {
                DataRow currentRows = agency.GetWorkerBD.GetDataSet.Tables["Клиенты"].Rows[agency.GetWorkerBD.GetDataSet.Tables["Клиенты"].Rows.Count - 1];

                Clientas client = (new Clientas(int.Parse(currentRows.ItemArray[0].ToString()),
                    currentRows.ItemArray[1].ToString(), currentRows.ItemArray[2].ToString(),
                    currentRows.ItemArray[3].ToString(), currentRows.ItemArray[4].ToString()));

                //добавить в список сформированного клиента
                clientList.Add(client);
            }
        }

        public void AddClient (Clientas client)
        {
            DataTable dt = agency.GetWorkerBD.GetDataSet.Tables["Клиенты"];
            DataRow newRow = dt.NewRow();
            newRow["Фамилия"] = client.name;
            newRow["Имя"] = client.lastName;
            newRow["Отчество"] = client.patronymic;
            newRow["Дата регистрации"] = DateTime.Now.ToString();
            newRow["Телефон"] = client.phone;

            dt.Rows.Add(newRow);
            //Обновить список контактов и БД
            agency.GetWorkerBD.ClientUpdate();
        }

    }
}
