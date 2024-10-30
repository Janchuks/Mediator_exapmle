namespace BananaShop;

public class Supplier
{
    private int _bananasInPackages = 90;
    public bool isContacted { get; set; }
    public void SupplyBananas(Store store)
    {
        Console.WriteLine("Supplier reached.. sending the truck");
        store.ReceiveBananas(_bananasInPackages);
        isContacted = true;
    }
        
}