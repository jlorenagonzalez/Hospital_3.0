namespace Hospital_2._0.Models
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public required int PatientId { get; set; }
        public required int DoctorId { get; set; }
        public  DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public required string Description { get; set; }
        public bool ? Active { get; set; }
    }
}
