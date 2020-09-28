using EquipmentMngr.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Controllers;


namespace EquipmentMngr.Data.Entities
{
    public class Equipment : Entity
    {
        [Key] public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public int VendorId { get; set; } 
        public int ManufacturerId { get; set; }
        [Required] public string Model { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        public string SubModel { get; set; }
        [Required] public string SerialNum { get; set; }
        [Required] public string ServiceTag { get; set; }

        [Display(Name = "Received")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")] 
        public DateTime DateReceived { get; set; }
        public bool Warranty { get; set; }
        public int StatusId { get; set; }

        [Display(Name="Type")]
        [ForeignKey(nameof(EquipmentTypeId))] public EquipmentType EquipmentType { get; set; }
        [ForeignKey(nameof(ManufacturerId))] public Manufacturer Manufacturer { get; set; }
        [ForeignKey(nameof(VendorId))] public Vendor Vendor { get; set; }
        [ForeignKey(nameof(StatusId))] public Status Status { get; set; }

    }
}