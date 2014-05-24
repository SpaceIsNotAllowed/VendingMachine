//http://msdn.microsoft.com/ru-ru/library/ms182532.aspx
//http://msdn.microsoft.com/ru-ru/library/ms182488.aspx
//http://msdn.microsoft.com/ru-ru/library/ms243176.aspx
//http://msdn.microsoft.com/ru-ru/library/ms182487.aspx

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineApplication;
using VendingMachineApplication.Devices;

namespace UnitTestProject
{
    [TestClass]
    public class SensorTest
    {
        [TestMethod]
        public void TestCellStringChange()
        {
            Sensor sensor = new Sensor();

            sensor.HasObject = true;
            sensor.Update();

            bool ExpectedOutput = true;
            bool ActualOutput = sensor.Warns();

            Assert.AreEqual(ExpectedOutput, ActualOutput, "Ожидаемое значение не соответствует действительному!");

            sensor.HasObject = false;
            sensor.Update();

            ExpectedOutput = false;
            ActualOutput = sensor.Warns();

            Assert.AreEqual(ExpectedOutput, ActualOutput, "Ожидаемое значение не соответствует действительному!");
        }
    }
}
