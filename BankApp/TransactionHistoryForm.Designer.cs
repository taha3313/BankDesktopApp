namespace BankApp
{
    partial class TransactionHistoryForm
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
            this.lvTransactions = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Receiver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvTransactions
            // 
            this.lvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Type,
            this.Amount,
            this.Receiver});
            this.lvTransactions.HideSelection = false;
            this.lvTransactions.Location = new System.Drawing.Point(93, 70);
            this.lvTransactions.Name = "lvTransactions";
            this.lvTransactions.Size = new System.Drawing.Size(637, 304);
            this.lvTransactions.TabIndex = 0;
            this.lvTransactions.UseCompatibleStateImageBehavior = false;
            this.lvTransactions.View = System.Windows.Forms.View.Details;
            this.lvTransactions.SelectedIndexChanged += new System.EventHandler(this.lvTransactions_SelectedIndexChanged);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 168;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 136;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 164;
            // 
            // Receiver
            // 
            this.Receiver.Text = "Receiver";
            this.Receiver.Width = 141;
            // 
            // TransactionHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvTransactions);
            this.Name = "TransactionHistoryForm";
            this.Text = "TransactionHistoryForm";
            this.Load += new System.EventHandler(this.TransactionHistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTransactions;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Receiver;
    }
}