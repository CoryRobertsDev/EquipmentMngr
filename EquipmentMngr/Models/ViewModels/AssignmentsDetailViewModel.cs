using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Data.Entities;

namespace EquipmentMngr.Models.ViewModels
{
    [NotMapped]
    public class AssignmentDetailViewModel : ColleagueNames
    {
        public Assignment Id { get; set; }
        public Assignment Location { get; set; }
        public Department Name { get; set; }
        public Equipment SerialNum { get; set; }
        public Equipment ServiceTag { get; set; }
        public Equipment Model { get; set; }
        public Equipment SubModel { get; set; }
        public Equipment Manufacturer { get; set; }
        public Equipment EquipmentType { get; set; }
        public Equipment Warranty { get; set; }
        public Equipment Vendor { get; set; }
    }
}
