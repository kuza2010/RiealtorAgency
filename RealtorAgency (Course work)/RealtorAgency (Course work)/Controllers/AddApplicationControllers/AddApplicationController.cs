using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace RealtorAgency__Course_work_.Controllers.AddApplicationControllers
{
    public class AddApplicationController:ABSOLUTE_CONTROLL
    {
        //Поля 
        private AddApplication window;


        //методы
        public AddApplicationController(AddApplication window)
        {
            this.window = window;
        }

        //Нажатие кнопки назад
        public void AddApplicationGoClientClick()
        {
            window.Owner.Visibility = Visibility.Visible;
            window.Close();
        }

        //Нажатие кнопки далее
        public void AddApplicationNextClick(Clientas client)
        {
            if (window.Num.Text.Equals(""))
                MessageBox.Show("Укажите номер заявки!");
            else if (mngRiealtorAgency.Agency.ContainsApplicationNum(int.Parse(window.Num.Text)))
                MessageBox.Show("Заявка с таким номером уже существует!");
            else
            {
                if (window.applicationList.SelectedIndex == 0)                                //Продажа
                {
                    SaleWondow sale = new SaleWondow(client, window.Num.Text);
                    sale.Owner = window;
                    window.Visibility = Visibility.Hidden;
                    sale.ShowDialog();
                }
                else if (window.applicationList.SelectedIndex == 1)                                //Покупка
                {
                    PurchaseWindow purchaseWindow = new PurchaseWindow(client, window.Num.Text);
                    purchaseWindow.Owner = window;
                    window.Visibility = Visibility.Hidden;
                    purchaseWindow.ShowDialog();
                }
                else if (window.applicationList.SelectedIndex == 2)                                //Обмен
                {
                    ExchangeWindow exchangeWindow = new ExchangeWindow(client, window.Num.Text);
                    exchangeWindow.Owner = window;
                    window.Visibility = Visibility.Hidden;
                    exchangeWindow.ShowDialog();
                }
            }
        }

        public void CheckSumbol(TextCompositionEventArgs e)
        {
            string validChar = @"([0-9])";
            if (!Regex.IsMatch(e.Text.ToString(), validChar)) e.Handled = true;
        }

    }
}
