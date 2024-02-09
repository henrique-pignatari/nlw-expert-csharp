using Microsoft.AspNetCore.Mvc;
using RocktseatAuction.API.Entities;
using RocktseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocktseatAuction.API.Controllers;

public class AuctionController : RocketseatAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var result = useCase.Execute();

        if(result is null)
            return NoContent();

        return Ok(result);
    }
}
