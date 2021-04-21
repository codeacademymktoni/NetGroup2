using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System;

namespace PizzaPlace.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public void Create(string email)
        {
            var existingSubscription = subscriptionRepository.GetByEmail(email);

            if(existingSubscription == null)
            {
                var newSubscription = new Subscription()
                {
                    Email = email,
                    DateCreated = DateTime.Now
                };

                subscriptionRepository.Add(newSubscription);
            }
        }
    }
}
