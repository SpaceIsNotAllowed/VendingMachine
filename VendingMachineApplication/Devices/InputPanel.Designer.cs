namespace VendingMachineApplication
{
    partial class MyPanel
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Background = new VendingMachineApplication.Devices.Component1(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.Transparent;
            this.Background.BackgroundImage = global::VendingMachineApplication.Properties.Resources.panel;
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Background.ImagePack = null;
            this.Background.Location = new System.Drawing.Point(18, 12);
            this.Background.Name = "Background";
            this.Background.Scale = 1.9F;
            this.Background.Size = new System.Drawing.Size(110, 217);
            this.Background.TabIndex = 2;
            this.Background.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Background);
            this.Name = "MyPanel";
            this.Size = new System.Drawing.Size(402, 256);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Devices.Component1 Background;
        private System.Windows.Forms.Button button1;

    }
}
