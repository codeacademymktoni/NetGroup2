using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System.Collections.Generic;

namespace PizzaPlace.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOffersRepository _offersRepository;

        public OfferService(IOffersRepository offersRepository)
        {
            _offersRepository = offersRepository;
        }

        public List<Offer> GetAllValid()
        {
            return _offersRepository.GetAllValid();
        }
    }
}
