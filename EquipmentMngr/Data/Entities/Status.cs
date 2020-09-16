using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Models;

namespace EquipmentMngr.Data.Entities
{
    public class Status : Entity
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(100)] public string Name { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Equipment> Equipment { get; set; } = new HashSet<Equipment>();
    }
}