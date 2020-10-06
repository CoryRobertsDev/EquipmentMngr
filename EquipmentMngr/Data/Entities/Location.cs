using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Models;

namespace EquipmentMngr.Data.Entities
{
    public class Location : Entity
    {
        [Key] public int Id { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        [InverseProperty("Location")]
        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();
    }
}