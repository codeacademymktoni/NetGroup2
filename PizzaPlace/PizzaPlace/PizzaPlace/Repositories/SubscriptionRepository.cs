using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Linq;

namespace PizzaPlace.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly PizzaPlaceDbContext pizzaPlaceDbContext;

        public SubscriptionRepository(PizzaPlaceDbContext pizzaPlaceDbContext)
        {
            this.pizzaPlaceDbContext = pizzaPlaceDbContext;
        }

        public void Add(Subscription subscription)
        {
            pizzaPlaceDbContext.Subscriptions.Add(subscription);
            pizzaPlaceDbContext.SaveChanges();
        }

        public Subscription GetByEmail(string email)
        {
            return pizzaPlaceDbContext.Subscriptions.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
