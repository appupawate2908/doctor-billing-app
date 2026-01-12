using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DoctorPrescriptionApp
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Symptoms { get; set; }
        public BindingList<Prescription> Prescriptions { get; set; }

        public Patient()
        {
            Prescriptions = new BindingList<Prescription>();
        }
    }
}
