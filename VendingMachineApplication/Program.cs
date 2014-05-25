using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("DevicesUnit.dll"))
            {
                MessageBox.Show("Файл DevicesUnit.dll не найден!", "Невозможно запустить программу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormVendingTest());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка в ходе выполнения программы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
