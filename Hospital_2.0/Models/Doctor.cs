namespace Hospital_2._0.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public required int BedId { get; set; }
        public required int PatientID { get; set; }
        public required String Firt_Name { get; set; }
        public  String ? Second_Name { get; set; }
        public required String First_last_name { get; set; }
        public required String Second_last_name { get; set; }
        public DateTime ? Birth_date { get; set; }
        public  int ? Age { get; set; }
        public string ? Gender { get; set; }
        public string ? Address { get; set; }
        public int ? Telephone_Number { get; set; }
        public string ? Mail { get; set; }
        public DateTime ? AdmissionDate { get; set; }
        public DateTime ? DepartureDate { get; set; }

        public bool? Active { get; set; }
    }
}
