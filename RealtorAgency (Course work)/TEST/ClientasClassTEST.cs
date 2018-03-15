using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealtorAgency__Course_work_;

namespace TEST
{
    [TestClass]
    public class ClientasClassTEST
    {
        [TestMethod]
        public void GetApplication_Test ()
        {
            //Создать клиента без заявок
            Clientas client = new Clientas("Петрович", "Артем", "Отчество", "8910882501");
            //получить номер заявки
            int num = client.GetApplication(4);
            Assert.AreEqual(num, -1);


            Home[] home = new Home[]
            {
                new Home("2", "50", "1500000", "NN")
            };
            client.AddOperation(home, Operation.SALE,"666", "Additional regiment");
            int num2 = client.GetApplication(666);
            Assert.AreEqual(num2, 0);
        }

        [TestMethod]
        public void Equalse_Test()
        {
            Clientas client = new Clientas("Петрович", "Артем", "Отчество", "8910882501");
            Clientas client2 = new Clientas("Петрович", "Артем", "Отчество", "8910882501");

            Assert.AreEqual(client.Equals(client2),true);

        }

        [TestMethod]
        public void ContainsApplicationNum_Test()
        {
            Clientas client = new Clientas("Петрович", "Артем", "Отчество", "8910882501");
            Home[] home = new Home[]
           {
                new Home("2", "50", "1500000", "NN")
           };
            client.AddOperation(home, Operation.SALE, "666", "Additional regiment");

            Assert.AreEqual(client.ContainsApplicationNum(666), true);
        }

        [TestMethod]
        public void GetApplicationByNum_Test()
        {
            Clientas client = new Clientas("Петрович", "Артем", "Отчество", "8910882501");
            Home[] home = new Home[]
            {
                new Home("2", "50", "1500000", "NN")
            };

            client.AddOperation(home, Operation.SALE, "666", "Additional regiment");

            Assert.AreEqual(client.GetApplicationByNum(666), client.application[0]);
        }

    }

}
