using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
