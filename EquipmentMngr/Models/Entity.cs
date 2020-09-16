using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMngr.Models
{
    public abstract class Entity
    {
        [Display(Name = "Created By")] public string CreatedByUser { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified By")] public string ModifiedByUser { get; set; }

        [Display(Name = "Modified Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTimeOffset ModifiedDate { get; set; }
    }
}