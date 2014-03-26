namespace VendingMachineApplication.UnitTesting
{
    partial class FormDisplayTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainInfo = new System.Windows.Forms.TextBox();
            this.MoneyInfo = new System.Windows.Forms.TextBox();
            this.InputInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.display = new VendingMachineApplication.Display();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            this.SuspendLayout();
            // 
            // MainInfo
            // 
            this.MainInfo.Location = new System.Drawing.Point(105, 12);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(139, 20);
            this.MainInfo.TabIndex = 1;
            this.MainInfo.Text = "Введите номер ячейки:";
            this.MainInfo.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // MoneyInfo
            // 
            this.MoneyInfo.Location = new System.Drawing.Point(105, 88);
            this.MoneyInfo.Name = "MoneyInfo";
            this.MoneyInfo.Size = new System.Drawing.Size(139, 20);
            this.MoneyInfo.TabIndex = 2;
            this.MoneyInfo.Text = "120 р.";
            this.MoneyInfo.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // InputInfo
            // 
            this.InputInfo.Location = new System.Drawing.Point(105, 50);
            this.InputInfo.Name = "InputInfo";
            this.InputInfo.Size = new System.Drawing.Size(140, 20);
            this.InputInfo.TabIndex = 3;
            this.InputInfo.Text = "435834#**";
            this.InputInfo.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Информация:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Входные данные:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Цена:";
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.Transparent;
            this.display.ImagePack = global::VendingMachineApplication.Properties.Resources.DisplayBackground;
            this.display.Location = new System.Drawing.Point(250, 12);
            this.display.Name = "display";
            this.display.Scale = 1.1F;
            this.display.Size = new System.Drawing.Size(171, 96);
            this.display.TabIndex = 0;
            this.display.TabStop = false;
            this.display.SizeChanged += new System.EventHandler(this.displaySizeChanged);
            // 
            // FormDisplayTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 117);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputInfo);
            this.Controls.Add(this.MoneyInfo);
            this.Controls.Add(this.MainInfo);
            this.Controls.Add(this.display);
            this.Name = "FormDisplayTest";
            this.Text = "Тестирование дисплея";
            this.Load += new System.EventHandler(this.FormDisplayTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Display display;
        private System.Windows.Forms.TextBox MainInfo;
        private System.Windows.Forms.TextBox MoneyInfo;
        private System.Windows.Forms.TextBox InputInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}