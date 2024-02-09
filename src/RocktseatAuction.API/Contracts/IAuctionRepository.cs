using RocktseatAuction.API.Entities;

namespace RocktseatAuction.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
