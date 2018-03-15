using RealtorAgency__Course_work_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TEST
{
    /// <summary>
    /// Сводное описание для RiealtorAgencyTEST
    /// </summary>
    [TestClass]
    public class RiealtorAgencyTEST
    {
        private RiealtorAgencyDB riealtorAgency = null;

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void RiealtorAgencyTEST_Initialize()
        {
            riealtorAgency = new RiealtorAgencyDB();
        }

        /// <summary>
        /// Тест метода GetNextNum
        /// Получает следующий номер заявки
        /// Возвращает номер следующей заявки
        /// </summary>
        [TestMethod]
        public void GetNextNum_Test ()
        {
            Assert.AreEqual(riealtorAgency.GetNextNum(), "0");
        }


        /// <summary>
        /// Тест метода GetClientId
        /// Возвращает клиента с таким ID
        /// Возвращает клиента с нужным ID
        /// </summary>
        [TestMethod]
        public void GetClientId_Test()
        {
            //Добавили клиента в агенство
            riealtorAgency.GetListClient.Add(new Clientas(666,"Петрович", "Артем", "Отчество", "8910882501"));
            
            Assert.AreEqual(riealtorAgency.GetClientID(666), new Clientas(666, "Петрович", "Артем", "Отчество", "8910882501"));
        }


        /// <summary>
        /// Тест метода GetClientIdByAppl
        /// Получвет клиента с указанным номером заявки
        /// Возвращает клмента с указанным номером заявки
        /// </summary>
        [TestMethod]
        public void GetClientIdByAppl_Test()
        {
            //Добавить клиента в агенство
            riealtorAgency.GetListClient.Add(new Clientas(666, "Петрович", "Артем", "Отчество", "8910882501"));
            Home[] home = new Home[]
           {
                new Home("2", "50", "1500000", "NN")
           };
            //Добавить операцию продажи клиенту 0
            riealtorAgency[0].AddOperation(home, Clientas.operation.SALE, "666", "Additional regiment");

            Assert.AreEqual(riealtorAgency.GetClientIDbyAppl(666), new Clientas(666, "Петрович", "Артем", "Отчество", "8910882501"));
        }

        /// <summary>
        /// Тест метода ContainsApplicationNum
        /// Метод проверяет содержится ли в конторе заявка
        /// с номером num
        /// false - нет, true - да
        /// </summary>
        [TestMethod]
        public void ContainsApplicationNum_Test()
        {
            riealtorAgency.GetListClient.Add(new Clientas(666, "Петрович", "Артем", "Отчество", "8910882501"));
            Home[] home = new Home[]
           {
                new Home("2", "50", "1500000", "NN")
           };
            //Добавить операцию продажи клиенту 0
            riealtorAgency[0].AddOperation(home, Clientas.operation.SALE, "666", "Additional regiment");
            Assert.AreEqual(riealtorAgency.ContainsApplicationNum(1337), false);
        }

        /// <summary>
        /// Тест метода ClientsExceptID
        /// Возвращает список клиентов без клиента с указанным id
        /// </summary>
        [TestMethod]
        public void ClientsExceptID()
        {
            Assert.AreEqual(riealtorAgency.ClientsExceptID(2),null);
        }
    }

}

