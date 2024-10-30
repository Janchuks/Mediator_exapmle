namespace BananaShop;

public class Program
{
    public static void Main(string[] args)
    {
        var storeMediator = new StoreMediator();
        Console.WriteLine("Hello dear customer, welcome to the Banana Store!");
        Console.WriteLine("Enter how many bananas you would like:");
        var count = int.Parse(Console.ReadLine());

        if (count >= 0)
        {
            storeMediator.ProcessOrder(count);
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
}