namespace AtmConsoleUI
{
    partial class IssuedMoneyForm
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
            this.dataGridViewMoney = new System.Windows.Forms.DataGridView();
            this.ColumnNominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMoney
            // 
            this.dataGridViewMoney.AllowUserToAddRows = false;
            this.dataGridViewMoney.AllowUserToDeleteRows = false;
            this.dataGridViewMoney.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewMoney.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMoney.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNominal,
            this.ColumnNumber});
            this.dataGridViewMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMoney.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMoney.Name = "dataGridViewMoney";
            this.dataGridViewMoney.ReadOnly = true;
            this.dataGridViewMoney.RowHeadersWidth = 5;
            this.dataGridViewMoney.RowTemplate.Height = 24;
            this.dataGridViewMoney.Size = new System.Drawing.Size(207, 147);
            this.dataGridViewMoney.TabIndex = 0;
            // 
            // ColumnNominal
            // 
            this.ColumnNominal.Frozen = true;
            this.ColumnNominal.HeaderText = "Nominal";
            this.ColumnNominal.Name = "ColumnNominal";
            this.ColumnNominal.ReadOnly = true;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.Frozen = true;
            this.ColumnNumber.HeaderText = "Number";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            // 
            // IssuedMoneyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 147);
            this.Controls.Add(this.dataGridViewMoney);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "IssuedMoneyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issued Money";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoney)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        public System.Windows.Forms.DataGridView dataGridViewMoney;
    }
}