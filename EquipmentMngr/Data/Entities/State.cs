using EquipmentMngr.Data.Entities.Base;
using EquipmentMngr.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public class State : Entity
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        [InverseProperty("States")] public virtual ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();
    }
}