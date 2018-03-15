using RealtorAgency__Course_work_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TEST
{
    /// <summary>
    /// Сводное описание для HomeClassTEST
    /// </summary>
    [TestClass]
    public class HomeClassTEST
    {
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

        /// <summary>
        /// Тест метода  AppropriateHome
        /// возвращает true - если дом пдходит
        /// </summary>
        [TestMethod]
        public void AppropriateHome_Test ()
        {
            List<Operations> operation = new List<Operations>();

            Home[] home = new Home[]
           {
                new Home("2", "50", "1500000", "NN")
           };
            Sale sale = new Sale(home[0], "1", "желание");


            Home[] home2 = new Home[]
          {
                new Home("2", "50", "1500000", "NN")
          };
            Purchase purchase = new Purchase(home[0], "1", "желание");

            operation.Add(sale);
            operation.Add(purchase);

            Assert.AreEqual(operation[0].AppropriateHome(home2[0], Clientas.operation.PURCHASE),true);
        }

    }
}
