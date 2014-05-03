﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace VendingMachineApplication
{
    public partial class MyPanel : UserControl
    {
        private double _initialWidth;
        private double _initialHeight;
        public double dLeft { get; private set; } // Если не вводить эти переменные, глобальный масштаб 
        public double dTop { get; private set; }  // будет меняться некорректно из-за округлений

        // x0, y0 - точка отсчёта
        public void ChangeGlobalScale(double x0, double y0, float newScale)
        {
            dLeft = x0 + (dLeft - x0) * newScale / _scale;
            dTop = y0 + (dTop - y0) * newScale / _scale;
            this.Location = new Point((int)dLeft, (int)dTop);
            PanelScale = newScale;
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if ((int)dLeft != Left)
                this.dLeft = Left;
            if ((int)dTop != Top)
                this.dTop = Top;
        }

        private List<InputButton> _inputButtons = new List<InputButton>();

        private Devices.Component1 Background;
        private InputButton inputButton0;
        private IContainer components;
        public ImageList imageList;
        private InputButton inputButton1;
        private InputButton inputButton2;
        private InputButton inputButton3;
        private InputButton inputButton4;
        private InputButton inputButton7;
        private InputButton inputButton5;
        private InputButton inputButton6;
        private InputButton inputButton8;
        private InputButton inputButton9;
        private InputButton inputButton10;
        private InputButton inputButton11;

        double _scale = 1;

        [Category("Масштаб")]
        [Browsable(true)]
        public double PanelScale
        {
            get
            {
                UpdateScale();
                return _scale;
            }
            set
            {
                _scale = value;
                if (Background.BackgroundImage != null)
                    this.Size = new Size(
                        (int)((double)Background.BackgroundImage.Width * _scale),
                        (int)((double)Background.BackgroundImage.Height * _scale)
                        );
            }
        }

        public MyPanel()
        {

            InitializeComponent();
            UpdateScale();
            InitButtons();
            _initialWidth = Background.Width;
            _initialHeight = Background.Height;
            //for (int i = 0; i < this.components.Components.Count; )
            foreach (object obj in this.components.Components)
            {
                if (obj.GetType().ToString().Contains("InputButton"))
                    ((InputButton)obj).Scale = (float)_scale;
            }

            this.dLeft = Left;
            this.dTop = Top;
        }

        private void InitButtons()
        {
            //this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPanel));
            
            for (int i = 0; i < -12; i++)
            {
                InputButton button = new InputButton();

                ((System.ComponentModel.ISupportInitialize)(button)).BeginInit();
                button.BackColor = System.Drawing.Color.Transparent;
                if (i < 10)
                {
                    char number = (char)((i + 1) % 10 + '0');
                    //button.Image = imageList.Images[number + ".png"];
                    button.ImagePack = new Bitmap(imageList.Images[number + ".png"]);
                    button.Key = number;
                }
                else
                {
                    button.Image = ((System.Drawing.Image)(resources.GetObject("inputButton1.Image")));
                    button.ImagePack = global::VendingMachineApplication.Properties.Resources._0;
                    button.Key = '0';
                }

                button.Location = new System.Drawing.Point((int)((10f + (i % 3) * 14) * _scale), (int)((18f + (i / 3) * 19) * _scale));
                button.Name = "inputButton1";
                button.OwnerPanel = null;
                button.Size = new System.Drawing.Size(15, 14);
                button.Scale = (float)_scale;
                button.TabIndex = 1;
                button.TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(button)).EndInit();
                _inputButtons.Add(button);
                this.Controls.Add(button);
                button.BringToFront();
                //this.components.Add(button);
                button.Parent = this;
                button.Click += ButtonClick;
            }
            //this.SuspendLayout();
            
            //this.ResumeLayout(false);
        }

        void UpdateScale()
        {
            if (Background.BackgroundImage != null)
                _scale = (double)Background.Width / (double)Background.BackgroundImage.Width;
            foreach (object obj in this.components.Components)
            {
                if (obj.GetType().ToString().Contains("InputButton"))
                    ((InputButton)obj).ChangeGlobalScale(0, 0, (float)_scale);
            }
            //inputButton1.ChangeGlobalScale(0, 0, (float)_scale);
            if (_inputButtons.Count > 0)
                foreach (InputButton button in _inputButtons)
                {
                    button.ChangeGlobalScale(0, 0, (float)_scale);
                }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPanel));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.inputButton11 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton10 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton9 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton8 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton6 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton5 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton7 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton4 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton3 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton2 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton1 = new VendingMachineApplication.InputButton(this.components);
            this.inputButton0 = new VendingMachineApplication.InputButton(this.components);
            this.Background = new VendingMachineApplication.Devices.Component1(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inputButton11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Green;
            this.imageList.Images.SetKeyName(0, "#.png");
            this.imageList.Images.SetKeyName(1, "1.png");
            this.imageList.Images.SetKeyName(2, "2.png");
            this.imageList.Images.SetKeyName(3, "3.png");
            this.imageList.Images.SetKeyName(4, "4.png");
            this.imageList.Images.SetKeyName(5, "5.png");
            this.imageList.Images.SetKeyName(6, "6.png");
            this.imageList.Images.SetKeyName(7, "7.png");
            this.imageList.Images.SetKeyName(8, "8.png");
            this.imageList.Images.SetKeyName(9, "9.png");
            this.imageList.Images.SetKeyName(10, "С.png");
            this.imageList.Images.SetKeyName(11, "Т.png");
            this.imageList.Images.SetKeyName(12, "0.png");
            // 
            // inputButton11
            // 
            this.inputButton11.BackColor = System.Drawing.Color.Transparent;
            this.inputButton11.Image = ((System.Drawing.Image)(resources.GetObject("inputButton11.Image")));
            this.inputButton11.ImagePack = global::VendingMachineApplication.Properties.Resources.С;
            this.inputButton11.Key = '#';
            this.inputButton11.Location = new System.Drawing.Point(37, 75);
            this.inputButton11.Name = "inputButton11";
            this.inputButton11.OwnerPanel = null;
            this.inputButton11.Scale = 1F;
            this.inputButton11.Size = new System.Drawing.Size(13, 13);
            this.inputButton11.TabIndex = 12;
            this.inputButton11.TabStop = false;
            this.inputButton11.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton10
            // 
            this.inputButton10.BackColor = System.Drawing.Color.Transparent;
            this.inputButton10.Image = ((System.Drawing.Image)(resources.GetObject("inputButton10.Image")));
            this.inputButton10.ImagePack = global::VendingMachineApplication.Properties.Resources.Т;
            this.inputButton10.Key = '*';
            this.inputButton10.Location = new System.Drawing.Point(9, 75);
            this.inputButton10.Name = "inputButton10";
            this.inputButton10.OwnerPanel = null;
            this.inputButton10.Scale = 1F;
            this.inputButton10.Size = new System.Drawing.Size(13, 13);
            this.inputButton10.TabIndex = 11;
            this.inputButton10.TabStop = false;
            this.inputButton10.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton9
            // 
            this.inputButton9.BackColor = System.Drawing.Color.Transparent;
            this.inputButton9.Image = ((System.Drawing.Image)(resources.GetObject("inputButton9.Image")));
            this.inputButton9.ImagePack = global::VendingMachineApplication.Properties.Resources._9;
            this.inputButton9.Key = '9';
            this.inputButton9.Location = new System.Drawing.Point(37, 56);
            this.inputButton9.Name = "inputButton9";
            this.inputButton9.OwnerPanel = null;
            this.inputButton9.Scale = 1F;
            this.inputButton9.Size = new System.Drawing.Size(13, 13);
            this.inputButton9.TabIndex = 10;
            this.inputButton9.TabStop = false;
            this.inputButton9.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton8
            // 
            this.inputButton8.BackColor = System.Drawing.Color.Transparent;
            this.inputButton8.Image = ((System.Drawing.Image)(resources.GetObject("inputButton8.Image")));
            this.inputButton8.ImagePack = global::VendingMachineApplication.Properties.Resources._8;
            this.inputButton8.Key = '8';
            this.inputButton8.Location = new System.Drawing.Point(23, 56);
            this.inputButton8.Name = "inputButton8";
            this.inputButton8.OwnerPanel = null;
            this.inputButton8.Scale = 1F;
            this.inputButton8.Size = new System.Drawing.Size(13, 13);
            this.inputButton8.TabIndex = 9;
            this.inputButton8.TabStop = false;
            this.inputButton8.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton6
            // 
            this.inputButton6.BackColor = System.Drawing.Color.Transparent;
            this.inputButton6.Image = ((System.Drawing.Image)(resources.GetObject("inputButton6.Image")));
            this.inputButton6.ImagePack = global::VendingMachineApplication.Properties.Resources._6;
            this.inputButton6.Key = '6';
            this.inputButton6.Location = new System.Drawing.Point(37, 37);
            this.inputButton6.Name = "inputButton6";
            this.inputButton6.OwnerPanel = null;
            this.inputButton6.Scale = 1F;
            this.inputButton6.Size = new System.Drawing.Size(13, 13);
            this.inputButton6.TabIndex = 8;
            this.inputButton6.TabStop = false;
            this.inputButton6.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton5
            // 
            this.inputButton5.BackColor = System.Drawing.Color.Transparent;
            this.inputButton5.Image = ((System.Drawing.Image)(resources.GetObject("inputButton5.Image")));
            this.inputButton5.ImagePack = global::VendingMachineApplication.Properties.Resources._5;
            this.inputButton5.Key = '5';
            this.inputButton5.Location = new System.Drawing.Point(23, 37);
            this.inputButton5.Name = "inputButton5";
            this.inputButton5.OwnerPanel = null;
            this.inputButton5.Scale = 1F;
            this.inputButton5.Size = new System.Drawing.Size(13, 13);
            this.inputButton5.TabIndex = 7;
            this.inputButton5.TabStop = false;
            this.inputButton5.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton7
            // 
            this.inputButton7.BackColor = System.Drawing.Color.Transparent;
            this.inputButton7.Image = ((System.Drawing.Image)(resources.GetObject("inputButton7.Image")));
            this.inputButton7.ImagePack = global::VendingMachineApplication.Properties.Resources._7;
            this.inputButton7.Key = '7';
            this.inputButton7.Location = new System.Drawing.Point(9, 56);
            this.inputButton7.Name = "inputButton7";
            this.inputButton7.OwnerPanel = null;
            this.inputButton7.Scale = 1F;
            this.inputButton7.Size = new System.Drawing.Size(13, 13);
            this.inputButton7.TabIndex = 6;
            this.inputButton7.TabStop = false;
            this.inputButton7.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton4
            // 
            this.inputButton4.BackColor = System.Drawing.Color.Transparent;
            this.inputButton4.Image = ((System.Drawing.Image)(resources.GetObject("inputButton4.Image")));
            this.inputButton4.ImagePack = global::VendingMachineApplication.Properties.Resources._4;
            this.inputButton4.Key = '4';
            this.inputButton4.Location = new System.Drawing.Point(9, 37);
            this.inputButton4.Name = "inputButton4";
            this.inputButton4.OwnerPanel = null;
            this.inputButton4.Scale = 1F;
            this.inputButton4.Size = new System.Drawing.Size(13, 13);
            this.inputButton4.TabIndex = 5;
            this.inputButton4.TabStop = false;
            this.inputButton4.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton3
            // 
            this.inputButton3.BackColor = System.Drawing.Color.Transparent;
            this.inputButton3.Image = ((System.Drawing.Image)(resources.GetObject("inputButton3.Image")));
            this.inputButton3.ImagePack = global::VendingMachineApplication.Properties.Resources._3;
            this.inputButton3.Key = '3';
            this.inputButton3.Location = new System.Drawing.Point(37, 18);
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.OwnerPanel = null;
            this.inputButton3.Scale = 1F;
            this.inputButton3.Size = new System.Drawing.Size(13, 13);
            this.inputButton3.TabIndex = 4;
            this.inputButton3.TabStop = false;
            this.inputButton3.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton2
            // 
            this.inputButton2.BackColor = System.Drawing.Color.Transparent;
            this.inputButton2.Image = ((System.Drawing.Image)(resources.GetObject("inputButton2.Image")));
            this.inputButton2.ImagePack = global::VendingMachineApplication.Properties.Resources._2;
            this.inputButton2.Key = '2';
            this.inputButton2.Location = new System.Drawing.Point(23, 18);
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.OwnerPanel = null;
            this.inputButton2.Scale = 1F;
            this.inputButton2.Size = new System.Drawing.Size(13, 13);
            this.inputButton2.TabIndex = 3;
            this.inputButton2.TabStop = false;
            this.inputButton2.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton1
            // 
            this.inputButton1.BackColor = System.Drawing.Color.Transparent;
            this.inputButton1.Image = ((System.Drawing.Image)(resources.GetObject("inputButton1.Image")));
            this.inputButton1.ImagePack = global::VendingMachineApplication.Properties.Resources._1;
            this.inputButton1.Key = '1';
            this.inputButton1.Location = new System.Drawing.Point(9, 18);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.OwnerPanel = null;
            this.inputButton1.Scale = 1F;
            this.inputButton1.Size = new System.Drawing.Size(13, 13);
            this.inputButton1.TabIndex = 2;
            this.inputButton1.TabStop = false;
            this.inputButton1.Click += new System.EventHandler(this.ButtonClick);
            // 
            // inputButton0
            // 
            this.inputButton0.BackColor = System.Drawing.Color.Transparent;
            this.inputButton0.Image = ((System.Drawing.Image)(resources.GetObject("inputButton0.Image")));
            this.inputButton0.ImagePack = global::VendingMachineApplication.Properties.Resources._0;
            this.inputButton0.Key = '0';
            this.inputButton0.Location = new System.Drawing.Point(23, 75);
            this.inputButton0.Name = "inputButton0";
            this.inputButton0.OwnerPanel = null;
            this.inputButton0.Scale = 1F;
            this.inputButton0.Size = new System.Drawing.Size(13, 13);
            this.inputButton0.TabIndex = 1;
            this.inputButton0.TabStop = false;
            this.inputButton0.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.Transparent;
            this.Background.BackgroundImage = global::VendingMachineApplication.Properties.Resources.panel;
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.ImagePack = null;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Scale = 1F;
            this.Background.Size = new System.Drawing.Size(60, 118);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // MyPanel
            // 
            this.Controls.Add(this.inputButton11);
            this.Controls.Add(this.inputButton10);
            this.Controls.Add(this.inputButton9);
            this.Controls.Add(this.inputButton8);
            this.Controls.Add(this.inputButton6);
            this.Controls.Add(this.inputButton5);
            this.Controls.Add(this.inputButton7);
            this.Controls.Add(this.inputButton4);
            this.Controls.Add(this.inputButton3);
            this.Controls.Add(this.inputButton2);
            this.Controls.Add(this.inputButton1);
            this.Controls.Add(this.inputButton0);
            this.Controls.Add(this.Background);
            this.Name = "MyPanel";
            this.Size = new System.Drawing.Size(60, 118);
            ((System.ComponentModel.ISupportInitialize)(this.inputButton11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputButton0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        public void ButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show((sender as InputButton).Key.ToString());
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            double cwd = this.Width;
            double chg = this.Height;

            double a = cwd / _initialWidth;
            double b = chg / _initialHeight;

            if (a < b)
                this.Width = (int)(_initialWidth * b);
            else
                this.Height = (int)(_initialHeight * a);
            UpdateScale();
        }

        
        
    }
}