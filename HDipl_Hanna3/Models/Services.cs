using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDipl_Hanna3.Models
{
    public class Services
    {

        [Key]
        public string ServiceId { get; set; }

        [Required]
        [Display(Name = "Service Description")]
        public string ServiceDescritption { get; set; }

        [Display(Name = "Price (€):")]
        public double Price { get; set; }

        [NotMapped]
        public virtual ICollection<Clients> Client { get; set; }

    


        public Services()
        {
            this.ServiceId = "1";
            this.ServiceDescritption = "Haircut";
            this.Price = 30;


        }
    }
}