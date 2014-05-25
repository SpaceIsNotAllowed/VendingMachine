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
    public class DisplayTest
    {
        [TestMethod]
        public void TestDisplay_InputInfoChange()
        {
            Display display = new Display();

            String InputText = "Hello!";
            String ExpectedOutput = "o!";

            display.InputInfo = InputText;
            String ActualOutput = display.InputInfo;

            Assert.AreEqual(ExpectedOutput, ActualOutput, false);
        }
    }
}
