using Microsoft.EntityFrameworkCore;
using RocktseatAuction.API.Contracts;
using RocktseatAuction.API.Entities;
using RocktseatAuction.API.Repositories;

namespace RocktseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }

    public Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}
