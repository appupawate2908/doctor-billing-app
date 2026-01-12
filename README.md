# Doctor Prescription Application

This is a .NET Windows Forms application designed for ENT specialists to streamline the process of creating, managing, and printing patient prescriptions. The application leverages the Google Gemini API to provide intelligent medicine suggestions based on patient symptoms.

## Features

- **Patient Information Management**: Add and save patient details including name, date of birth, and an automatically generated patient ID.
- **Symptom & Suggestion Engine**: Enter patient symptoms and receive medicine suggestions from the Google Gemini API.
- **Dynamic Prescription List**: Add suggested medicines or enter them manually into a structured prescription grid.
- **Save & Load**: Save individual patient prescriptions as JSON files for easy retrieval and record-keeping.
- **Print & Export**:
    - Generate a print preview and print a professional-looking prescription.
    - Export prescription details to a simple text file.
- **Prescription History**: View a history of all saved prescriptions in a separate form, with the ability to filter by date.

## Setup & Usage

### 1. Prerequisites

- .NET Desktop Runtime
- A valid Google Gemini API Key

### 2. Configuration

Before running the application, you must provide your Google Gemini API key.

**Option 1: Environment Variable (Recommended)**
   - Create an environment variable named `GEMINI_API_KEY`.
   - Set its value to the API key you obtained from Google AI Studio.

**Option 2: Hardcode (For testing only)**
   - Open the `Form1.cs` file.
   - Locate the `_suggestMedicineButton_Click` method.
   - Replace the placeholder in the `apiKey` variable with your actual key:
     ```csharp
     string apiKey = "YOUR_API_KEY_HERE";
     ```

### 3. Running the Application

1.  Navigate to the project's output directory:
    ```
    cd bin\Debug\net10.0-windows
    ```
2.  Run the executable:
    ```
    DoctorPrescriptionApp.exe
    ```

### How to Use

1.  The application starts with a new, empty prescription and an auto-generated Patient ID.
2.  Fill in the **Patient Information** and **Symptoms**.
3.  Click **"Suggest Medicine"** to get AI-powered suggestions.
4.  Select a suggestion and click **"Add to Prescription"** to populate the medicine fields.
5.  Click **"Add"** to add the medicine to the patient's prescription list.
6.  Click **"Save"** to save the complete prescription to a JSON file in the `Prescriptions` folder.
7.  Click **"Print"** to see a print preview and print the prescription.
8.  Click **"History"** to view and filter all past prescriptions.
9.  Click **"New Prescription"** to clear the form for the next patient.