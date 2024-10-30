using System;

namespace BananaShop;

public class StoreMediator
{
    private readonly Store _store;
    private readonly Costumer _customer;
    private readonly Supplier _supplier;
    public bool restockRequested = false;

    public StoreMediator()
    {
        _store = new Store();
        _customer = new Costumer();
        _supplier = new Supplier();
    }

    public void ProcessOrder(int count)
    {
        int availableBananas = _store.CheckInventory();
        int requestedBananas = _customer.RequestBananas(count);

        if (requestedBananas > availableBananas)
        {
            Console.WriteLine("Not enough bananas in stock. Requesting more from the supplier...");
            _supplier.SupplyBananas(_store);
            restockRequested = true;
        }
        else if (availableBananas == 0 || (availableBananas - requestedBananas) == 0)
        {
            Console.WriteLine("Store has ran out of bananas, contacting the supplier!");
            _supplier.SupplyBananas(_store);
            restockRequested = true;
        }

        _store.SellBananas(requestedBananas);
        Console.WriteLine(requestedBananas + " Bananas have been sold to the costumer!");

        Console.WriteLine("Bananas remaining in store after sale: " + _store.CheckInventory());
    }
}