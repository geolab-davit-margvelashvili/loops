namespace Loops;
class Program
{ 
public static void Main(string[] args)
    {
        // exercise 1
        var employees = new List<Exercise1Employee>();

        while (true)
        {
            Console.WriteLine(" enter your name ");
            string employeeName = Console.ReadLine();
            if (string.IsNullOrEmpty(employeeName))
            {
                break;
            }
            Console.WriteLine(" enter your working days ");
            int employeeWorkingDays = int.Parse(Console.ReadLine());
            Console.WriteLine(" enter your overtime hours ");
            int emplyeeTotalOvertimeHours = int.Parse(Console.ReadLine());

            employees.Add(new Exercise1Employee(employeeName, employeeWorkingDays, emplyeeTotalOvertimeHours));
        }

        foreach (var employee in employees)
        {
            Console.WriteLine(employee.Name);
            employee.EarnedSalary();
        }
        
        //exercise 2

        var products = new List<Exercise2Product>();
        decimal totalCost = 0;

        while (true)
        {
            Console.WriteLine(" enter product name ");
            string name2 = Console.ReadLine();
            if (string.IsNullOrEmpty(name2))
            {
                break;
            }

            Console.WriteLine(" enter product price ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine(" enter product number ");
            int number = int.Parse(Console.ReadLine());
            products.Add(new Exercise2Product(name2, price, number));
        }

        foreach (var product in products)
        {
            Console.WriteLine($" your {product.Name} costed  ");
            Console.WriteLine(product.ProductCost);
            Console.WriteLine();
            totalCost = totalCost + product.ProductCost;
        }

        Console.WriteLine($"total cost of all products is {totalCost} ");

        //exercise 3

        var productCost = new List<Exercise3weeks>();
        decimal totalCost1 = 0;

        while (true)
        {
            Console.WriteLine(" enter product name ");
            string name3 = Console.ReadLine();
            if (string.IsNullOrEmpty(name3))
            {
                break;
            }
            Console.WriteLine("enter product cost from Monday Till Sunday ");
            decimal monday = decimal.Parse(Console.ReadLine());
            decimal tuesday = decimal.Parse(Console.ReadLine());
            decimal wednesday = decimal.Parse(Console.ReadLine());
            decimal thursday = decimal.Parse(Console.ReadLine());
            decimal friday = decimal.Parse(Console.ReadLine());
            decimal saturday = decimal.Parse(Console.ReadLine());


            productCost.Add(new Exercise3weeks(name3, monday, tuesday, wednesday, thursday, friday, saturday));
        }
        foreach (var item in productCost)
        {
            totalCost1 = totalCost1 + item.Sunday;
        }

        var sunday = DayOfWeek.Sunday;
        Console.WriteLine($"total cost calculated in {sunday} is {totalCost1}");


    }


}

class Exercise1Employee
{
    public string Name { get; set; }
    
    public int WorkingDays { get; set; }
    
    public const int WorkingHoursInDay = 8;
    public int WorkingOvertimeHoursInMonth { get;set; }

    public const decimal HourlySalary = 20m;
    public const decimal OvertimeHourlySalary = 25m;

    public Exercise1Employee(string name, int workingDays,int overTimeHoursInMonth)
    {
        Name = name;
        WorkingDays = workingDays;
        WorkingOvertimeHoursInMonth = overTimeHoursInMonth;
    }

    public void EarnedSalary()
    {
        decimal earnedSalary = WorkingDays * (WorkingHoursInDay * HourlySalary) + (WorkingOvertimeHoursInMonth * OvertimeHourlySalary);
        Console.WriteLine($" your earned total salary is : {earnedSalary} Lari ");
        Console.WriteLine();
    }

}

class Exercise2Product
{
    public string Name { get; set; }
    public decimal Price { get; set;}
    public int ProductNumber { get; set;}
    public decimal ProductCost {  get; set;}

    public Exercise2Product(string name, decimal price, int productNumber)
    {
        Name = name;
        Price = price;
        ProductNumber = productNumber;
        ProductCost = price * productNumber;
    }

    
}
class Exercise3weeks
{
    public string Name { get; set; }
    public decimal Monday{ get; set; }
    public decimal Tuesday { get; set; }
    public decimal Wednesday { get; set; }
    public decimal Thursday { get; set; }
    public decimal Friday { get; set; }
    public decimal Saturday { get; set; }
    public decimal Sunday { get; set; }

    public Exercise3weeks(string name,decimal monday, decimal tuesday, decimal wednesday, decimal thursday, decimal fri, decimal sat)
    {
        Monday = monday;
        Tuesday = tuesday;
        Wednesday = wednesday;
        Thursday = thursday;
        Friday = fri;
        Saturday = sat;
        Sunday = monday + tuesday + wednesday + thursday + fri + sat;
    }

   
}


