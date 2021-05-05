using BookStore.DtoModels;
using BookStore.Models;

namespace BookStore.Mappings
{
    public static class DtoMappings
    {
        public static BookDto ToDtoModel(this Book entity)
        {
            return new BookDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                Genre = entity.Genre,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }

        public static Book ToDomainModel(this BookDto entity)
        {
            return new Book
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                Genre = entity.Genre,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }
    }
}
