namespace Poort80Assignment.Models
{
    public class EmployeeWithDepartment : Employee
    {
        public DepartmentSimple? Department { get; set; }
    }
}
