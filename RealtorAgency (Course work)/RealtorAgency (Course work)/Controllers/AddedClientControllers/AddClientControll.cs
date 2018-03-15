using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RealtorAgency__Course_work_.Controllers.AddedClientControllers
{
    class AddClientControll:ABSOLUTE_CONTROLL
    {
        private AddedClient window;


        //методы
        public AddClientControll (AddedClient window)
        {
            this.window = window;
        }


        public void AddClientControllOkClick()
        {
            //если все поля заполнены
            if (window.Name.Text != "" && window.LastName.Text != "" && window.Patron.Text != "" && window.Phone.Text != "")
            {
                //Создать клиента
                Clientas client = new Clientas(window.Name.Text, window.LastName.Text, window.Patron.Text, window.Phone.Text);
                window.Visibility = Visibility.Hidden;
                //Добавить
                mngRiealtorAgency.Agency.AddClient(client);
                window.Close();
            }
            else
                MessageBox.Show("Заполните данные!");
        }

        public void AddClientControllBackClick ()
        {
            window.Close();
        }

        public void CheckSumbol (TextCompositionEventArgs e)
        {
            string validChar = @"([а-я])|[А-Я]";
            if (!Regex.IsMatch(e.Text.ToString(), validChar)) e.Handled = true;
        }

        public void CheckSubolNumber (TextCompositionEventArgs e)
        {
            string validChar = @"([0-9])";
            if (!Regex.IsMatch(e.Text.ToString(), validChar)) e.Handled = true;
        }

    }

}
