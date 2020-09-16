using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Data.Entities.Base;
using EquipmentMngr.Models;

namespace EquipmentMngr.Data.Entities
{
    public class EquipmentType : Entity
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(100)] public string Name { get; set; }

        [InverseProperty("EquipmentType")]
        public virtual ICollection<Equipment> Equipment { get; set; } = new HashSet<Equipment>();
    }
}