using Hospital_2._0.Models;
using Hospital_2._0.Repositories;
using System;

namespace Hospital_2._0.Services
{

    public interface IDoctorService
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetDoctor(int IdDoctor);
        Task<Doctor> CreateDoctor
            (int BedId,
            int PatientID,
            String Firt_Name,
            String Second_Name,
            String First_last_name,
            String Second_last_name,
            DateTime Birth_date,
            int Age,
            string Gender,
            string Address,
            int Telephone_Number,
            string Mail,
            DateTime AdmissionDate,
            DateTime DepartureDate
            );
        Task<Doctor> UpdateDoctor
            (
            int IdDoctor,
            int? BedId,
            int? PatientID,
            String? Firt_Name,
            String? Second_Name,
            String First_last_name,
            String Second_last_name,
            DateTime? Birth_date,
            int? Age,
            string? Gender,
            string? Address,
            int? Telephone_Number,
            string? Mail,
            DateTime? AdmissionDate,
            DateTime? DepartureDate
            );

        Task<Doctor> DeleteDoctor(int IdDoctor, bool Active);

    }
    public class DoctorService : IDoctorService
    {
        public readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _doctorRepository.GetAll();
        }

        public async Task<Doctor> GetDoctor(int IdDoctor)
        {
            return await _doctorRepository.GetDoctor(IdDoctor);
        }


        public async Task<Doctor> CreateDoctor(int BedId, int PatientID, string Firt_Name, string Second_Name, string First_last_name, string Second_last_name, DateTime Birth_date, int Age, string Gender, string Address, int Telephone_Number, string Mail, DateTime AdmissionDate, DateTime DepartureDate)
        {
            return await _doctorRepository.CreateDoctor(BedId, PatientID, Firt_Name, Second_Name, First_last_name, Second_last_name, Birth_date, Age, Gender, Address, Telephone_Number, Mail, AdmissionDate, DepartureDate);
        }

        public async Task<Doctor> DeleteDoctor(int IdDoctor, bool Active)
        {

            Doctor DoctorToDelete = await _doctorRepository.GetDoctor(IdDoctor);

            if (DoctorToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                DoctorToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _doctorRepository.UpdateDoctor(DoctorToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Doctor not found.");
            }
        }
        public async Task<Doctor> UpdateDoctor(int IdDoctor, int? BedId, int? PatientID, string? Firt_Name, string? Second_Name, string First_last_name, string Second_last_name, DateTime? Birth_date, int? Age, string? Gender, string? Address, int? Telephone_Number, string? Mail, DateTime? AdmissionDate, DateTime? DepartureDate)
        {
            Doctor newDoctor = await _doctorRepository.GetDoctor(IdDoctor);
            if (newDoctor != null)
            {
                if (Firt_Name != null)
                {
                    newDoctor.BedId = (int)BedId;
                    newDoctor.PatientID = (int)PatientID;
                    newDoctor.Firt_Name = Firt_Name;
                    newDoctor.Second_Name = Second_Name;
                    newDoctor.First_last_name = First_last_name;
                    newDoctor.Second_last_name = Second_last_name;
                    newDoctor.Birth_date = Birth_date;
                    newDoctor.Age = Age;
                    newDoctor.Gender = Gender;
                    newDoctor.Address = Address;
                    newDoctor.Telephone_Number = Telephone_Number;
                    newDoctor.Mail = Mail;
                    newDoctor.AdmissionDate = AdmissionDate;
                    newDoctor.DepartureDate = DepartureDate;
                }
                return await _doctorRepository.UpdateDoctor(newDoctor);
            }
            throw new NotImplementedException();
        }
    }
 }
