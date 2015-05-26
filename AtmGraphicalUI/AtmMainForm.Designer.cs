namespace AtmConsoleUI
{
    partial class AtmMainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.textBoxInputSum = new System.Windows.Forms.TextBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLoadCassettes = new System.Windows.Forms.Button();
            this.textBoxCassettes = new System.Windows.Forms.TextBox();
            this.buttonDeleteCassettes = new System.Windows.Forms.Button();
            this.panelInsertCassettes = new System.Windows.Forms.Panel();
            this.listBoxMoney = new System.Windows.Forms.ListBox();
            this.panelInput.SuspendLayout();
            this.panelInsertCassettes.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(126, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(70, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(126, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(14, 153);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(70, 153);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 50);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(126, 153);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 50);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(70, 209);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(50, 50);
            this.button0.TabIndex = 9;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // textBoxInputSum
            // 
            this.textBoxInputSum.Location = new System.Drawing.Point(41, 3);
            this.textBoxInputSum.Name = "textBoxInputSum";
            this.textBoxInputSum.ReadOnly = true;
            this.textBoxInputSum.Size = new System.Drawing.Size(162, 22);
            this.textBoxInputSum.TabIndex = 10;
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.buttonEnter);
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.buttonCancel);
            this.panelInput.Controls.Add(this.textBoxInputSum);
            this.panelInput.Controls.Add(this.button1);
            this.panelInput.Controls.Add(this.button0);
            this.panelInput.Controls.Add(this.button2);
            this.panelInput.Controls.Add(this.button9);
            this.panelInput.Controls.Add(this.button3);
            this.panelInput.Controls.Add(this.button8);
            this.panelInput.Controls.Add(this.button4);
            this.panelInput.Controls.Add(this.button7);
            this.panelInput.Controls.Add(this.button5);
            this.panelInput.Controls.Add(this.button6);
            this.panelInput.Location = new System.Drawing.Point(27, 12);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(262, 272);
            this.panelInput.TabIndex = 11;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(182, 153);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(60, 50);
            this.buttonEnter.TabIndex = 13;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(182, 97);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(60, 50);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(182, 41);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 50);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLoadCassettes
            // 
            this.buttonLoadCassettes.Location = new System.Drawing.Point(13, 33);
            this.buttonLoadCassettes.Name = "buttonLoadCassettes";
            this.buttonLoadCassettes.Size = new System.Drawing.Size(98, 49);
            this.buttonLoadCassettes.TabIndex = 12;
            this.buttonLoadCassettes.Text = "Load Cassettes";
            this.buttonLoadCassettes.UseVisualStyleBackColor = true;
            this.buttonLoadCassettes.Click += new System.EventHandler(this.buttonLoadCassettes_Click);
            // 
            // textBoxCassettes
            // 
            this.textBoxCassettes.Location = new System.Drawing.Point(41, 5);
            this.textBoxCassettes.Name = "textBoxCassettes";
            this.textBoxCassettes.Size = new System.Drawing.Size(100, 22);
            this.textBoxCassettes.TabIndex = 14;
            this.textBoxCassettes.Text = "xml";
            // 
            // buttonDeleteCassettes
            // 
            this.buttonDeleteCassettes.Location = new System.Drawing.Point(117, 33);
            this.buttonDeleteCassettes.Name = "buttonDeleteCassettes";
            this.buttonDeleteCassettes.Size = new System.Drawing.Size(98, 49);
            this.buttonDeleteCassettes.TabIndex = 15;
            this.buttonDeleteCassettes.Text = "Delete Cassettes";
            this.buttonDeleteCassettes.UseVisualStyleBackColor = true;
            this.buttonDeleteCassettes.Click += new System.EventHandler(this.buttonDeleteCassettes_Click);
            // 
            // panelInsertCassettes
            // 
            this.panelInsertCassettes.Controls.Add(this.buttonDeleteCassettes);
            this.panelInsertCassettes.Controls.Add(this.buttonLoadCassettes);
            this.panelInsertCassettes.Controls.Add(this.textBoxCassettes);
            this.panelInsertCassettes.Location = new System.Drawing.Point(295, 12);
            this.panelInsertCassettes.Name = "panelInsertCassettes";
            this.panelInsertCassettes.Size = new System.Drawing.Size(220, 89);
            this.panelInsertCassettes.TabIndex = 16;
            // 
            // listBoxMoney
            // 
            this.listBoxMoney.FormattingEnabled = true;
            this.listBoxMoney.ItemHeight = 16;
            this.listBoxMoney.Location = new System.Drawing.Point(295, 117);
            this.listBoxMoney.Name = "listBoxMoney";
            this.listBoxMoney.Size = new System.Drawing.Size(220, 84);
            this.listBoxMoney.TabIndex = 17;
            // 
            // AtmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 296);
            this.Controls.Add(this.listBoxMoney);
            this.Controls.Add(this.panelInsertCassettes);
            this.Controls.Add(this.panelInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AtmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AtmMainForm_FormClosed);
            this.Load += new System.EventHandler(this.AtmMainForm_Load);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelInsertCassettes.ResumeLayout(false);
            this.panelInsertCassettes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.TextBox textBoxInputSum;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLoadCassettes;
        private System.Windows.Forms.TextBox textBoxCassettes;
        private System.Windows.Forms.Button buttonDeleteCassettes;
        private System.Windows.Forms.Panel panelInsertCassettes;
        private System.Windows.Forms.ListBox listBoxMoney;
    }
}

