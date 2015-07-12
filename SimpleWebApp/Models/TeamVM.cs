using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Team;

namespace SimpleWebApp.Models
{
    //Observera att vi refererar till Member som finns i klassbiblioteket Team
    public class TeamVM
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Member Coach { get; set; }
        public string Town { get; set; }
    }
}