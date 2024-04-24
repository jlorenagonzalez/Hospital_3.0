namespace Hospital_2._0.Models
{
    public class Bed
    {
        public int BedId { get; set; }
        public  string ? TypeBed{ get; set; }
        public int ? PatientId { get; set; }
        public required String Availability { get; set; }
        public bool? Active { get; set; }
    }
}
