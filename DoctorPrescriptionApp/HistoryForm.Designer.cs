namespace DoctorPrescriptionApp
{
    partial class HistoryForm
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
            this._historyDataGridView = new System.Windows.Forms.DataGridView();
            this._datePicker = new System.Windows.Forms.DateTimePicker();
            this._searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._historyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _historyDataGridView
            // 
            this._historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._historyDataGridView.Location = new System.Drawing.Point(12, 41);
            this._historyDataGridView.Name = "_historyDataGridView";
            this._historyDataGridView.Size = new System.Drawing.Size(776, 397);
            this._historyDataGridView.TabIndex = 0;
            // 
            // _datePicker
            // 
            this._datePicker.Location = new System.Drawing.Point(12, 12);
            this._datePicker.Name = "_datePicker";
            this._datePicker.Size = new System.Drawing.Size(200, 23);
            this._datePicker.TabIndex = 1;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(218, 12);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._searchButton);
            this.Controls.Add(this._datePicker);
            this.Controls.Add(this._historyDataGridView);
            this.Name = "HistoryForm";
            this.Text = "Prescription History";
            ((System.ComponentModel.ISupportInitialize)(this._historyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _historyDataGridView;
        private System.Windows.Forms.DateTimePicker _datePicker;
        private System.Windows.Forms.Button _searchButton;
    }
}