using BookStore.Data.Interfaces;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly BookStoreDbContext _context;

        public ApplicationsRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Application GetByApiKey(string apiKey)
        {
            return _context.Applications.FirstOrDefault(x => x.Key == apiKey);
        }
    }
}
