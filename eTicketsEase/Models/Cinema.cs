﻿using eTicketsEase.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relatioship
        public List<Movie> Movies { get; set; }
    }
}
