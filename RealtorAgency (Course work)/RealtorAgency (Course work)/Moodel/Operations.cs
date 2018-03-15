namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс родитель для Всех операций
    /// (продажа.покупка,обмен)
    /// </summary>
    public class Operations
    {
        //Поля 
        protected Home sweetHome;                   //Наш дом
        protected Operation tpy;           //Тип операции
        private string desire;                      //Пожелания - просто текст (блаблабла)
        //Свойства
        public string Desire
        {
            get
            {
                return desire;
            }
        }
        public int number
        {
            get;
            private set;
        }
        public Home Home
        {
            get
            {
                return sweetHome;
            }
        }


        //Методы
        public Operations(Home home, string num, string desire)
        {
            number = int.Parse(num);
            sweetHome = home;
            this.desire = desire;
            tpy = Operation.NULL;
        }

        /// <summary>
        /// Возвращает тип операции
        /// (продажа.покупка,обмен)
        /// </summary>
        /// <returns>Тип операции</returns>
        public Operation GetTypeApplication ()
        {
            return tpy;
        }
    }
}
