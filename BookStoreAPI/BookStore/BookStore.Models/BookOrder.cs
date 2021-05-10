using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class BookOrder
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
