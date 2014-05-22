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
    public partial class PanelBackground : GraphicalObject
    {
        public PanelBackground()
        {
            InitializeComponent();
        }

        public PanelBackground(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (BackgroundImage != null)
            {
                double wd = BackgroundImage.Width;
                double hg = BackgroundImage.Height;
                double a = this.Width / wd;
                double b = this.Height / hg;

                if (a < b)
                    this.Width = (int)(wd * b);
                else
                    this.Height = (int)(hg * a);
            }
        }
    }
}
