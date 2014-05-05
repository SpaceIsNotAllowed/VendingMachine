namespace VendingMachineApplication
{
    partial class FormChooseAction
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
            this.buttonInsertMoney = new System.Windows.Forms.Button();
            this.comboBoxBanknotes = new System.Windows.Forms.ComboBox();
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInsertMoney
            // 
            this.buttonInsertMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertMoney.Location = new System.Drawing.Point(12, 12);
            this.buttonInsertMoney.Name = "buttonInsertMoney";
            this.buttonInsertMoney.Size = new System.Drawing.Size(193, 23);
            this.buttonInsertMoney.TabIndex = 0;
            this.buttonInsertMoney.Text = "Вставить купюру";
            this.buttonInsertMoney.UseVisualStyleBackColor = true;
            this.buttonInsertMoney.Click += new System.EventHandler(this.buttonInsertMoney_Click);
            // 
            // comboBoxBanknotes
            // 
            this.comboBoxBanknotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBanknotes.FormattingEnabled = true;
            this.comboBoxBanknotes.Items.AddRange(new object[] {
            "10 рублей",
            "50 рублей",
            "100 рублей",
            "500 рублей"});
            this.comboBoxBanknotes.Location = new System.Drawing.Point(211, 14);
            this.comboBoxBanknotes.Name = "comboBoxBanknotes";
            this.comboBoxBanknotes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBanknotes.TabIndex = 1;
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRandomize.Location = new System.Drawing.Point(12, 41);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(320, 23);
            this.buttonRandomize.TabIndex = 2;
            this.buttonRandomize.Text = "Загрузить автомат случайным образом";
            this.buttonRandomize.UseVisualStyleBackColor = true;
            // 
            // FormChooseAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 75);
            this.Controls.Add(this.buttonRandomize);
            this.Controls.Add(this.comboBoxBanknotes);
            this.Controls.Add(this.buttonInsertMoney);
            this.MaximumSize = new System.Drawing.Size(358, 113);
            this.MinimizeBox = false;
            this.Name = "FormChooseAction";
            this.Text = "Выберите действие";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInsertMoney;
        private System.Windows.Forms.ComboBox comboBoxBanknotes;
        private System.Windows.Forms.Button buttonRandomize;
    }
}