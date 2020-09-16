using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Data.Entities.Base;
using EquipmentMngr.Models;

namespace EquipmentMngr.Data.Entities
{
    public class Department : Entity
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(50)] public string Name { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>();

    }
}