using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FullPrice { get; set; }
        [Required]
        public List<BookOrder> Books { get; set; }
    }
}
