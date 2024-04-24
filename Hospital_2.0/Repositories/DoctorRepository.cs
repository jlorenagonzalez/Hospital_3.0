using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetDoctor(int idDoctor);
        Task<Doctor> CreateDoctor
            (
            int ParPBedId,
            int ParPatientID,
            String ParFirt_Name,
            String ParSecond_Name,
            String ParFirst_last_name,
            String ParSecond_last_name,
            DateTime ParBirth_date,
            int ParAge,
            string ParGender,
            string ParAddress,
            int ParTelephone_Number,
            string ParMail,
            DateTime ParParAdmissionDate,
            DateTime ParDepartureDate);

        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<Doctor> DeleteDoctor(Doctor doctor);

    }


    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorContext _db;

        public DoctorRepository(DoctorContext db)
        {
            _db = db;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int idDoctor)
        {
            return await _db.Doctors.FirstOrDefaultAsync(u => u.DoctorId == idDoctor);
        }

        public async Task<Doctor> CreateDoctor(int ParPBedId, int ParPatientID, string ParFirt_Name, string ParSecond_Name, string ParFirst_last_name, string ParSecond_last_name, DateTime ParBirth_date, int ParAge, string ParGender, string ParAddress, int ParTelephone_Number, string ParMail, DateTime ParParAdmissionDate, DateTime ParDepartureDate)
        {
            Doctor newDoctor = new Doctor
            {
                BedId = ParPBedId,
                PatientID = ParPatientID,
                Firt_Name = ParFirt_Name,
                Second_Name = ParSecond_Name,
                First_last_name = ParFirst_last_name,
                Second_last_name = ParSecond_Name,
                Birth_date = ParBirth_date,
                Age = ParAge,
                Gender = ParGender,
                Address = ParAddress,
                Telephone_Number = ParTelephone_Number,
                Mail = ParMail,
                AdmissionDate = ParParAdmissionDate,
                DepartureDate = ParDepartureDate
            };

            await _db.Doctors.AddAsync(newDoctor);
            _db.SaveChangesAsync();
            return newDoctor;
        }
        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> DeleteDoctor(Doctor doctor)
        {
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }
    }
}
