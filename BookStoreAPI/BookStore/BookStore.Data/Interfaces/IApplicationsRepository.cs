using BookStore.Models;
using System.Threading.Tasks;

namespace BookStore.Data.Interfaces
{
    public interface IApplicationsRepository
    {
        Task<Application> GetByApiKeyAsync(string apiKey);
    }
}
