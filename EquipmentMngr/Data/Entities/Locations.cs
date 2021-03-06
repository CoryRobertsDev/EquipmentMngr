﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Infrastructure.Repositories;

namespace EquipmentMngr.Data.Entities
{
    public class Location : IAuditable
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(100)] public string Name { get; set; }
        [Display(Name = "Created By")] public string CreatedBy { get; set; }
        [Display(Name = "Created On")] public DateTime? CreatedOn { get; set; }
        [Display(Name = "Updated By")] public string UpdatedBy { get; set; }
        [Display(Name = "Updated On By")] public DateTime? UpdatedOn { get; set; }
        [InverseProperty("Location")] public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();
    }
}
