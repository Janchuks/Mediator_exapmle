using BananaShop;
using System.Reflection;


namespace BananaShopTests;

public class Program_FullIntegration_Tests
{
    private readonly StoreMediator _storeMediator;
    private readonly Store _store;
    private readonly Supplier _supplier;

    public Program_FullIntegration_Tests(){

        _store = new Store();
        _supplier = new Supplier();

        _storeMediator = new StoreMediator();

        var storeField = typeof(StoreMediator).GetField("_store", BindingFlags.NonPublic | BindingFlags.Instance);
        storeField.SetValue(_storeMediator, _store);

        var supplierField = typeof(StoreMediator).GetField("_supplier", BindingFlags.NonPublic | BindingFlags.Instance);
        supplierField.SetValue(_storeMediator, _supplier);
    }
    [Fact]
    public void Main_ProcessesOrder()
    {
        var input = new StringReader("5\n"); 
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        BananaShop.Program.Main(new string[0]); 
           
        //so here we have simulated the user input that is true
        // Main method has called storeMediator
        // since Place order is a void method, we can check the string
        // by checking the string inside the StoreMediator we can assure that its called

        Assert.Contains("Bananas remaining in store after sale", output.ToString());
    }

    [Fact]
    public void Main_DoesntProcessOrder()
    {
        var input = new StringReader("-1\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        BananaShop.Program.Main(new string[0]);

        Assert.Contains("Please enter a valid number.", output.ToString());
    }
}