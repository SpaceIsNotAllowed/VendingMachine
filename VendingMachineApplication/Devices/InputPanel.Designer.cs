namespace VendingMachineApplication
{
    partial class InputPanel
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
            this.inputButton1 = new VendingMachineApplication.InputButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.inputButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputButton1
            // 
            this.inputButton1.BackColor = System.Drawing.Color.Transparent;
            this.inputButton1.ImagePack = global::VendingMachineApplication.Properties.Resources.button;
            this.inputButton1.Key = '0';
            this.inputButton1.Location = new System.Drawing.Point(27, 23);
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.OwnerPanel = null;
            this.inputButton1.Scale = 1.9F;
            this.inputButton1.Size = new System.Drawing.Size(40, 44);
            this.inputButton1.TabIndex = 0;
            this.inputButton1.TabStop = false;
            // 
            // InputPanel
            // 
            this.Controls.Add(this.inputButton1);
            this.Name = "InputPanel";
            this.Size = new System.Drawing.Size(204, 261);
            ((System.ComponentModel.ISupportInitialize)(this.inputButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private InputButton inputButton1;

    }
}
