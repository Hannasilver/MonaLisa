using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDipl_Hanna3.Models
{
    public class Employees
    {
        [Key]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Beautician")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname:")]
        public string Surname { get; set; }

        [NotMapped]
        public virtual ICollection<Clients> Client { get; set; }

        public Employees()
        {
            this.EmployeeId = "1";
            this.FirstName = "Kate";
            this.Surname = "Walden";


        }

    }
}