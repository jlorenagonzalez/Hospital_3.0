using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_2._0.Models
{
    public class Patient

    {
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public required String Firt_Name { get; set; }
        public String ? Second_Name { get; set; }
        public required String First_last_name { get; set; }
        public required String Second_last_name { get; set; }
        public  DateTime? Birth_date { get; set; }
        public int ? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public int? Telephone_Number { get; set; }
        public string? Mail { get; set; }
        public int? Clinic_History { get; set; }
        public int? ID_Doctor { get; set; }
        public bool? Active { get; set; }
    }
}
