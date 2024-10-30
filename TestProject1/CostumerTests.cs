using BananaShop;
using FluentAssertions;

namespace BananaShopTests;

public class CostumerTests
{
    private readonly Costumer _costumer;
    public CostumerTests()
    {
        _costumer = new Costumer();
    }
    [Fact]
    public void RequestBananas_ReturnsIntOfRequestedBananas()
    {
        var result = _costumer.RequestBananas(10);
        result.Should().Be(10);
    }
}