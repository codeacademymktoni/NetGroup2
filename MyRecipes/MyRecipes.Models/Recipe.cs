﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50,MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Directions { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated{ get; set; }
    }
}
