using System.Collections.Generic;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс описания логики клиента
    /// </summary>
    public class Clientas
    {
        //Поля, свойства
        public int ID { get; private set; }
        public string phone { get; private set;}
        public string name { get; private set; }
        public string lastName { get; private set; }
        public string patronymic { get; private set; }
        //Все операции клиента (заявки)
        public List<Operations>application { get; private set; }

        //Методы 
        public Clientas (string lastName, string name, string patronymic ,string telephome)
        {
            this.name = name;
            this.patronymic = patronymic;
            this.lastName = lastName;
            phone = telephome;

            this.application = new List<Operations>();
        }

        public Clientas (int id, string lastName, string name, string patronymic, string telephome)
        {
            this.name = name;
            this.patronymic = patronymic;
            this.lastName = lastName;
            phone = telephome;
            ID = id;

            this.application = new List<Operations>();
        }
        
        /// <summary>
        /// получить индекс заявки с нужным номером
        /// </summary>
        /// <param name="id">Номер заявки</param>
        /// <returns>Заявку с нужным номером</returns>
        public int GetApplication(int id)
        {
            for(int i=0; i<application.Count; i++)
            {
                if (application[i].number == id)
                    return i;
            }
            return -1;
        }

        public static bool operator == (Clientas client, Clientas client2)
        {
            if (client.name.Equals(client2.name)&&
                client2.lastName.Equals(client.lastName)&&
                client.patronymic.Equals(client2.patronymic) &&
                client.ID == client2.ID) return true;
            else return false;
        }

        public static bool operator != (Clientas client, Clientas client2)
        {
            if (client.name.Equals(client2.name) &&
                client2.lastName.Equals(client.lastName) &&
                client.patronymic.Equals(client2.patronymic) &&
                client.ID == client2.ID) return false;
            else return true;
        }

        public override bool Equals (object obj)
        {
            if (obj == null) return false;
            if (obj is Clientas)
            {
                Clientas client = (Clientas) obj;
                return this.Equals(client);
            }
            else
                return false;
        }

        public bool Equals(Clientas client)
        {
            if (client.name.Equals(this.name) &&
                this.lastName.Equals(client.lastName) &&
                client.patronymic.Equals(this.patronymic)&&
                client.ID==this.ID)
                return true;
            else return false;
        }

        /// <summary>
        /// Добавление заявки данному клиенту
        /// </summary>
        /// <param name="home"> Массив домов</param>
        /// <param name="operat">Тип операции</param>
        /// <param name="num">Номер заявки</param>
        /// <param name="desire">Пожелания</param>
        public void AddOperation(Home[] home, Operation operat, string num, string desire)
        {
            if (operat == Operation.SALE && home.Length == 1)
                application.Add(new Sale(home[0], num, desire));
            else if (operat == Operation.PURCHASE && home.Length == 1)
                application.Add(new Purchase(home[0], num, desire));
            else if (operat == Operation.EXCHANGE && home.Length == 2)
                application.Add(new Exchange(home[0], home[1], num, desire));
        }

        /// <summary>
        /// Содержится ли у данного клиента заявка
        /// с номером num
        /// </summary>
        /// <param name="num">Номер заявки</param>
        /// <returns> Истина если заявка с таким номером есть</returns>
        public bool ContainsApplicationNum (int num)
        {
            foreach(Operations i in application)
            {
                if (i.number == num)
                    return true;
                return false;
            }
            return false;
        }

        /// <summary>
        /// Вернуть заявку с таким номером
        /// </summary>
        /// <param name="id">Номер заявки</param>
        /// <returns>Заявка с указанным номером</returns>
        public Operations GetApplicationByNum(int id)
        {
            foreach(Operations i in application)
            {
                if (i.number == id)
                    return i;
            }
            return null;
        }

    }

    public enum Operation
    {
        SALE, EXCHANGE, PURCHASE, NULL
    };

}
