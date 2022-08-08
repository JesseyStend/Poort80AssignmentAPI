using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.MockData
{
    public class MockEmployeeData : IEployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee(){ Id = Guid.NewGuid(), Name = "Jessey Stend"},
            new Employee(){ Id = Guid.NewGuid(), Name = "Frank Mürhen"},
            new Employee(){ Id = Guid.NewGuid(), Name = "Dennis Jongbloed"}
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmplyee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee change)
        {
            Employee employee = GetEmployee(change.Id);
            employee.Name = change.Name;
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(search => search.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
