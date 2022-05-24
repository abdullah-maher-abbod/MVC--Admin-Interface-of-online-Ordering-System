using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SafeDiningAdmin.Models
{
    public class FirebaseReviews
    {
        
        public string id { get; set; }
        public string name { get; set; }
        public string rate { get; set; }      
        public string text { get; set; }
        public string timestamp { get; set; }
    }
}
