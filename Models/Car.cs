using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Car
    {
        
        public string Description { get; set; }

        public string Plate { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
