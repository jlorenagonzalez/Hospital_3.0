using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Hospital_2._0.Repositories;
using Microsoft.Extensions.Primitives;
using System;

namespace Hospital_2._0.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAll();
        Task<Patient> GetPatient(int idPatient);
        Task<Patient> CreatePatient(String Pfirt_Name, String Psecond_Name, String Pfirst_last_name, String Psecond_last_name, DateTime Pbirth_date, int Page, string Pgender, string Paddress, int Ptelephone_Number, string Pmail, int Pclinic_History, int Pid_Doctor);
        Task<Patient> UpdatePatient(int IdPatiente, string? Pfirt_Name = null, String? Psecond_Name = null, String? Pfirst_last_name = null, String? Psecond_last_name = null, DateTime? Pbirth_date = null, int? P_age = null, string? Pgender = null, string? Paddress = null, int? Ptelephone_Number = null, string? Pmail = null, int? Pclinic_History = null, int? Pid_Doctor = null);
        Task<Patient> DeletePatient(int patientID, bool Active);

    }
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {

            _patientRepository = patientRepository;
        }
        public async Task<List<Patient>> GetAll()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patient> GetPatient(int idPatient)
        {
            return await _patientRepository.GetPatient(idPatient);
        }
        public async Task<Patient> CreatePatient(string Pfirt_Name, string Psecond_Name, string Pfirst_last_name, string Psecond_last_name, DateTime Pbirth_date, int P_age, string Pgender, string Paddress, int Ptelephone_Number, string Pmail, int Pclinic_History, int Pid_Doctor)
        {
            return await _patientRepository.CreatePatient(Pfirt_Name,Psecond_Name,Pfirst_last_name, Psecond_last_name,Pbirth_date,P_age,Pgender,Paddress,Ptelephone_Number,Pmail,Pclinic_History,Pid_Doctor);
        }
        public async Task<Patient> UpdatePatient(int PIdPatiente, string? Pfirt_Name = null, String? Psecond_Name = null, String? Pfirst_last_name = null, String? Psecond_last_name = null, DateTime? Pbirth_date = null, int? P_age = null, string? Pgender = null, string? Paddress = null, int? Ptelephone_Number = null, string? Pmail = null, int? Pclinic_History = null, int? Pid_Doctor = null)
        {
            Patient newPatient = await _patientRepository.GetPatient(PIdPatiente);
            if (newPatient != null)
            {
                if (Pfirt_Name != null)
                {
                    newPatient.Firt_Name = Pfirt_Name;
                    newPatient.Second_Name = Psecond_Name;
                    newPatient.First_last_name = Pfirst_last_name;
                    newPatient.Second_last_name = Psecond_last_name;
                    newPatient.Birth_date = Pbirth_date;
                    newPatient.Age = P_age;
                    newPatient.Gender = Pgender;
                    newPatient.Address = Paddress;
                    newPatient.Telephone_Number = Ptelephone_Number;
                    newPatient.Mail = Pmail;
                    newPatient.Clinic_History = Pclinic_History;
                    newPatient.ID_Doctor = Pid_Doctor;



                }
                return await _patientRepository.UpdatePatient(newPatient);
            }
            throw new NotImplementedException();
        }

        public async Task<Patient> DeletePatient(int PatienteId, bool Active)
        {

            Patient PatientToDelete = await _patientRepository.GetPatient(PatienteId);

            if (PatientToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                PatientToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _patientRepository.UpdatePatient(PatientToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Patiente not found.");
            }
        }
    }

}
