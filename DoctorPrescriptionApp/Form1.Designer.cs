namespace DoctorPrescriptionApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _patientInfoGroupBox = new GroupBox();
            _patientIdTextBox = new TextBox();
            _patientIdLabel = new Label();
            _dobPicker = new DateTimePicker();
            _dobLabel = new Label();
            _patientNameTextBox = new TextBox();
            _patientNameLabel = new Label();
            _saveButton = new Button();
            _loadButton = new Button();
            _printButton = new Button();
            _exportTextButton = new Button();
            _exitButton = new Button();
            _newPrescriptionButton = new Button();
            _historyButton = new Button();
            _symptomsGroupBox = new GroupBox();
            _symptomsTextBox = new TextBox();
            _suggestMedicineButton = new Button();
            _suggestionListBox = new ListBox();
            _addSuggestionButton = new Button();
            _prescriptionGroupBox = new GroupBox();
            _addPrescriptionButton = new Button();
            _numberOfDaysTextBox = new TextBox();
            label3 = new Label();
            _timesPerDayTextBox = new TextBox();
            label2 = new Label();
            _medicineNameTextBox = new TextBox();
            label1 = new Label();
            _prescriptionDataGridView = new DataGridView();
            _patientInfoGroupBox.SuspendLayout();
            _symptomsGroupBox.SuspendLayout();
            _prescriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_prescriptionDataGridView).BeginInit();
            SuspendLayout();
            // 
            // _patientInfoGroupBox
            // 
            _patientInfoGroupBox.Controls.Add(_patientIdTextBox);
            _patientInfoGroupBox.Controls.Add(_patientIdLabel);
            _patientInfoGroupBox.Controls.Add(_dobPicker);
            _patientInfoGroupBox.Controls.Add(_dobLabel);
            _patientInfoGroupBox.Controls.Add(_patientNameTextBox);
            _patientInfoGroupBox.Controls.Add(_patientNameLabel);
            _patientInfoGroupBox.Location = new Point(12, 12);
            _patientInfoGroupBox.Name = "_patientInfoGroupBox";
            _patientInfoGroupBox.Size = new Size(776, 120);
            _patientInfoGroupBox.TabIndex = 0;
            _patientInfoGroupBox.TabStop = false;
            _patientInfoGroupBox.Text = "Patient Information";
            // 
            // _patientIdTextBox
            // 
            _patientIdTextBox.Location = new Point(94, 76);
            _patientIdTextBox.Name = "_patientIdTextBox";
            _patientIdTextBox.ReadOnly = true;
            _patientIdTextBox.Size = new Size(200, 23);
            _patientIdTextBox.TabIndex = 5;
            // 
            // _patientIdLabel
            // 
            _patientIdLabel.AutoSize = true;
            _patientIdLabel.Location = new Point(6, 80);
            _patientIdLabel.Name = "_patientIdLabel";
            _patientIdLabel.Size = new Size(61, 15);
            _patientIdLabel.TabIndex = 4;
            _patientIdLabel.Text = "Patient ID:";
            // 
            // _dobPicker
            // 
            _dobPicker.Location = new Point(94, 47);
            _dobPicker.Name = "_dobPicker";
            _dobPicker.Size = new Size(200, 23);
            _dobPicker.TabIndex = 3;
            // 
            // _dobLabel
            // 
            _dobLabel.AutoSize = true;
            _dobLabel.Location = new Point(6, 51);
            _dobLabel.Name = "_dobLabel";
            _dobLabel.Size = new Size(76, 15);
            _dobLabel.TabIndex = 2;
            _dobLabel.Text = "Date of Birth:";
            // 
            // _patientNameTextBox
            // 
            _patientNameTextBox.Location = new Point(94, 19);
            _patientNameTextBox.Name = "_patientNameTextBox";
            _patientNameTextBox.Size = new Size(200, 23);
            _patientNameTextBox.TabIndex = 1;
            // 
            // _patientNameLabel
            // 
            _patientNameLabel.AutoSize = true;
            _patientNameLabel.Location = new Point(6, 22);
            _patientNameLabel.Name = "_patientNameLabel";
            _patientNameLabel.Size = new Size(82, 15);
            _patientNameLabel.TabIndex = 0;
            _patientNameLabel.Text = "Patient Name:";
            // 
            // _saveButton
            // 
            _saveButton.Location = new Point(12, 140);
            _saveButton.Name = "_saveButton";
            _saveButton.Size = new Size(75, 23);
            _saveButton.TabIndex = 6;
            _saveButton.Text = "Save";
            _saveButton.UseVisualStyleBackColor = true;
            // 
            // _loadButton
            // 
            _loadButton.Location = new Point(93, 140);
            _loadButton.Name = "_loadButton";
            _loadButton.Size = new Size(75, 23);
            _loadButton.TabIndex = 7;
            _loadButton.Text = "Load";
            _loadButton.UseVisualStyleBackColor = true;
            // 
            // _printButton
            // 
            _printButton.Location = new Point(174, 140);
            _printButton.Name = "_printButton";
            _printButton.Size = new Size(75, 23);
            _printButton.TabIndex = 9;
            _printButton.Text = "Print";
            _printButton.UseVisualStyleBackColor = true;
            // 
            // _exportTextButton
            // 
            _exportTextButton.Location = new Point(255, 140);
            _exportTextButton.Name = "_exportTextButton";
            _exportTextButton.Size = new Size(95, 23);
            _exportTextButton.TabIndex = 10;
            _exportTextButton.Text = "Export to Text";
            _exportTextButton.UseVisualStyleBackColor = true;
            // 
            // _exitButton
            // 
            _exitButton.Location = new Point(530, 140);
            _exitButton.Name = "_exitButton";
            _exitButton.Size = new Size(75, 23);
            _exitButton.TabIndex = 12;
            _exitButton.Text = "Exit";
            _exitButton.UseVisualStyleBackColor = true;
            // 
            // _newPrescriptionButton
            // 
            _newPrescriptionButton.Location = new Point(356, 140);
            _newPrescriptionButton.Name = "_newPrescriptionButton";
            _newPrescriptionButton.Size = new Size(120, 23);
            _newPrescriptionButton.TabIndex = 13;
            _newPrescriptionButton.Text = "New Prescription";
            _newPrescriptionButton.UseVisualStyleBackColor = true;
            // 
            // _historyButton
            // 
            _historyButton.Location = new Point(611, 140);
            _historyButton.Name = "_historyButton";
            _historyButton.Size = new Size(75, 23);
            _historyButton.TabIndex = 14;
            _historyButton.Text = "History";
            _historyButton.UseVisualStyleBackColor = true;
            // 
            // _symptomsGroupBox
            // 
            _symptomsGroupBox.Controls.Add(_symptomsTextBox);
            _symptomsGroupBox.Controls.Add(_suggestMedicineButton);
            _symptomsGroupBox.Controls.Add(_suggestionListBox);
            _symptomsGroupBox.Controls.Add(_addSuggestionButton);
            _symptomsGroupBox.Location = new Point(12, 170);
            _symptomsGroupBox.Name = "_symptomsGroupBox";
            _symptomsGroupBox.Size = new Size(776, 260);
            _symptomsGroupBox.TabIndex = 11;
            _symptomsGroupBox.TabStop = false;
            _symptomsGroupBox.Text = "Symptoms and Suggestions";
            // 
            // _symptomsTextBox
            // 
            _symptomsTextBox.Location = new Point(6, 22);
            _symptomsTextBox.Multiline = true;
            _symptomsTextBox.Name = "_symptomsTextBox";
            _symptomsTextBox.Size = new Size(764, 50);
            _symptomsTextBox.TabIndex = 0;
            // 
            // _suggestMedicineButton
            // 
            _suggestMedicineButton.Location = new Point(6, 78);
            _suggestMedicineButton.Name = "_suggestMedicineButton";
            _suggestMedicineButton.Size = new Size(120, 23);
            _suggestMedicineButton.TabIndex = 1;
            _suggestMedicineButton.Text = "Suggest Medicine";
            _suggestMedicineButton.UseVisualStyleBackColor = true;
            // 
            // _suggestionListBox
            // 
            _suggestionListBox.FormattingEnabled = true;
            _suggestionListBox.Location = new Point(6, 107);
            _suggestionListBox.Name = "_suggestionListBox";
            _suggestionListBox.Size = new Size(764, 94);
            _suggestionListBox.TabIndex = 2;
            // 
            // _addSuggestionButton
            // 
            _addSuggestionButton.Location = new Point(6, 213);
            _addSuggestionButton.Name = "_addSuggestionButton";
            _addSuggestionButton.Size = new Size(150, 23);
            _addSuggestionButton.TabIndex = 3;
            _addSuggestionButton.Text = "Add to Prescription";
            _addSuggestionButton.UseVisualStyleBackColor = true;
            _addSuggestionButton.Click += _addSuggestionButton_Click_1;
            // 
            // _prescriptionGroupBox
            // 
            _prescriptionGroupBox.Controls.Add(_addPrescriptionButton);
            _prescriptionGroupBox.Controls.Add(_numberOfDaysTextBox);
            _prescriptionGroupBox.Controls.Add(label3);
            _prescriptionGroupBox.Controls.Add(_timesPerDayTextBox);
            _prescriptionGroupBox.Controls.Add(label2);
            _prescriptionGroupBox.Controls.Add(_medicineNameTextBox);
            _prescriptionGroupBox.Controls.Add(label1);
            _prescriptionGroupBox.Controls.Add(_prescriptionDataGridView);
            _prescriptionGroupBox.Location = new Point(12, 440);
            _prescriptionGroupBox.Name = "_prescriptionGroupBox";
            _prescriptionGroupBox.Size = new Size(776, 250);
            _prescriptionGroupBox.TabIndex = 8;
            _prescriptionGroupBox.TabStop = false;
            _prescriptionGroupBox.Text = "Prescription List";
            // 
            // _addPrescriptionButton
            // 
            _addPrescriptionButton.Location = new Point(6, 211);
            _addPrescriptionButton.Name = "_addPrescriptionButton";
            _addPrescriptionButton.Size = new Size(75, 23);
            _addPrescriptionButton.TabIndex = 7;
            _addPrescriptionButton.Text = "Add";
            _addPrescriptionButton.UseVisualStyleBackColor = true;
            // 
            // _numberOfDaysTextBox
            // 
            _numberOfDaysTextBox.Location = new Point(600, 182);
            _numberOfDaysTextBox.Name = "_numberOfDaysTextBox";
            _numberOfDaysTextBox.Size = new Size(100, 23);
            _numberOfDaysTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(500, 185);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 5;
            label3.Text = "Number of Days:";
            // 
            // _timesPerDayTextBox
            // 
            _timesPerDayTextBox.Location = new Point(394, 182);
            _timesPerDayTextBox.Name = "_timesPerDayTextBox";
            _timesPerDayTextBox.Size = new Size(100, 23);
            _timesPerDayTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 185);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 3;
            label2.Text = "Times Per Day:";
            // 
            // _medicineNameTextBox
            // 
            _medicineNameTextBox.Location = new Point(103, 182);
            _medicineNameTextBox.Name = "_medicineNameTextBox";
            _medicineNameTextBox.Size = new Size(200, 23);
            _medicineNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 185);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 1;
            label1.Text = "Medicine Name:";
            // 
            // _prescriptionDataGridView
            // 
            _prescriptionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _prescriptionDataGridView.Location = new Point(6, 22);
            _prescriptionDataGridView.Name = "_prescriptionDataGridView";
            _prescriptionDataGridView.Size = new Size(764, 150);
            _prescriptionDataGridView.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 700);
            Controls.Add(_symptomsGroupBox);
            Controls.Add(_prescriptionGroupBox);
            Controls.Add(_printButton);
            Controls.Add(_exportTextButton);
            Controls.Add(_loadButton);
            Controls.Add(_saveButton);
            Controls.Add(_patientInfoGroupBox);
            Controls.Add(_exitButton);
            Controls.Add(_newPrescriptionButton);
            Controls.Add(_historyButton);
            Name = "Form1";
            Text = "ENT Clinic - Prescription";
            _patientInfoGroupBox.ResumeLayout(false);
            _patientInfoGroupBox.PerformLayout();
            _symptomsGroupBox.ResumeLayout(false);
            _symptomsGroupBox.PerformLayout();
            _prescriptionGroupBox.ResumeLayout(false);
            _prescriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_prescriptionDataGridView).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _patientInfoGroupBox;
        private System.Windows.Forms.Label _patientNameLabel;
        private System.Windows.Forms.TextBox _patientNameTextBox;
        private System.Windows.Forms.Label _dobLabel;
        private System.Windows.Forms.DateTimePicker _dobPicker;
        private System.Windows.Forms.Label _patientIdLabel;
        private System.Windows.Forms.TextBox _patientIdTextBox;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.Button _printButton;
        private System.Windows.Forms.Button _exportTextButton;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Button _newPrescriptionButton;
        private System.Windows.Forms.Button _historyButton;
        private System.Windows.Forms.GroupBox _symptomsGroupBox;
        private System.Windows.Forms.TextBox _symptomsTextBox;
        private System.Windows.Forms.Button _suggestMedicineButton;
        private System.Windows.Forms.ListBox _suggestionListBox;
        private System.Windows.Forms.Button _addSuggestionButton;
        private System.Windows.Forms.GroupBox _prescriptionGroupBox;
        private System.Windows.Forms.DataGridView _prescriptionDataGridView;
        private System.Windows.Forms.TextBox _medicineNameTextBox;
        private System.Windows.Forms.TextBox _timesPerDayTextBox;
        private System.Windows.Forms.TextBox _numberOfDaysTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _addPrescriptionButton;
    }
}
