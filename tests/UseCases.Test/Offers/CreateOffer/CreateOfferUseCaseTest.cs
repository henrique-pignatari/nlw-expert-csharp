using Bogus;
using FluentAssertions;
using Moq;
using RocktseatAuction.API.Communication.Requests;
using RocktseatAuction.API.Contracts;
using RocktseatAuction.API.Entities;
using RocktseatAuction.API.Services;
using RocktseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700))
            .Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggeduser>();

        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(0, request);

        act.Should().NotThrow();
    }
}
