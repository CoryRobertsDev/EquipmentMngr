﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public partial class ViewAssignmentsDetail
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string ColleagueId { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(80)]
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        public int LocationId { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        public int RoomNumber { get; set; }
        public string RequestedBy { get; set; }
        public int AssignedById { get; set; }
        public DateTime AssignedDate { get; set; }
        public int EquipmentTypeId { get; set; }
        [StringLength(100)]
        public string EquipmentType { get; set; }
        public int ManufacturerId { get; set; }
        [StringLength(100)]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNum { get; set; }
        [Required]
        public string ServiceTag { get; set; }
        public int? UnassignedById { get; set; }
        public DateTime? UnassignedDate { get; set; }
    }
}