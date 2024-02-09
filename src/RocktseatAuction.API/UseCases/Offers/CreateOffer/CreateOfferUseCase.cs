using RocktseatAuction.API.Communication.Requests;
using RocktseatAuction.API.Contracts;
using RocktseatAuction.API.Entities;
using RocktseatAuction.API.Repositories;
using RocktseatAuction.API.Repositories.DataAccess;
using RocktseatAuction.API.Services;

namespace RocktseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    private readonly IOfferRepository _offerRepository;

    public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository offerRepository)
    {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        _offerRepository.Add( offer );

        return offer.Id;
    }
}
