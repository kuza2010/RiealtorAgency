
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace RealtorAgency__Course_work_.Controllers.AboutControllers
{
    class AboutController : ABSOLUTE_CONTROLL
    {
        private About window = null;

        public AboutController (About window)
        {
            this.window = window;
        }

        //Обработка события нажатия на кнопку удалить
        public void AboutDeleteClick (DataGrid applications)
        {
            string iDClient = null;
            string iD = null;
            if (applications.SelectedItems != null && applications.SelectedIndex != -1)
            {
                //Удаление контакта из датагрид
                for (int i = 0; i < applications.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = applications.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow) datarowView.Row;
                        iD = dataRow.ItemArray[0].ToString();
                        iDClient = dataRow.ItemArray[1].ToString();

                        dataRow.Delete();
                    }
                }
                //Обновить нашу БД 
            mngRiealtorAgency.Agency.DelDBApplication(iD, iDClient);
            }   
        }

        //Обработка события нажатия на кнопку добавить
        public void AboutAddClick (Clientas client)
        {
            AddApplication application = new AddApplication(client, mngRiealtorAgency.Agency);
            application.Owner = window;
            application.ShowDialog();
        }

        //Обработка двойного щелчка по гриду заявок
        public void AboutApplicationDoubleClick (DataGrid applications)
        {
            if (applications.SelectedItems != null && applications.SelectedIndex != -1)
            {
                for (int i = 0; i < applications.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = applications.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow) datarowView.Row;
                        window.FillOffers(dataRow);
                    }
                }
            }
        }

        //Обработка двойного щелчка по гриду предложений
        public void AboutOffersDoubleClick (DataGrid offers, DataGrid applications, Clientas client)
        {
            if (offers.SelectedItems != null && applications.SelectedIndex != -1)
            {
                for (int i = 0; i < offers.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = offers.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow) datarowView.Row;
                        Additional_InformationWindow infWindow = new Additional_InformationWindow(client,
                           mngRiealtorAgency.Agency.GetClientIDbyAppl(int.Parse(dataRow[2].ToString())),
                            int.Parse(dataRow[2].ToString()));

                        infWindow.Owner = window;
                        infWindow.ShowDialog();
                    }
                }
            }
        }

    }
}
