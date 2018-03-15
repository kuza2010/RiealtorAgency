using System.Collections.Generic;
using System.Data;
using RealtorAgency__Course_work_.Moodel;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс описания логики работы риелторского агенства
    /// </summary>
    public class RiealtorAgencyDB
    {
        //ПОЛЯ
        private DataBaseWorker workerDB=null;                   //Все виды работы с БД
        private MngrClient manager;                             //Менеджер Клиентов


        //Свойства
        public string connectionString { get; private set; }
        public Clientas this[int index]                         //индексирующее свойство
        {
            get
            {
                return manager[index];
            }
        }
        public List<Clientas> GetListClient
        {
            get
            {
                return manager.GetListClient;
            }
        }
        public MngrClient GetMngrClient
        {
            get
            {
                return manager;
            }
        }

        public DataBaseWorker GetWorkerBD
        {
            get
            {
                return workerDB;
            }
        }
      

        //МЕТОДЫ
        public RiealtorAgencyDB (string connectionString)
        {
            this.connectionString = connectionString;
            workerDB = new DataBaseWorker(connectionString, this);
            manager = new MngrClient(this);

            workerDB.FillDataSet();                                      //Заполнение DataSet
            manager.StartClientList();                                   //Заполнение ckientList
        }

        public string GetNextNum()
        {
           return manager.GetNextNum();
        }

        public Clientas GetClientID(int id)
        {
            return manager.GetClientID(id);
        }

        public Clientas GetClientIDbyAppl (int id)
        {
            return manager.GetClientIDbyAppl(id);
        }
       
        public bool ContainsApplicationNum (int num)
        {
            return manager.ContainsApplicationNum(num);
        }
        
        public List<Clientas> ClientsExceptID(int id)
        {
            return manager.ClientsExceptID(id);
        }

        public void DeleteClientList (Clientas client)
        {
            manager.DeleteClientList(client);
        }

        public void FillClient ()
        {
            manager.FillClient();
        }

        public void AddClient (Clientas client)
        {
            manager.AddClient(client);
        }

        public void DelDBApplication (string id, string iDClient)
        {
            workerDB.DelDBApplication(id, iDClient);
            manager.DeleteApplication(id, iDClient);
        }

        public void AddApplication (Clientas client)
        {
            workerDB.AddApplication(client);
        }

        /// <summary>
        /// Получение списка предложений
        /// </summary>
        /// <param name="idClient">Номер клиента</param>
        /// <param name="idApplication">Номер заявки</param>
        /// <param name="offers">Таблица предложений</param>
        public void GetListOffers (string idClient, string idApplication, DataTable offers)
        {
            int INTid = int.Parse(idApplication);
            string tpy;

            //Очищаем записи
            offers.Clear();
            if (offers == null)
                offers = new DataTable("List offers");

            //Получаем клиента для которого нужно вывести предложения
            Clientas client = GetClientID(int.Parse(idClient));

            //Заполнить лист потенциальных предложений
            List<Clientas> pList = ClientsExceptID(int.Parse(idClient));


            //Получить тип операции
            if (client.GetApplicationByNum(INTid).GetTypeApplication() == Operation.EXCHANGE)
                tpy = "Обмен";
            else if (client.GetApplicationByNum(INTid).GetTypeApplication() == Operation.SALE)
                tpy = "Продажа";
            else if (client.GetApplicationByNum(INTid).GetTypeApplication() == Operation.PURCHASE)
                tpy = "Покупка";
            else tpy = null;

            //Случай с продажей
            if (tpy.Equals("Продажа"))
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    for (int j = 0; j < pList[i].application.Count; j++)
                    {
                        //Отбираем заявки с типом = ПОКУПКА
                        if (pList[i].application[j].GetTypeApplication() == Operation.PURCHASE &&
                           ((Purchase)pList[i].application[j]).AppropriateHome(client.GetApplicationByNum(INTid).Home))
                        {
                            DataRow newRow;
                            newRow = offers.NewRow();
                            newRow["Тип операции"] = "Покупка";
                            newRow["Информация о заявке"] = ((Purchase) pList[i].application[j]).ToString();
                            newRow["Номер заявки"] = pList[i].application[j].number;
                            offers.Rows.Add(newRow);
                        }
                    }
                }
            }
            else if(tpy.Equals("Покупка"))
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    for (int j = 0; j < pList[i].application.Count; j++)
                    {
                        //Отбираем заявки с типом = Продажа
                        if (pList[i].application[j].GetTypeApplication() == Operation.SALE && 
                           ((Sale)pList[i].application[j]).AppropriateHome(client.GetApplicationByNum(INTid).Home))
                        {
                            DataRow newRow;
                            newRow = offers.NewRow();
                            newRow["Тип операции"] = "Продажа";
                            newRow["Информация о заявке"] = ((Sale) pList[i].application[j]).ToString();
                            newRow["Номер заявки"] = pList[i].application[j].number;
                            offers.Rows.Add(newRow);
                        }
                    }
                }
            }
            else if (tpy.Equals("Обмен"))
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    for (int j = 0; j < pList[i].application.Count; j++)
                    {
                        //Отбираем заявки с типом = Продажа
                        if (pList[i].application[j].GetTypeApplication() == Operation.EXCHANGE &&
                           ((Exchange)pList[i].application[j]).AppropriateHome(((Exchange) client.GetApplicationByNum(INTid)).Home,
                                ((Exchange) client.GetApplicationByNum(INTid)).Home2))
                        {
                            DataRow newRow;
                            newRow = offers.NewRow();
                            newRow["Тип операции"] = "Обмен";
                            newRow["Информация о заявке"] = ((Exchange) pList[i].application[j]).ToString();
                            newRow["Номер заявки"] = pList[i].application[j].number;
                            offers.Rows.Add(newRow);
                        }
                    }
                }
            }
        }
    }

}
