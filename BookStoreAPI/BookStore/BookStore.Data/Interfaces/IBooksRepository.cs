
using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Data.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        void Create(Book book);
        void Update(Book book);
        Book GetById(int id);
        void Delete(Book book);
        Task<Book> GetByTitleAsync(string title);
        List<Book> GetWithFilters(string title, string author);
    }
}
