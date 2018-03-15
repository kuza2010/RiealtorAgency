
using RealtorAgency__Course_work_.Moodel;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Класс описания логики продажи дома
    /// </summary>
   public class Sale:Operations, ISalPurch
    {
        public Sale(Home home, string num, string desire):base(home, num,desire)
        {
            tpy = Operation.SALE;
        }

        //Для поля таблицы Заявки - О предложении
        public override string ToString ()
        {
            return string.Format("Квартира для продажи:\r\n*адрес - {0},\r\n*площадь - {1}, количество комнат - {2}, цена - {3}",
                sweetHome.Adress, sweetHome.Area, sweetHome.NumRoom, sweetHome.Price);
        }

        public  bool AppropriateHome (Home comparisonHome)
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
            //Если ищем квартиры для продажи
            if (realPrice[1] <= comparisonPrice[0] - comparisonPrice[0] * 0.05)
                return false;                                                                           //Если наша цена - 10% больше максимально предложенной
            if ((double) (comparisonHome.Area + comparisonHome.Area * 0.1) < (double) this.Home.Area)
                return false;                                                                           //Если наша площадь +10% меньше предложенной площади

            if (!comparisonAdress[0].Equals(realAdress[0]))
                return false;                                                                                               //Если разные города
            return true;
        }

    }
}
