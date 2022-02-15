using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
