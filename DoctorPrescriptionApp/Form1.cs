using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DoctorPrescriptionApp
{
    public partial class Form1 : Form
    {
        private Patient _currentPatient;
        private PrintDocument _printDocument;
        private static int _nextPatientId = 1;
        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += _printDocument_PrintPage;

            _saveButton.Click += _saveButton_Click;
            _loadButton.Click += _loadButton_Click;
            _addPrescriptionButton.Click += _addPrescriptionButton_Click;
            _printButton.Click += _printButton_Click;
            _exportTextButton.Click += _exportTextButton_Click;
            _suggestMedicineButton.Click += _suggestMedicineButton_Click;
            _addSuggestionButton.Click += _addSuggestionButton_Click;
            _exitButton.Click += _exitButton_Click;
            _newPrescriptionButton.Click += _newPrescriptionButton_Click;
            _historyButton.Click += _historyButton_Click;

            ClearForm();
        }

        private void _historyButton_Click(object sender, EventArgs e)
        {
            new HistoryForm().Show();
        }

        private void ClearForm()
        {
            _currentPatient = new Patient { PatientId = _nextPatientId.ToString(), Date = DateTime.Today };
            _nextPatientId++;

            _patientNameTextBox.Text = string.Empty;
            _dobPicker.Value = DateTime.Today;
            _patientIdTextBox.Text = _currentPatient.PatientId;
            _symptomsTextBox.Text = string.Empty;
            _suggestionListBox.Items.Clear();
            _medicineNameTextBox.Text = string.Empty;
            _timesPerDayTextBox.Text = string.Empty;
            _numberOfDaysTextBox.Text = string.Empty;

            if (_prescriptionDataGridView.Columns.Count == 0)
            {
                _prescriptionDataGridView.AutoGenerateColumns = false;
                _prescriptionDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineName", HeaderText = "Medicine Name", Width = 300 });
                _prescriptionDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TimesPerDay", HeaderText = "Times Per Day" });
                _prescriptionDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NumberOfDays", HeaderText = "Number of Days" });
            }
            _prescriptionDataGridView.DataSource = new BindingList<Prescription>(_currentPatient.Prescriptions);
        }

        private void _newPrescriptionButton_Click(object sender, EventArgs e)
        {
            if (_currentPatient.Prescriptions.Any())
            {
                if (MessageBox.Show("Start a new prescription? The current one will be cleared.", "New Prescription", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClearForm();
                }
            }
            else
            {
                ClearForm();
            }
        }

        private void _exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void _suggestMedicineButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_symptomsTextBox.Text))
            {
                MessageBox.Show("Please enter symptoms first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string apiKey = "AIzaSyD8lANjSDGCpAgzPRg9DY0FnpO988qlIcI";
            string prompt = "You are an ENT specialist. Based on these symptoms: '" + _symptomsTextBox.Text + "', suggest 3-4 appropriate medicines and return ONLY a markdown table with this EXACT format:\n\n| MedicineName | TimesPerDay | NumberOfDays |\n|--------------|-------------|--------------|\n| Medicine1    | 2           | 7            |";

            string response = await AskGemini(prompt, apiKey);
            MessageBox.Show(response);

            _suggestionListBox.Items.Clear();

            if (response.StartsWith("Error:") || response.StartsWith("Exception:"))
            {
                MessageBox.Show(response, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _suggestionListBox.Items.Add("Failed to get suggestions.");
                return;
            }

            var pattern = @"\|(?<name>.*?)\|\s*(?<dosage>.*?)\|\s*(?<duration>.*?)\|";
            var matches = Regex.Matches(response, pattern);

            var suggestions = new List<MedicineSuggestion>();
            foreach (Match match in matches.Cast<Match>().Skip(1)) // Skip header
            {
                suggestions.Add(new MedicineSuggestion
                {
                    MedicineName = match.Groups["name"].Value.Trim(),
                    TimesPerDay = match.Groups["dosage"].Value.Trim(),
                    NumberOfDays = int.TryParse(match.Groups["duration"].Value.Trim(), out int days) ? days : 0
                });
            }

            if (suggestions.Any())
            {
                foreach (var s in suggestions)
                {
                    _suggestionListBox.Items.Add(s);
                }
            }
            else
            {
                _suggestionListBox.Items.Add("No suggestions found.");
            }
        }

        private void _addSuggestionButton_Click(object sender, EventArgs e)
        {
            if (_suggestionListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a medicine first.");
                return;
            }

            if (_suggestionListBox.SelectedItem is MedicineSuggestion selected)
            {
                _medicineNameTextBox.Text = selected.MedicineName;
                _timesPerDayTextBox.Text = selected.TimesPerDay;
                _numberOfDaysTextBox.Text = selected.NumberOfDays.ToString();
            }
            else
            {
                MessageBox.Show("Please select a valid medicine suggestion (not the header line).");
            }
        }


        private void _addPrescriptionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_medicineNameTextBox.Text) || !int.TryParse(_numberOfDaysTextBox.Text, out _))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentPatient.Prescriptions.Add(new Prescription
            {
                MedicineName = _medicineNameTextBox.Text,
                TimesPerDay = _timesPerDayTextBox.Text,
                NumberOfDays = int.Parse(_numberOfDaysTextBox.Text)
            });
            _medicineNameTextBox.Clear();
            _timesPerDayTextBox.Clear();
            _numberOfDaysTextBox.Clear();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_patientNameTextBox.Text))
            {
                MessageBox.Show("Patient Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentPatient.Name = _patientNameTextBox.Text;
            _currentPatient.DateOfBirth = _dobPicker.Value;
            _currentPatient.Symptoms = _symptomsTextBox.Text;

            string dir = Path.Combine(Application.StartupPath, "Prescriptions");
            Directory.CreateDirectory(dir);
            string path = Path.Combine(dir, $"{_currentPatient.PatientId}_{_currentPatient.Name}.json");

            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(_currentPatient, Formatting.Indented));
                MessageBox.Show("Prescription saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _loadButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "JSON|*.json", Title = "Load Prescription", InitialDirectory = Path.Combine(Application.StartupPath, "Prescriptions") };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentPatient = JsonConvert.DeserializeObject<Patient>(File.ReadAllText(dialog.FileName));
                    DisplayPatientData(_currentPatient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _printButton_Click(object sender, EventArgs e)
        {
            new PrintPreviewDialog { Document = _printDocument }.ShowDialog();
        }

        private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 12);
            Font header = new Font("Arial", 16, FontStyle.Bold);
            float y = e.MarginBounds.Top;

            g.DrawString("ENT Clinic", header, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g) * 2;
            g.DrawString($"Date: {_currentPatient.Date:d}", font, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g) * 3;

            g.DrawString("Patient Information", header, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g) * 2;
            g.DrawString($"Name: {_currentPatient.Name}", font, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g);
            g.DrawString($"Patient ID: {_currentPatient.PatientId}", font, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g) * 2;

            g.DrawString("Prescriptions (Rx)", header, Brushes.Black, e.MarginBounds.Left, y);
            y += font.GetHeight(g) * 2;

            foreach (var p in _currentPatient.Prescriptions)
            {
                g.DrawString($"{p.MedicineName} - {p.TimesPerDay} for {p.NumberOfDays} days", font, Brushes.Black, e.MarginBounds.Left, y);
                y += font.GetHeight(g);
            }

            g.DrawString("Dr. Loknath", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom - font.GetHeight(g));
        }

        private void _exportTextButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Text|*.txt",
                FileName = $"{_currentPatient.PatientId}.txt",
                InitialDirectory = Path.Combine(Application.StartupPath, "Prescriptions")
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Date: {_currentPatient.Date:d}");
                sb.AppendLine($"Patient: {_currentPatient.Name} (ID: {_currentPatient.PatientId})");
                sb.AppendLine("---");
                foreach (var p in _currentPatient.Prescriptions)
                {
                    sb.AppendLine($"{p.MedicineName}, {p.TimesPerDay}, {p.NumberOfDays} days");
                }
                File.WriteAllText(dialog.FileName, sb.ToString());
            }
        }

        private void DisplayPatientData(Patient patient)
        {
            _patientNameTextBox.Text = patient.Name;
            _dobPicker.Value = patient.DateOfBirth;
            _patientIdTextBox.Text = patient.PatientId;
            _symptomsTextBox.Text = patient.Symptoms;
            _prescriptionDataGridView.DataSource = new BindingList<Prescription>(patient.Prescriptions);
        }

        public async Task<string> AskGemini(string prompt, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey) || !apiKey.StartsWith("AIza"))
            {
                return "Error: Invalid API Key format.";
            }

            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"API Error: {response.StatusCode}\n{responseBody}";
                }

                var jsonResponse = JObject.Parse(responseBody);
                string rawText = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                return string.IsNullOrEmpty(rawText) ? "Error: No text in API response." : rawText;
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        private void _addSuggestionButton_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class MedicineSuggestion
    {
        public string MedicineName { get; set; }
        public string TimesPerDay { get; set; }
        public int NumberOfDays { get; set; }
        
        public override string ToString()
        {
            return $"{MedicineName} ({TimesPerDay}, {NumberOfDays} days)";
        }
    }
}
