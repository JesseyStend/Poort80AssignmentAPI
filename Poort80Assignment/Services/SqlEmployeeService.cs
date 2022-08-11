using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlEmployeeService : ICRUDservice<Employee, EmployeeIn>
    {
        private Context.ApiContext _appContext;

        public SqlEmployeeService(Context.ApiContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Employee> All()
        {
            return _appContext.employees.ToList();
        }

        public Employee Create(EmployeeIn entity)
        {
            Employee employee = new()
            {
                Name = entity.Name,
                DepartmentId = (int)(entity.DepartmentId != null? entity.DepartmentId : 1)
            };
            _appContext.employees.Add(employee);
            _appContext.SaveChanges();
            return employee;
        }

        public void Delete(Employee entity)
        {
            _appContext.employees.Remove(entity);
            _appContext.SaveChanges();
        }

        public Employee? Find(int id)
        {
            return _appContext.employees.Find(id);
        }

        public Employee? Update(EmployeeIn change, Employee current)
        {
            Type t = typeof(Employee);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(change, null);
                if (value != null)
                    prop.SetValue(current, value, null);
            }

            _appContext.employees.Update(current);
            _appContext.SaveChanges();
            return current;
        }
    }
}
