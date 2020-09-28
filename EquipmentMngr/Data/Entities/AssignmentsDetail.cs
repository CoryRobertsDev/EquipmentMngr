using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMngr.Data.Entities
{
    public class AssignmentsDetail
    {
        [Key]
        public string ColleagueId { get; set; }
        public string Name { get; set; }
        public int AssignmentId { get; set; }
        public string AssignedBy { get; set; }
        public DateTimeOffset AssignedDate { get; set; }
        public int EquipmentId { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public int RoomNumber { get; set; }
        public string EquipmentType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNum { get; set; }
        public string ServiceTag { get; set; }

    }
}

