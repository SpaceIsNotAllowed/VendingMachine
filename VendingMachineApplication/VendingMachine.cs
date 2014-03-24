using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public enum State
    {
        SCellRequest,
        SChangingCellRequest,
        SRepeat,
        SPriceRequest,
        SDone,
        SMoneyRequest,
        SEmptyCell,
        SUnlock,
        SAlert
    }

    public partial class VendingMachine : Component
    {
        public VendingMachine()
        {
            InitializeComponent();
            Init();
        }

        public VendingMachine(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        private String input = "";
        private String password = "123";
        private int account;
        private List<Cell> cellList;
        private State state;
        private Sensor sensor;
        private Display display;
        private CoinKeeper coinKeeper;
        private InputPanel inputPanel;
        private Acceptor acceptor;

        private void AnalyseInput()
        {
            //...
        }

        private void InitState()
        {
            //...
        }

        public void Update()
        {
            //...
        }

        private void Init()
        {
            //...
        }
    }
}
