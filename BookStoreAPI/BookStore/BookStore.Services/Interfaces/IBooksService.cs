using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAll();
        Task<bool> CreateAsync(Book book);
        void Update(Book book);
        void Delete(int id);
        Book GetById(int id);
        List<Book> GetWithFilters(string title, string author);
    }
}
