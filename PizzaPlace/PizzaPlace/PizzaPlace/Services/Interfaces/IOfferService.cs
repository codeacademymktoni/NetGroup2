using PizzaPlace.Models;
using System.Collections.Generic;

namespace PizzaPlace.Services.Interfaces
{
    public interface IOfferService
    {
        List<Offer> GetAllValid();
    }
}
