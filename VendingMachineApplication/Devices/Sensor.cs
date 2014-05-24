using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool HasObject { get; set; }

        private bool _warning;
        
        private void Alarm()
        {
            _warning = true;
        }

        private void Check()
        {
            if (HasObject)
            {
                if (!_warning)
                    Alarm();
            }
            else _warning = false;
        }

        public bool Warns()
        {
            return _warning;
        }

        public void Update()
        {
            Check();
        }
    }
}
