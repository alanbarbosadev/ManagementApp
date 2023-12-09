namespace ManagementApp.Api.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
    }
}
