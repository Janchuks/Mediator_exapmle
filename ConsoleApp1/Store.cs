namespace BananaShop;

public class Store
{
    private int _bananaCount = 9;

    public int CheckInventory()
    {
        return _bananaCount;
    }

    public void SellBananas(int count)
    {
        _bananaCount -= count;
        Console.WriteLine("Current banana count in store "+_bananaCount);
    }

    public void ReceiveBananas(int count)
    {
        _bananaCount += count;
        Console.WriteLine("Truck reached the store, bananas are restocked!");
    }
}