using RealtorAgency__Course_work_.Moodel;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс для описания логики покупки дома
    /// </summary>
   public class Purchase: Operations,ISalPurch
    {
        //Методы
        public Purchase (Home home, string num, string desire) : base(home, num, desire)
        {
            tpy = Operation.PURCHASE;
        }

        public override string ToString ()
        {
            return string.Format("Квартира для покупки:\r\n*адрес - {0},\r\n*площадь - {1}, количество комнат - {2}, цена - {3}",
                sweetHome.Adress, sweetHome.Area, sweetHome.NumRoom, sweetHome.Price);
        }

        public bool AppropriateHome (Home comparisonHome)
        {
            // 0 - min :  1 - max
            //Поисе минимальной и максимальной цены дома клиента
            int[] comparisonPrice = new int[2];
            comparisonPrice = comparisonHome.MinMaxSum;

            //Поисе минимальной и максимальной цены дома для сравнения
            int[] realPrice = new int[2];
            realPrice = this.Home.MinMaxSum;

            string[] comparisonAdress = comparisonHome.GetCityDistrStreer;
            string[] realAdress = this.Home.GetCityDistrStreer;

            if (comparisonHome.NumRoom != this.Home.NumRoom)
                return false;
            if (realPrice[0] >= comparisonPrice[1] + comparisonPrice[1] * 0.05)
                return false;                                                                           //Если минимальная цена для продажи больше нашей максимальной + 5%
            if ((double) (comparisonHome.Area - comparisonHome.Area * 0.1) > (double) this.Home.Area)
                return false;                                                                            //Eесли наша площадь - 10% больше предложенной площади

            if (!comparisonAdress[0].Equals(realAdress[0]))
                return false;                                                                                               //Если разные города

            return true;

        }
    }

}
