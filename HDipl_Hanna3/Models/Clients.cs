using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDipl_Hanna3.Models
{
    public class Clients
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Appoinment Date and Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime AppointmentDate { get; set; }


        [ForeignKey("Service")]
        public string ServiceId { get; set; }

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname:")]
        public string Surname { get; set; }


        [Required]
        [Phone]
        [Display(Name = "Phone Number:")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        public virtual Services Service { get; set; }

        public virtual Employees Employee { get; set; }

        public string errorMessage = "";

        public Clients()
        {
            this.ID = 1;
            this.AppointmentDate = new DateTime(2008, 5, 1, 10, 00, 00);
            this.ServiceId = "HiFi";
            this.EmployeeId = "Aoife";
            this.Name = "Alana";
            this.Surname = "Nina";
            this.PhoneNumber = "0866665521";
            this.EmailAddress = "alana@nina.com";

        }

    }

 
}