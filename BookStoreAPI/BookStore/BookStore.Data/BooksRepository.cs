using BookStore.Data.Interfaces;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BooksRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void Delete(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book GetByTitle(string title)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Title.ToLower() == title.ToLower());
        }

        public void Update(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
