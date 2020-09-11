using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMngr.Data.Entities
{
    public class ColleagueNames
    {
        [Key]
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int EquipmenteId { get; set; }
        public string ColleagueId { get; set; }
        public string Fullname { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();
    }
}