using System.Reflection;
using BananaShop;
using FluentAssertions;

namespace BananaShopTests;

public class StoreMediatorTests
{
    private readonly Store _store;
    private readonly Supplier _supplier;

    private readonly StoreMediator _storeMediator;

    public StoreMediatorTests()
    {
        _store = new Store();
        _supplier = new Supplier();

        _storeMediator = new StoreMediator();

        //these are reflections because StoreMediator has private fields that need to be accessed
        var storeField = typeof(StoreMediator).GetField("_store", BindingFlags.NonPublic | BindingFlags.Instance);
        storeField.SetValue(_storeMediator, _store);

        var supplierField = typeof(StoreMediator).GetField("_supplier", BindingFlags.NonPublic | BindingFlags.Instance);
        supplierField.SetValue(_storeMediator, _supplier);
    }

    [Fact]
    public void ProcessOrder_RestockIsNotRequested()
    {
        _storeMediator.ProcessOrder(1);

        _storeMediator.restockRequested.Should().BeFalse();
    }

    [Fact]
    public void ProcessOrder_RestockIsRequested_BananasInStoreAreLessThanRequested()
    {
        _storeMediator.ProcessOrder(20);

        _storeMediator.restockRequested.Should().BeTrue();
    }

    [Fact]
    public void ProcessOrder_RestockIsRequested_BananasInStoreAre0()
    {
        _storeMediator.ProcessOrder(9);

        _storeMediator.restockRequested.Should().BeTrue();
    }

    //Mediator communicates with store
    [Fact]
    public void ProcessOrder_StoreHasLessBananas()
    {
        var bananasBeforeOrder = _store.CheckInventory();
        _storeMediator.ProcessOrder(1);

        var bananasAfterOrder = _store.CheckInventory();

        bananasBeforeOrder.Should().Be(9);
        bananasAfterOrder.Should().Be(8);

    }

    [Fact]
    public void ProcessOrder_BananasHaveBeenRestocked_storeHad0()
    {
        _storeMediator.ProcessOrder(9);
        var restock = _storeMediator.restockRequested;

        var bananasAfterOrder = _store.CheckInventory();

        bananasAfterOrder.Should().Be(90);
        restock.Should().BeTrue();
    }

    [Fact]
    public void ProcessOrder_BananasHaveBeenRestocked_storeHadLessThanRequested()
    {
        _storeMediator.ProcessOrder(20);
        var restock = _storeMediator.restockRequested;

        var bananasAfterOrder = _store.CheckInventory();

        bananasAfterOrder.Should().Be(99-20);
        restock.Should().BeTrue();
    }

    //supplier is contacted
    [Fact]
    public void ProcessOrder_CallsSupplierWhenBananasAreMissing()
    {
        _storeMediator.ProcessOrder(20);
        _supplier.isContacted.Should().BeTrue();
    }

    [Fact]
    public void ProcessOrder_CallsSupplierWhenBananasAre0()
    {
        _storeMediator.ProcessOrder(9);
        _supplier.isContacted.Should().BeTrue();
    }

    [Fact]
    public void ProcessOrder_SupplierIsNotCalled()
    {
        _storeMediator.ProcessOrder(1);
        _supplier.isContacted.Should().BeFalse();
    }
}