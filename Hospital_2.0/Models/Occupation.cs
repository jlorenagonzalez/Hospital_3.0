using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_2._0.Models
{
    public class Occupation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OccupationId { get; set; }
        public int? IdDoctor { get; set; }
        public DateTime? DateOccupation { get; set; }
        public int ? IdPaciente { get; set; }
        public int? State { get; set; }

        public bool? Active { get; set; }

    }
}
