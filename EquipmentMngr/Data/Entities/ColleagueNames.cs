using EquipmentMngr.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public class ColleagueNames {

        public string ColleagueId { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        [ForeignKey(nameof(AssignmentId))]
        [InverseProperty("Assignment")]
        public int AssignmentId { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();

    }
}

