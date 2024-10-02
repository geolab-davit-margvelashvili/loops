namespace Loops;

// *****************************
// * მომხმარებლის კალათის ჯამი *
// *****************************
//
// პროგრამა მომხმარებელს სთხოვს შეიყვანოს პროდუქტების დასახელება და ფასი.
// ყველა შეყვანის შემდეგ პროგრამა მომხმარებელს ეკითხება სურს თუ არა გაგრძელება.
// თუ მომხმარებელი შეიყვანს “yes” ან “y” პროგრამა გრძელდება და ითხოვოს მომდევნო პროდუქტის დასახელებისა და ფასის შეყვანას.
// ბოლოს პროგრამა უნდა ბეჭდავს:
//      * შეყვანილი პროდუქტების საერთო ღირებულებას
//      * ყველაზე იაფიანი პროდუქტის დასახელებასა და ფასს
//      * ყველაზე ძვირიანი პროდუქტის დასახელებასა და ფასს

public class Program
{
    public static void Main()
    {
        var products = GetProductListFromConsole();

        var totalPrice = CalculateTotalPrice(products);
        Console.WriteLine($"Total price is: {totalPrice}");

        var cheapestProduct = FindCheapestProduct(products);
        Console.WriteLine($"Cheapest product is: {cheapestProduct.Name} --- {cheapestProduct.Price}");

        var mostExpensiveProduct = FindTheMostExpensiveProduct(products);
        Console.WriteLine($"Most expensive product is: {mostExpensiveProduct.Name} --- {mostExpensiveProduct.Price}");
    }

    /// <summary>
    /// პოულობს ყველაზე იაფ პროდუქტს
    /// </summary>
    private static Product FindCheapestProduct(List<Product> products)
    {
        // დავუშვათ რომ პირველივე პროდუქტი არის ყველაზე დაბალ ფასიანი
        Product cheapestProduct = products[0];

        // ავიღოთ თითოეული პროდუქტი პროდუქტების სიიდან.
        // ათვლას ვიწყებთ მეორე პროდუქტიდან
        for (int i = 1; i < products.Count; i++)
        {
            Product currentProduct = products[i];

            // მიმდინარე პროდუქტის ფასს ვადარებთ ყველაზე დაბალ ფასიან პროდუქტს
            if (currentProduct.Price < cheapestProduct.Price)
            {
                // თუ მიმდინარე პროდუქტის ფასი უფრო ნაკლებია ვიდრე ყველაზე დაბალ ფასიანი პროდუქტსი
                // ეს იმას ნიშნავს რომ უფრო დაბალ ფასიანი პროდუქტი გვიპოვნია, ამიტომ
                // ყველაზე დაბალ ფასიანი პროდუქტად ავირჩიოთ მიმდინარე პროდუქტი
                cheapestProduct = currentProduct;
            }
        }
        // ციკლის დასრულების შემდეგ cheapestProduct ობიექტი აღმოჩნდება ყველაზე დაბალფასიანი პროდუქტი
        return cheapestProduct;
    }

    /// <summary>
    /// პოულობს ყველაზე იაფ პროდუქტს
    /// </summary>
    private static Product FindTheMostExpensiveProduct(List<Product> products)
    {
        Product mostExpensiveProduct = products[0];

        for (int i = 1; i < products.Count; i++)
        {
            Product currentProduct = products[i];
            if (currentProduct.Price > mostExpensiveProduct.Price)
            {
                mostExpensiveProduct = currentProduct;
            }
        }

        return mostExpensiveProduct;
    }

    private static decimal CalculateTotalPrice(List<Product> products)
    {
        var totalPrice = 0m;
        for (int i = 0; i < products.Count; i++)
        {
            var product = products[i];
            totalPrice += product.Price;
        }

        return totalPrice;
    }

    private static List<Product> GetProductListFromConsole()
    {
        var products = new List<Product>();
        string retryCommand;
        do
        {
            var product = CreateProduct();
            products.Add(product);

            // \n სიმბოლო გამოიყენება ტექსტის ახალი ხაზზე გადასატანად
            Console.Write("\nEnter 'yes' or 'y' to continue: ");
            retryCommand = Console.ReadLine();

            // new string('-', 30) მოგვცემს ტექსტს რომელიც შევსებული იქნება 30 ცალი '-' სიმბოლოთი
            Console.WriteLine(new string('-', 30));
        } while (retryCommand == "yes" || retryCommand == "y");

        return products;
    }

    private static Product CreateProduct()
    {
        var product = new Product();
        product.Name = GetProductNameFromConsole();
        product.Price = GetProductPriceFromConsole();

        return product;
    }

    /// <summary>
    /// აბრუნებს პროდუქტის ფასს რომელიც უნდა იყოს არაუარყოფითი რიცხვი
    /// </summary>
    private static decimal GetProductPriceFromConsole()
    {
        Console.Write("Enter Product price: ");
        var price = decimal.Parse(Console.ReadLine());

        // შევამოწმოთ შემოყვანილი ფასი უარყოფითი ხომ არ არის
        if (price < 0)
        {
            // თუ ფასი უარყოფითია მაშინ დავაფიქსიროთ გამონაკლისი შემთხვევა (დავარყათ შეცდომა)
            throw new Exception("price must be non negative number");
        }

        return price;
    }

    private static string GetProductNameFromConsole()
    {
        Console.Write("Enter Product Name: ");
        return Console.ReadLine();
    }
}