using WarehouseApplication;

internal class Program
{
    private static void Main(string[] args)
    {
        StockManagement stockManagement = new StockManagement();
        Console.WriteLine("***WAREHOUSE APPLICATION***");
        while (true)
        {
            showMenu();
            int.TryParse(Console.ReadLine(), out int option);
            string name = "";
            int type = 0;
            int stock = 0;
            int id = 0;
            switch (option)
            {
                case 1:
                    stockManagement.ListProducts();
                    break;
                case 2:
                    Console.WriteLine("\nPlease insert the name of the product: ");
                    name = Console.ReadLine();
                    stockManagement.SearchProduct(name);
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("\n***SUBMENU***");
                        Console.WriteLine("1. In house");
                        Console.WriteLine("2. 3rd party");
                        Console.WriteLine("Please select the source type: ");
                        int.TryParse(Console.ReadLine(), out type);
                        if (type == 1 || type == 2)
                        {
                            Console.WriteLine("\nPlease insert the name of the product: ");
                            name = Console.ReadLine();
                            Console.WriteLine("\nPlease insert the stock number: ");
                            int.TryParse(Console.ReadLine(), out stock);
                            break;
                        } else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                    stockManagement.AddProduct(0, name, type, stock);
                    Console.WriteLine($"Congratulations! Product {name.ToUpper().Trim()} added successfully.");
                    break;
                case 4:
                    Console.WriteLine("\nPlease insert the product id: ");
                    int.TryParse(Console.ReadLine(), out id);
                    stockManagement.RemoveProduct(id);
                    break;
                case 5:
                    while (true)
                    {
                        Console.WriteLine("\n***SUBMENU***");
                        Console.WriteLine("1. In house");
                        Console.WriteLine("2. 3rd party");
                        Console.WriteLine("Please select the source type: ");
                        int.TryParse(Console.ReadLine(), out type);
                        if (type == 1 || type == 2)
                        {
                            Console.WriteLine("\nPlease insert the name of the product: ");
                            name = Console.ReadLine();
                            Console.WriteLine("\nPlease insert the product id: ");
                            int.TryParse(Console.ReadLine(), out id);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                    stockManagement.EditProduct(id, name, type, stock);
                    break;
                case 6:
                    Console.WriteLine("\nPlease insert the stock number: ");
                    int.TryParse(Console.ReadLine(), out stock);
                    Console.WriteLine("\nPlease insert the product id: ");
                    int.TryParse(Console.ReadLine(), out id);
                    stockManagement.UpdateStock(id, stock);
                    break;
                case 7:
                    Console.WriteLine("Thank you for using the application. Have a good one!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    private static void showMenu()
    {
        Console.WriteLine("\n***MENU***");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. Search Product");
        Console.WriteLine("3. Add Product");
        Console.WriteLine("4. Remove Product");
        Console.WriteLine("5. Edit Product");
        Console.WriteLine("6. Update Stock");
        Console.WriteLine("7. Exit");
        Console.WriteLine("Please select an option: ");
    }
}