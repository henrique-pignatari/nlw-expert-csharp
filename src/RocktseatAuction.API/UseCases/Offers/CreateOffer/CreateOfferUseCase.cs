using RocktseatAuction.API.Communication.Requests;
using RocktseatAuction.API.Entities;
using RocktseatAuction.API.Repositories;
using RocktseatAuction.API.Services;

namespace RocktseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new RocketseatAuctionDbContext();

        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Offers.Add( offer );
        repository.SaveChanges();

        return offer.Id;
    }
}
