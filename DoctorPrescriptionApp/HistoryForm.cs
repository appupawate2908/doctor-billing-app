using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; // Use Newtonsoft.Json for deserialization

namespace DoctorPrescriptionApp
{
    public partial class HistoryForm : Form
    {
        private List<PrescriptionHistoryItem> _allPrescriptions;

        public HistoryForm()
        {
            InitializeComponent();
            LoadHistory();
            _searchButton.Click += _searchButton_Click;
        }

        private void LoadHistory()
        {
            _allPrescriptions = new List<PrescriptionHistoryItem>();
            string prescriptionsFolder = Path.Combine(Application.StartupPath, "Prescriptions");
            
            if (!Directory.Exists(prescriptionsFolder))
            {
                Directory.CreateDirectory(prescriptionsFolder);
            }

            string[] files = Directory.GetFiles(prescriptionsFolder, "*.json");

            foreach (string file in files)
            {
                try
                {
                    string jsonString = File.ReadAllText(file);
                    var patient = JsonConvert.DeserializeObject<Patient>(jsonString); // Use JsonConvert
                    if (patient != null)
                    {
                        foreach (var prescription in patient.Prescriptions)
                        {
                            _allPrescriptions.Add(new PrescriptionHistoryItem
                            {
                                Date = patient.Date,
                                PatientId = patient.PatientId,
                                PatientName = patient.Name,
                                Symptoms = patient.Symptoms,
                                MedicineName = prescription.MedicineName,
                                TimesPerDay = prescription.TimesPerDay,
                                NumberOfDays = prescription.NumberOfDays
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file {file}: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _historyDataGridView.DataSource = new BindingList<PrescriptionHistoryItem>(_allPrescriptions);
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = _datePicker.Value.Date;
            var filteredPrescriptions = _allPrescriptions.Where(p => p.Date.Date == selectedDate).ToList();
            _historyDataGridView.DataSource = new BindingList<PrescriptionHistoryItem>(filteredPrescriptions);
        }
    }

    public class PrescriptionHistoryItem
    {
        public DateTime Date { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string Symptoms { get; set; }
        public string MedicineName { get; set; }
        public string TimesPerDay { get; set; }
        public int NumberOfDays { get; set; }
    }
}
