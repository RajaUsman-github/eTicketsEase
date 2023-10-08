using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePicturUrl { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Actor Bio")]
        public string Bio { get; set; }

        //Relatioship
        public List<Actor_Movie> Actors_Movies { get; set; }
    } 
}
