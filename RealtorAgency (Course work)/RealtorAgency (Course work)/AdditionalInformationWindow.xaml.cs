using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RealtorAgency__Course_work_
{
    /// <summary>
    /// Окно дополнительной информации
    /// </summary>
    public partial class Additional_InformationWindow : Window
    {

        private Clientas forClient = null;
        private Clientas fromClient = null;
        private int num;

        public Additional_InformationWindow (Clientas client, Clientas client2,int idApplication)
        {
            InitializeComponent();
            forClient = client;
            fromClient = client2;
            num = idApplication;
        }

        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            OfferPanel.Text = string.Format("Предложение для: {0} {1} {2}",
                forClient.lastName,forClient.name,forClient.patronymic);

            OfferPanel2.Text = string.Format("От: {0} {1} {2}",
                fromClient.lastName, fromClient.name, fromClient.patronymic);

            string tpy = null;
            string offers = null;

            if (fromClient.application[fromClient.GetApplication(num)].GetTypeApplication() == Operation.SALE)
            {
                offers = ((Sale) (fromClient.application[fromClient.GetApplication(num)])).ToString();
                tpy = "продать";
            }
            if (fromClient.application[fromClient.GetApplication(num)].GetTypeApplication() == Operation.EXCHANGE)
            {
                offers = ((Exchange) (fromClient.application[fromClient.GetApplication(num)])).ToString();
                tpy = "обменять";
            }
            if (fromClient.application[fromClient.GetApplication(num)].GetTypeApplication() == Operation.PURCHASE)
            {
                offers = ((Purchase) (fromClient.application[fromClient.GetApplication(num)])).ToString();
                tpy = "купить";
            }
            

            OfferText.Text = string.Format("{0} {1} {2} предлагает {3} дом:\r\n{4}",
                 fromClient.lastName, fromClient.name, fromClient.patronymic,tpy,offers);

            Phone.Text = string.Format("Для связи: {0}", fromClient.phone);

        }

        private void GoClient_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
