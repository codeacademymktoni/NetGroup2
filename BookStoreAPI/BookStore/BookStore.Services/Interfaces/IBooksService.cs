using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Services.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAll();
        bool Create(Book book);
        void Update(Book book);
        void Delete(int id);
        Book GetById(int id);
    }
}
