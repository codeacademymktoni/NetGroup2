using PizzaPlace.Models;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        void Add(Subscription subscription);
        Subscription GetByEmail(string email);
    }
}
