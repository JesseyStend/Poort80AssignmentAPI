using Poort80Assignment.Models;

namespace Poort80Assignment.Interfaces
{
    public interface IEployeeData
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        void DeleteEmplyee(Employee employeed);
        Employee EditEmployee(Employee employee);
    }
}
