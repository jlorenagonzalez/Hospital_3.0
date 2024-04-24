namespace Hospital_2._0.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public required int DoctorId { get; set; }
        public  int ? PatientId { get; set; }
        public  DateTime ? AssignmentDate { get; set; }
        public string ? Description { get; set; }
        public bool? Active { get; set; }
    }
}
