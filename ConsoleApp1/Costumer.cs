namespace BananaShop;

public class Costumer
{
    public int RequestBananas(int count)
    {
        Console.WriteLine("Costumer wants to buy "+count+" bananas");
        return count;
    }
}