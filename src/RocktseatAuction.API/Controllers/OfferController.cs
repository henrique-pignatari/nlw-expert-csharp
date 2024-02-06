using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocktseatAuction.API.Communication.Requests;
using RocktseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocktseatAuction.API.Controllers;

public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
