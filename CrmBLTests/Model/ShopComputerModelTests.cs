using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void StartTest()
        {
            ShopComputerModel shopComputerModel = new ShopComputerModel();

            shopComputerModel.Start();
        }
    }
}