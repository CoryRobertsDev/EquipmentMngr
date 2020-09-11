using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMngr.Data.Entities
{
    public class Employee : Infrastructure.Repositories.IAuditable
    {
        [Key] public int Id { get; set; }
        [Display(Name = "Name")] public string Name => $"{FirstName} {LastName}";
        [Display(Name = "First Name")] public string FirstName { get; set; }
        [Display(Name = "Last Name")] public string LastName { get; set; }
        [Display(Name = "Email")] public string Email { get; set; }
        public string ColleagueId { get; set; }
        [Display(Name = "Created By")] public string CreatedBy { get; set; }
        [Display(Name = "Created On")] public DateTime? CreatedOn { get; set; }
        [Display(Name = "Updated By")] public string UpdatedBy { get; set; }
        [Display(Name = "Updated On By")] public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();

    }
}