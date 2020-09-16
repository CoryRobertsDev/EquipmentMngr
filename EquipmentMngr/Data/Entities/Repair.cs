using EquipmentMngr.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentMngr.Data.Entities
{
    public class Repair : Entity
    {
        [Display(Name = "Equipment Id")]
        [Required(ErrorMessage = "Equipment Id is Required")]
        public int Id { get; set; }

        [Display(Name = "Date Shipped")]
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")] 
        public DateTime DateShipped { get; set; }

        [Display(Name = "Tracking")]
        [Required(ErrorMessage = "Tracking is Required")]
        public string TrackingNum { get; set; }

        [Display(Name = "Recipient")]
        [Required(ErrorMessage = "Recipient is Required")]
        public string Recipient { get; set; }

        [Display(Name = "Street Address 1")]
        [Required(ErrorMessage = "Address is Required")]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Street Address 2")] public string StreetAddress2 { get; set; }

        //[Display(Name = "Street Address 3")]
        //public string StreetAddress3 { get; set; }

        [NotMapped]
        [Display(Name = "Address")]
        public string FriendlyAddress => string.IsNullOrWhiteSpace(StreetAddress1)
            ? $"{City}, {States.Abbreviation}, {Zip}"
            : string.IsNullOrWhiteSpace(StreetAddress2)
                ? $"{StreetAddress1}, {City}, {States.Abbreviation}, {Zip}"
                : $"{StreetAddress1} - {StreetAddress2}, {City}, {States.Abbreviation}, {Zip}";


        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty(nameof(State.Repairs))]
        public virtual State States { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)",
            ErrorMessage = "Zip code is invalid.")] // US or Canada
        public string Zip { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string ContactPhone { get; set; }

        [Display(Name = "Replacement Serial")] public string ReplacementSerialNumber { get; set; }

        public bool? Returned { get; set; }

        [Display(Name = "Date Returned")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")] 
        public DateTime? DateReturned { get; set; }
    }
}