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
    public class CoinKeeperTest
    {
        [TestMethod]
        public void TestCoinKeeper_GetMoney()
        {
            CoinKeeper coinKeeper = new CoinKeeper();

            for (int i = 1; i < 5; i++)
            {
                int ExpectedOutput = 0;

                for (int j = 0; j < i; j++)
                {
                    ExpectedOutput += j * 100;
                    coinKeeper.GetMoney((uint) j * 100);
                }
                int ActualOutput = (int)coinKeeper.ReturnMoney();
                Assert.AreEqual(ExpectedOutput, ActualOutput, "Количество переданных денег не соответствует количеству возвращённых");

                ActualOutput = (int)coinKeeper.ReturnMoney();
                ExpectedOutput = 0;
                Assert.AreEqual(ExpectedOutput, ActualOutput, "Счётчик не сбрасывается после возврата денег");
            }
        }
    }
}
