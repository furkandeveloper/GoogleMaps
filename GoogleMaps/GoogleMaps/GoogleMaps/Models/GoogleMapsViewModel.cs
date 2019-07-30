using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleMaps.Models
{
    public class GoogleMapsViewModel
    {
        [Required]
        public string Adress { get; set; }

        public string xCordinat { get; set; }

        public string yCordinat { get; set; }

        public string FullAddress { get; set; }

        public string Message { get; set; }
    }
}
