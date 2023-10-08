using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        public string ProfilePicturUrl { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        //Relatioship
        public List<Movie> Movies { get; set; }
    }
}
