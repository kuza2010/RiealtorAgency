using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RealtorAgency__Course_work_.Controllers.SaleWindowControllers
{
   public class SaleWindowController:ABSOLUTE_CONTROLL
    {
        //Поля 
        private SaleWondow window;


        //Методы 
        public SaleWindowController(SaleWondow window)
        {
            this.window = window;
        }

        //Кнопка назад
        public void SaleGoClientClick ()
        {
            window.Owner.Visibility = Visibility.Visible;
            window.Close();
        }

        //Кнопка дальше
        public void SaleNextClick(Clientas client)
        {
            if (window.City.Text.Length >= 5 && window.District.Text.Length >= 5 && window.Street.Text.Length >= 3
                && window.NumRoom.Text != "" && window.Price.Text != "" && window.Area.Text != "" && window.Desire.Text.Length >= 5)
            {
                Home[] home = new Home[]
                {
                new Home(window.NumRoom.Text, window.Area.Text, window.Price.Text, 
                    String.Format("Город:{0}, район:{1}, улица:{2}",window.City.Text,
                        window.District.Text,window.Street.Text))
                };

                //Добавление Заявки в clientList
                client.AddOperation(home, Operation.SALE, window.Number.Text, window.Desire.Text);
                //Добавление заявки в DataTable и БД
                mngRiealtorAgency.Agency.AddApplication(client);
                //Новое отображение DataGrid
                About about = (About) window.Owner.Owner;
                about.Refresh();

                window.Owner.Close();
                window.Close();
            }
            else
                MessageBox.Show("Данные введены некорректно!");
        }

        public void CheckSumbol (TextCompositionEventArgs e)
        {
            string validChar = @"([а-я])|[А-Я]|[.]|[,]|[:]|[-]";
            if (!Regex.IsMatch(e.Text.ToString(), validChar)) e.Handled = true;
        }

        public void CheckSubolNumber (TextCompositionEventArgs e)
        {
            string validChar = @"([0-9])|[-]";
            if (!Regex.IsMatch(e.Text.ToString(), validChar)) e.Handled = true;
        }
    }
}
