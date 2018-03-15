using System;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Логика описания дома
    /// </summary>
   public class Home
    {
        //Поля
        private int numRoom;
        private double area;
        private int minPrice;
        private int maxPrice;
        private string adress;
        //Свойства
        public int NumRoom
        {
            get
            {
                return numRoom;
            }
        }
        public double Area
        {
            get
            {
                return area;
            }
        }
        public string Price
        {
            get
            {
                if (minPrice == maxPrice)
                    return string.Format("{0}", minPrice);
                else
                    return string.Format("{0}-{1}", minPrice, maxPrice);
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
        }
        public int[] MinMaxSum
        {
            get
            {
                int []array = new int[2];
                array[0] = minPrice;
                array[1] = maxPrice;

                return array;
            }
        }
        public string []GetCityDistrStreer
        {
            get
            {
                string[] str = new string[3];
                string pAdress = adress.Replace("Город:", "");
                pAdress = pAdress.Replace("район:","");
                pAdress = pAdress.Replace("улица:", "");
                str = pAdress.Split(',');
                return str;
            }
        }

        //Методы 
        public Home (string room,string area,string price, string adress)
        {
            numRoom = int.Parse(room);
            this.area = Double.Parse(area);
            //РАзбиение строки с ценой на 2 цены. Ну или на 1
            string[] arrayPrice = price.Split('-');
            if(arrayPrice.Length==2)
            {
                int tPrice = int.Parse(arrayPrice[0]);
                int tPrice2 = int.Parse(arrayPrice[1]);
                if (tPrice > tPrice2)
                {
                    minPrice = tPrice2;
                    maxPrice = tPrice;
                }
                else
                {
                    minPrice = tPrice;
                    maxPrice = tPrice2;
                }
            }
            else
            {
                minPrice = int.Parse(price);
                maxPrice = minPrice;
            }
            this.adress = adress;
        }

    }
}
