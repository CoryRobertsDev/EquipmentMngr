using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Infrastructure.Repositories;

namespace EquipmentMngr.Data.Entities
{
    public class Equipment : IAuditable
    {
        [Key] public int Id { get; set; }
        public int EquipmentTypeId { get; set; }
        public int VendorId { get; set; }
        public int ManufacturerId { get; set; }
        [Required] public string Model { get; set; }
        public string SubModel { get; set; }
        [Required] public string SerialNum { get; set; }
        [Required] public string ServiceTag { get; set; }
        public DateTime DateReceived { get; set; }
        public int DepartmentId { get; set; }
        public string RequestedBy { get; set; }
        public bool Warranty { get; set; }
        public DateTime? DecommissionDate { get; set; }
        public bool? DecommissionStatus { get; set; }
        public DateTime? DestroyDate { get; set; }
        public bool? DestroyStatus { get; set; }
        public int? AssignmentId { get; set; }
        public bool? IsAssigned { get; set; }

        [ForeignKey(nameof(AssignmentId))]
        public Assignment Assignment { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        [ForeignKey(nameof(EquipmentTypeId))]
        public EquipmentType EquipmentType { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }

        //public partial class Equipment
        //{
        //    [Key] [DisplayName("Equip. Id")] public int Id { get; set; }

        //    [Display(Name = "Type")] public int EquipmentTypeId { get; set; }

        //    [Display(Name = "Vendor")]
        //    [Required(ErrorMessage = "Vendor is required")]
        //    public int VendorId { get; set; }

        //    [Display(Name = "Manufacturer")]
        //    [Required(ErrorMessage = "Manufacturer is required")]
        //    public int ManufacturerId { get; set; }

        //    [Display(Name = "Model")]
        //    [Required(ErrorMessage = "Please enter model name.")]
        //    public string Model { get; set; }

        //    [DisplayName("Sub-Model")] public string SubModel { get; set; }

        //    [DisplayName("Serial Num.")]
        //    [Required(ErrorMessage = "Please enter serial number.")]
        //    public string SerialNum { get; set; }

        //    [Required(ErrorMessage = "Please enter invoice number.")]
        //    [DisplayName("Service Tag")]
        //    public string ServiceTag { get; set; }

        //    [DataType(DataType.Date)]
        //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //    [Required(ErrorMessage = "Please select a date.")]
        //    [DisplayName("Date Received")]
        //    public DateTime DateReceived { get; set; }

        //    [Display(Name = "Requesting Department")]
        //    [Required(ErrorMessage = "Department is required")]
        //    public int DepartmentId { get; set; }

        //    [DisplayName("Requesting Employee")] public string RequestedBy { get; set; }

        //    [Display(Name = "Warranty")] public bool Warranty { get; set; }

        //    [DataType(DataType.Date)]
        //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //    [DisplayName("Decommission Date")]
        //    //[Required(ErrorMessage = "Please select a date.")]
        //    public DateTime? DecommissionDate { get; set; }

        //    [DisplayName("Decommission Status")]
        //    //[Required(ErrorMessage = "Please select a decommission status")]
        //    public bool? DecommissionStatus { get; set; }

        //    [DataType(DataType.Date)]
        //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //    [DisplayName("Destroy Date")]
        //    //[Required(ErrorMessage = "Please select a date.")]
        //    public DateTime? DestroyDate { get; set; }

        //    [DisplayName("Destroy Status")]
        //    //[Required(ErrorMessage = "Please select a destroy status")]
        //    public bool? DestroyStatus { get; set; }

        //    public bool? IsAssigned { get; set; }

        //    [ForeignKey(nameof(AssignmentId))]
        //    [InverseProperty("Equipment")]
        //    public virtual Assignment Assignment { get; set; }

        //    [NotMapped]
        //    public int AssignmentId { get; set; }

        //    [ForeignKey(nameof(DepartmentId))]
        //    [InverseProperty("Equipment")]
        //    public virtual Department Department { get; set; }

        //    [ForeignKey(nameof(EquipmentTypeId))]
        //    [InverseProperty("Equipment")]
        //    public virtual EquipmentType EquipmentType { get; set; }

        //    [ForeignKey(nameof(ManufacturerId))]
        //    [InverseProperty("Equipment")]
        //    public virtual Manufacturer Manufacturer { get; set; }

        //    [ForeignKey(nameof(VendorId))]
        //    [InverseProperty("Equipment")]
        //    public virtual Vendor Vendor { get; set; }
        [Display(Name = "Created By")] public string CreatedBy { get; set; }
        [Display(Name = "Created On")] public DateTime? CreatedOn { get; set; }
        [Display(Name = "Updated By")] public string UpdatedBy { get; set; }
        [Display(Name = "Updated On By")] public DateTime? UpdatedOn { get; set; }

    }
}