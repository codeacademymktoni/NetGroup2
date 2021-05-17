using BookStore.Models;

namespace BookStore.Data.Interfaces
{
    public interface IApplicationsRepository
    {
        Application GetByApiKey(string apiKey);
    }
}
