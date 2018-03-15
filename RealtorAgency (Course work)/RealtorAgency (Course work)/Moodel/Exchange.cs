using RealtorAgency__Course_work_.Moodel;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс описания логики Обмeна дома
    /// </summary>
    class Exchange:Operations, IExch
    {
        //Поля 
        private Home dreamHome;     //Дом, на который хотите поменять свой

        public Home Home2
        {
            get { return dreamHome; }
        }


        //Методы
        public Exchange (Home home,Home dreamHome ,string num,string desire) : base(home, num, desire)
        {
            tpy = Operation.EXCHANGE;
            this.dreamHome = dreamHome;
        }

        public override string ToString ()
        {
            return string.Format("Имеющаяся квартира:\r\n*адрес - {0},\r\n*площадь - {1}, количество комнат - {2}, цена - {3} \r\nКвартира для обмена: \r\n*адрес - {4},\r\n*площадь - {5}, количество комнат - {6}, цена - {7}",
                sweetHome.Adress, sweetHome.Area, sweetHome.NumRoom, sweetHome.Price,
                dreamHome.Adress, dreamHome.Area, dreamHome.NumRoom, dreamHome.Price);
        }

        public bool AppropriateHome (Home comparisonSweetHome, Home comparisonDreamHome)
        {
            // 0 - min :  1 - max ДОМ ДЛЯ ОБМЕНА
            int[] comparisonSweetPrice = new int[2];
            comparisonSweetPrice = comparisonSweetHome.MinMaxSum;
            // 0 - min :  1 - max ЖЕЛАЕМЫЙ ДОМ
            int[] comparisonDreamPrice = new int[2];
            comparisonDreamPrice = comparisonDreamHome.MinMaxSum;


            int[] realSweetPrice = new int[2];
            realSweetPrice = this.Home.MinMaxSum;
            int[] realDreamPrice = new int[2];
            realDreamPrice = ((Exchange) this).Home2.MinMaxSum;


            string[] comparisonSweetAdress = comparisonSweetHome.GetCityDistrStreer;
            string[] comparisonDreamAdress = comparisonDreamHome.GetCityDistrStreer;

            string[] realSweetAdress = this.Home.GetCityDistrStreer;
            string[] realDreamAdress = ((Exchange) this).Home2.GetCityDistrStreer;


            if (comparisonSweetHome.NumRoom != ((Exchange) this).Home2.NumRoom ||
                comparisonDreamHome.NumRoom != this.Home.NumRoom)
                return false;
            if (comparisonSweetPrice[0] * 0.95 > realDreamPrice[1]                                        //Минимальная цена нашего дома+5% меньше минимальной цены предложенного имеющегося дома 
                || comparisonDreamPrice[0] * 0.95 > realSweetPrice[0]                                         //или если цена  дома который хотим + 5% меньше минимальной цены дома который предложили
               || realDreamPrice[0] * 0.95 > comparisonSweetPrice[1])
                return false;
            if ((double) (comparisonDreamHome.Area * 0.90) > (double) this.Home.Area
                || (double) (comparisonSweetHome.Area) < (double) ((Exchange) this).Home2.Area * 0.9)
                return false;
            if (!comparisonSweetAdress[0].Equals(realDreamAdress[0]) ||
                !realSweetAdress[0].Equals(comparisonDreamAdress[0]))
                return false;

            return true;

        }
    }
}
