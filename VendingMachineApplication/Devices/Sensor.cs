using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication.Devices
{
    public partial class Sensor : Component
    {
        #region Конструкторы
        public Sensor()
        {
            InitializeComponent();
        }

        public Sensor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        public VendingMachineApplication.VendingMachine VendingMachine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private bool HasObject; // ссылка на переменную!!
        private bool Warning;
        
        private void Alarm()
        {
            Warning = true; 
        }

        private void Check()
        {
            if (HasObject)
            {
                if (!Warning) Alarm();
            }
            else Warning = false;
        }

        public bool Warns()
        {
            return Warning;
        }

        public void Update()
        {
            Check();
        }
    }
}
