using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public class EquipmentType : Infrastructure.Repositories.IAuditable
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(100)] public string Name { get; set; }
        [InverseProperty("EquipmentType")] public virtual ICollection<Equipment> Equipment { get; set; } = new HashSet<Equipment>();
    }
}