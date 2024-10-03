Console.WriteLine("Tell me you employee data and i will tell you things");



List<Employee> EmployeeData = new List<Employee>();


string MoreEmployees = "";
string MoreWorkedDays = "";

decimal TotalSalary = 0;


do
{
    var employee = new Employee();

    int WorkedDays = 1;

    Console.WriteLine("Tell me employee name");
    employee.EmployeeName = Console.ReadLine();

    Console.WriteLine("Tell me employee hourly salary");
    employee.EmployeeSalary = decimal.Parse(Console.ReadLine());


    do
    {



        Console.WriteLine($"Tell me workers day {WorkedDays} worked hours");
        int WorkedHours = int.Parse(Console.ReadLine());

        if (WorkedHours > 8)
        {
            int ExtraHours = 0;

            ExtraHours = WorkedHours - 8;

            TotalSalary = (8 * employee.EmployeeSalary) + (ExtraHours * (employee.EmployeeSalary * 1.25m));

        }

        else
        {

            TotalSalary = WorkedHours * employee.EmployeeSalary;

        }

        if (WorkedHours > 8)
        {
            employee.WorkedOverTime = true;
        }

        employee.OwedMoney = employee.OwedMoney + TotalSalary;

        WorkedDays ++;

        Console.WriteLine("Enter y if there are more worked days for this employee");
        MoreWorkedDays = Console.ReadLine();

    }
    while (MoreWorkedDays == "y");

    EmployeeData.Add(employee);

    Console.WriteLine("Enter y if there are more employees");
    MoreEmployees = Console.ReadLine();

} 

while (MoreEmployees == "y");




for (int i = 0; i < EmployeeData.Count; i++)
{
    var WriteData = EmployeeData[i];


    Console.WriteLine("Here is employee name and how much you owe them");
    Console.WriteLine(WriteData.EmployeeName);
    Console.WriteLine(WriteData.OwedMoney);
}

for (int i = 0; i < EmployeeData.Count; i++)
{

    if (EmployeeData[i].WorkedOverTime == true)
    {
        Console.WriteLine("Here are employees who worked overtime and how much you owe them");
        Console.WriteLine(EmployeeData[i].EmployeeName);
        Console.WriteLine(EmployeeData[i].OwedMoney);
    }

}


class Employee
{

    public string EmployeeName { get; set; }
    public decimal EmployeeSalary { get; set; }
    public decimal OwedMoney { get; set; }
    public bool WorkedOverTime { get; set; }

}
