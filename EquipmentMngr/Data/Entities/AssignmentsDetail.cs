
using System;

namespace EquipmentMngr.Data.Entities
{
    public class AssignmentsDetail
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string ColleagueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public int RoomNumber { get; set; }
        public string RequestedBy { get; set; }
        public int AssignedById { get; set; }
        public DateTime AssignedDate { get; set; }
        public int EquipmentTypeId { get; set; }
        public string EquipmentType { get; set; }
        public int ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNum { get; set; }
        public string ServiceTag { get; set; }
        public int? UnassignedById { get; set; }
        public DateTime? UnassignedDate { get; set; }
    }
}