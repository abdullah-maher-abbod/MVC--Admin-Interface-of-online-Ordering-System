using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SafeDiningAdmin.Models
{
    public class FirebaseData
    {
        
        public string id { get; set; }
        [Required(ErrorMessage = "Must key in the name before submit")]
        public string name { get; set; }
        [Required(ErrorMessage = "Must key in the address before submit")]
        public string address { get; set; }
        [Required(ErrorMessage = "Must key in the availability before submit")]
        public string availability { get; set; }
        [Required(ErrorMessage = "Must key in the category before submit")]
        public string category { get; set; }
       [Required(ErrorMessage = "Must key in the email before submit")]
        public string email { get; set; }
       [Required(ErrorMessage = "Must key in the location before submit")]
        public string location { get; set; }
       [Required(ErrorMessage = "Must key in the price before submit")]
        public string price { get; set; }
        [Required(ErrorMessage = "Must key in the rate before submit")]
        public float rate { get; set; }
        [Required(ErrorMessage = "Must key in the safety before submit")]
        public string safety { get; set; }
        [Required(ErrorMessage = "Must key in the password before submit")]
        public string password { get; set; }
        [Required(ErrorMessage = "Must key in the announcement before submit")]
        public string announcement { get; set; }
        [JsonIgnore]
        public string image { get; set; }
        [JsonIgnore]
        public string steas { get; set; }
        [JsonIgnore]
        public string reviews { get; set; }
        [JsonIgnore]
        public string menu { get; set; }
    }
}
