using BananaShop;
using FluentAssertions;

namespace BananaShopTests;

public class StoreTests
{
    private readonly Store _store;
    public StoreTests()
    {
        _store = new Store();
    }
    [Fact]
    public void CheckInventory_returnsInt()
    {
        var bananaCount = _store.CheckInventory();

        bananaCount.Should().Be(9);
    }

    [Fact]
    public void SellBananas_subtractsFromBananaCount()
    {
        _store.SellBananas(1);

        _store.CheckInventory().Should().Be(8);
    }

    [Fact]
    public void RecieveBananas_AddsToBananaCount()
    {
        _store.ReceiveBananas(90);

        _store.CheckInventory().Should().Be(99);
    }
}