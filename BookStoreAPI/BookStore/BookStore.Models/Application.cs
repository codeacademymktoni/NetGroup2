using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
