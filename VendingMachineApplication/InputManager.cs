using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class InputPanel : Component
    {
        public InputPanel()
        {
            InitializeComponent();
        }

        public InputPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
