using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace RealtorAgency__Course_work_
{
    public class ClientController : ABSOLUTE_CONTROLL
    {
        //Поля 
        private Client window;


        //Методы
        public ClientController (Client window)
        {
            this.window = window;
        }

        //Обработка кнопки  удаления
        public void PushButtonDelete ()
        {
            try
            {
                if (window.clientsGrid.SelectedItems != null && window.clientsGrid.SelectedIndex != -1)
                {
                    int index = window.clientsGrid.SelectedIndex;
                    //Удаление контакта из датагрид
                    for (int i = 0; i < window.clientsGrid.SelectedItems.Count; i++)
                    {
                        DataRowView datarowView = window.clientsGrid.SelectedItems[i] as DataRowView;
                        if (datarowView != null)
                        {
                            DataRow dataRow = (DataRow) datarowView.Row;
                            Clientas client = new Clientas(int.Parse(dataRow[0].ToString()), dataRow[1].ToString(),
                                dataRow[2].ToString(), dataRow[3].ToString(), dataRow[4].ToString());
                            //Удалить контакт из списка контакто 
                            mngRiealtorAgency.Agency.DeleteClientList(client);
                            dataRow.Delete();
                        }
                    }
                }
                //Обновить нашу БД с клиентами
                mngRiealtorAgency.Agency.GetWorkerBD.UpdateDBandList();
            }
            catch (Exception)
            {
                MessageBox.Show("Не шалите");
            }
        }

        //Обработка надатия кнопки Добавить
        public void PushButtonAddClientas()
        {
            AddedClient windowClient = new AddedClient(mngRiealtorAgency.Agency);
            windowClient.Owner = window;
            windowClient.ShowDialog();
            window.clientsGrid.Items.Refresh();
        }

        //обработка кнопки Инфо
        public void PushButtonInfo()
        {
            if (window.clientsGrid.SelectedItems != null && window.clientsGrid.SelectedIndex != -1)
            {
                try
                {
                    DataRowView fullName = (DataRowView) window.clientsGrid.SelectedItems[0];
                    int index = int.Parse(fullName.Row.ItemArray[0].ToString());

                    About about = new About(mngRiealtorAgency.Agency.GetClientID(index));
                    about.Owner = (Client) window;
                    about.ShowDialog();

                }
                //на случай выделенеи пустой строки
                catch (InvalidCastException)
                {
                    MessageBox.Show("Выберите не пустую строку!");
                }
            }
        }

    }

}
