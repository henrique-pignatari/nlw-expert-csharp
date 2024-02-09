using RocktseatAuction.API.Entities;

namespace RocktseatAuction.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
