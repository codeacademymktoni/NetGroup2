
using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Data.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        void Create(Book book);
        void Update(Book book);
        Book GetById(int id);
        void Delete(Book book);
        Book GetByTitle(string title);
        List<Book> GetWithFilters(string title, string author);
    }
}
