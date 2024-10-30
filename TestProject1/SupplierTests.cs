using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaShop;
using FluentAssertions;

namespace BananaShopTests;

public class SupplierTests
{
    private readonly Supplier _supplier;
    private readonly Store _store;
    public SupplierTests()
    {
        _store = new Store();
        _supplier = new Supplier();
    }

    [Fact]
    public void SupplyBananas_StoreRecievesBananas()
    {
        var beforeAddingBananas = _store.CheckInventory();

        _supplier.SupplyBananas(_store);

        var afterAddingBananas = _store.CheckInventory();

        beforeAddingBananas.Should().Be(9);
        afterAddingBananas.Should().Be(99);
    }
}