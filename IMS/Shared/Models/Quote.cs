using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IMS.Shared.Models
{
    public class Quote
    {
     
        
        public int ID { get; set; }
        public int TitleCode { get; set; }
        [Required(ErrorMessage ="Client name is required.")]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string ClientName { get; set; }
    }
}
