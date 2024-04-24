using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hospital_2._0.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAll();
        Task<Patient> GetPatient(int idPatient);
        Task<Patient> CreatePatient(String Pfirt_Name, String Psecond_Name, String Pfirst_last_name, String Psecond_last_name, DateTime Pbirth_date, int P_age, string Pgender, string Paddress, int Ptelephone_Number, string Pmail, int Pclinic_History, int Pid_Doctor);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> DeletePatient(Patient patient);

    }

    public class PatientRepository : IPatientRepository
    {

        private readonly PatientDbContext _db;
        public PatientRepository(PatientDbContext db) 
        {
            _db = db;
        }

        public async Task<List<Patient>> GetAll()
        {

            #region Pruebas
            //// Recuperar todos los pacientes de la base de datos
            //var patients = await _db.Patients.ToListAsync();

            //// Verificar si algún campo relevante es nulo y manejarlo adecuadamente
            //foreach (var patient in patients)
            //{
            //    if (patient.Second_Name == null)
            //    {
            //        patient.Second_Name = " "; // Asignar un valor por defecto para el nombre si es nulo
            //    }
            //    // Repite este proceso para otros campos que podrían ser nulos
            //}

            //// Devolver la lista de pacientes modificada
            //return patients;

            #endregion 
            return await _db.Patients.ToListAsync();

        }
        public async Task<Patient> GetPatient(int idPatient)
        {
            return await _db.Patients.FirstOrDefaultAsync(u => u.PatientId == idPatient);
        }

        public async Task<Patient> CreatePatient(string Pfirt_Name, string Psecond_Name, string Pfirst_last_name, string Psecond_last_name, DateTime Pbirth_date, int P_age, string Pgender, string Paddress, int Ptelephone_Number, string Pmail, int Pclinic_History, int Pid_Doctor)
        {
            Patient newPatient = new Patient
            {
                Firt_Name = Pfirst_last_name,
                Second_Name = Psecond_Name,
                First_last_name = Pfirst_last_name,
                Second_last_name = Psecond_last_name,
                Birth_date = Pbirth_date,
                Age = P_age,
                Gender = Pgender,
                Address = Paddress,
                Telephone_Number = Ptelephone_Number,
                Mail = Pmail,
                Clinic_History = Pclinic_History,
                ID_Doctor = Pid_Doctor

            };
            await _db.Patients.AddAsync(newPatient);
            _db.SaveChangesAsync();
            return newPatient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
            return patient;
            //throw new NotImplementedException();
        }
        public async Task<Patient> DeletePatient(Patient patient)
        {
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
            return patient;
        }
    }
}
