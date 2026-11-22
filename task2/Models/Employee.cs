
namespace EmployeeApp.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }

        public Employee(string name, double salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }
    }
}
