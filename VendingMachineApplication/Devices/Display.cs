using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public partial class Display : Component
    {
        #region Конструкторы

        public Display()
        {
            InitializeComponent();
            Init();
        }

        public Display(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        #endregion

        private void Init()
        {
            Background = Bitmap.FromFile(".\\images\\Display.bmp");
            //...
        }

        private void Update()
        {
            //...
        }

        private Image Background;
        private String _MainInfo, _InputInfo, _MoneyInfo;

        #region Свойства

        public String MainInfo
        {
            set
            {
                _MainInfo = value;
                Update();
            }
        }

        public String InputInfo
        {
            set
            {
                _InputInfo = value;
                Update();
            }
        }

        public String MoneyInfo
        {
            set
            {
                _MoneyInfo = value;
                Update();
            }
        }

        #endregion

        public VendingMachine VendingMachine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
