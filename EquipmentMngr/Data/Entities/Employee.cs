using EquipmentMngr.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public class Employee : Entity
    {
        [Key] public int Id { get; set; }
        [Display(Name = "Name")] public string Name => $"{FirstName} {LastName}";
        [Display(Name = "First Name")] public string FirstName { get; set; }
        [Display(Name = "Last Name")] public string LastName { get; set; }
        [Display(Name = "Email")] public string Email { get; set; }
        public string ColleagueId { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();
    }
}