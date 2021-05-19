using BookStore.Data.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly BookStoreDbContext _context;

        public ApplicationsRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Application> GetByApiKeyAsync(string apiKey)
        {
            return await _context.Applications.FirstOrDefaultAsync(x => x.Key == apiKey);
        }
    }
}
