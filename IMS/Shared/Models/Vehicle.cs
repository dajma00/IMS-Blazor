using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IMS.Shared.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VehicleID { get; set; }
        public int QuoteID { get; set; }
        public string VehicleName { get; set; }
        public List<Driver> Drivers;
        public Vehicle() //constructor
        {
            VehicleName = "";
            Drivers = new List<Driver>();
        }
    }
}
