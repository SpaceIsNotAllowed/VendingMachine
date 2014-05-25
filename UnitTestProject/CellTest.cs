//http://msdn.microsoft.com/ru-ru/library/ms182532.aspx
//http://msdn.microsoft.com/ru-ru/library/ms182488.aspx
//http://msdn.microsoft.com/ru-ru/library/ms243176.aspx
//http://msdn.microsoft.com/ru-ru/library/ms182487.aspx

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineApplication;
using DevicesUnit;

namespace UnitTestProject
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void TestCell()
        {
            int expectedOutput = -1;
            int actualOutput = -1;

            Product p = new Product();

            Cell cell = new Cell();
            cell.Product = p;
            int q = 0;
            for (int i = 0; i <= 5; i++)
            {
                q += i;
                cell.AddProduct(i);
                expectedOutput = q <= 10? q : 10;
                actualOutput = cell.ProductCount;
                Assert.AreEqual(expectedOutput, actualOutput, "");
            }

            Cell cell2 = new Cell();
            cell2.AddProduct(3);
            expectedOutput = 0;
            actualOutput = cell2.ProductCount;
            Assert.AreEqual(expectedOutput, actualOutput, "Продукт не задан, но количество изменяется.");
        }
    }
}
