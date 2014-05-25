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
    //mock... todo

    [TestClass]
    public class AcceptorTest
    {
        public bool SubTestBanknoteCheck(Banknote input)
        {
            Acceptor acceptor = new Acceptor();

            Banknote banknote = input;
            acceptor.GetMoney(banknote);

            while (acceptor.isBusy() && !acceptor.Failed())
                acceptor.Update();

            return acceptor.Failed();
        }

        public Acceptor InsertMoney(Banknote banknote)
        {
            Acceptor acceptor = new Acceptor();

            acceptor.GetMoney(banknote);

            while (acceptor.isBusy())
                acceptor.Update();

            return acceptor;
        }
        void InsertMoney(Acceptor acceptor, Banknote banknote, ref int expectedValue)
        {
            acceptor.GetMoney(banknote);
            while (acceptor.isBusy()) acceptor.Update();
            expectedValue += banknote.Value;
        }

        public bool SubTestReturnMoney(Banknote banknote)
        {
            bool result = true;
            uint account = 0;
            Acceptor acceptor = null;
            acceptor = InsertMoney(banknote);

            account = acceptor.ReturnMoney();
            result &= account == banknote.Value;

            account = acceptor.ReturnMoney();
            result &= account == 0;

            account = acceptor.ReturnMoney();
            result &= account == 0;

            return result;
        }

        [TestMethod]
        public void TestBanknoteCheck() // Тест метода GetMoney()
        {
            bool out1 = SubTestBanknoteCheck(new Banknote(BanknoteRating.Ten));
            bool out2 = SubTestBanknoteCheck(new Banknote(BanknoteRating.Fifty));
            bool out3 = SubTestBanknoteCheck(new Banknote(BanknoteRating.OneHundred));
            bool out4 = SubTestBanknoteCheck(new Banknote(BanknoteRating.Unknown));

            // В первых трёх случаях не должно быть ошибки при принятии купюры, а в четвёртом купюра не должна быть принята
            bool ActualOutput = !out1 && !out2 && !out3 && out4;
            bool ExpectedOutput = true;

            Assert.AreEqual(ExpectedOutput, ActualOutput, "Ошибка при прохождении теста" + Environment.NewLine
                + "Ожидается: False, False, False, True" + Environment.NewLine
                + "Результат: " + out1.ToString() + ", " + out2.ToString() + ", " + out3.ToString() + ", " + out4.ToString());
        }

        [TestMethod]
        public void TestReturnMoney()
        {
            bool result = true;

            result &= SubTestReturnMoney(new Banknote(BanknoteRating.Ten));
            result &= SubTestReturnMoney(new Banknote(BanknoteRating.Fifty));
            result &= SubTestReturnMoney(new Banknote(BanknoteRating.OneHundred));
            result &= SubTestReturnMoney(new Banknote(BanknoteRating.Unknown));

            int exp = 0;
            Banknote banknote = null;

            Acceptor acceptor = new Acceptor();

            banknote = new Banknote(BanknoteRating.Ten);
            InsertMoney(acceptor, banknote, ref exp);
            InsertMoney(acceptor, banknote, ref exp);

            banknote = new Banknote(BanknoteRating.Fifty);
            InsertMoney(acceptor, banknote, ref exp);

            banknote = new Banknote(BanknoteRating.OneHundred);
            InsertMoney(acceptor, banknote, ref exp);
            // exp == 170
            uint account = acceptor.ReturnMoney();
            bool ActualOutput = account == (uint)exp && result;
            bool ExpectedOutput = true;

            Assert.AreEqual(ExpectedOutput, ActualOutput, "Ошибка при прохождении теста");
        }

    }
}
