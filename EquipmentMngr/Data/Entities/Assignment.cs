using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EquipmentMngr.Infrastructure.Repositories;

namespace EquipmentMngr.Data.Entities
{
    public class Assignment : IAuditable
    {
        [Display(Name = "Assignment Id")]
        public int AssignmentId { get; set; }

        [Display(Name = "Colleague Id")]
        public string ColleagueId { get; set; }

        [Display(Name = "Equipment Id")]
        public int EquipmentId { get; set; }

        [Display(Name = "Room Num.")]
        public int RoomNumber { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Assignment")]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Assignment")]
        public int LocationId { get; set; }

        public bool? Unassigned { get; set; }

        [Timestamp]
        [Display(Name="Date Unassigned")]
        public byte[] RowVersion { get; set; } 

        //IAuditable Fields
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        //Navigation Properties
        public virtual Location Location { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }

    }




}

//[Table("Assignment")]
//public partial class Assignment
//{
//[Key] public int Id { get; set; }



//public int LocationId { get; set; }

//public int DepartmentId { get; set; }

//[Display(Name = "Date Assigned")]
//[DataType(DataType.Date)]
//[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
//public DateTime AssignedDate { get; set; }


//[Display(Name = "Date Unassigned")]
//[DataType(DataType.Date)]
//[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/DD/YYYY}")]
//public DateTime? UnassignedDate { get; set; }

//[Display(Name = "Assigned By")] public int AssignedById { get; set; }

//[Display(Name = "Unassigned By")] public int? UnassignedById { get; set; }

//[ForeignKey(nameof(AssignedById))]
//[InverseProperty(nameof(Employee.AssignmentAssignedBy))]
//public virtual Employee AssignedBy { get; set; }

//[ForeignKey(nameof(DepartmentId))]
//[InverseProperty("Assignment")]
//public virtual Department Department { get; set; }

//[ForeignKey(nameof(LocationId))]
//[InverseProperty("Assignment")]
//public virtual Location Location { get; set; }

//[ForeignKey(nameof(UnassignedById))]
//[InverseProperty(nameof(Employee.AssignmentUnassignedBy))]
//public virtual Employee UnassignedBy { get; set; }

//public ICollection<Equipment> Equipment { get; set; }
//public virtual view_ColleagueNames AssignmentId { get; set; }

