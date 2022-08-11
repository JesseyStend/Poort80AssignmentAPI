using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlEmployeeService : ICRUDservice<Employee>
    {
        private Context.AppContext _appContext;

        public SqlEmployeeService(AppContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Employee> All()
        {
            return _appContext.employees.ToList();
        }

        public Employee Create(Employee entity)
        {
            entity.Id = _appContext.employees.Last().Id + 1;
            _appContext.employees.Add(entity);
            _appContext.SaveChanges();
            return entity;
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

        public Employee? Update(Employee entity)
        {
            _appContext.employees.Update(entity);
            _appContext.SaveChanges();
            return _appContext.employees.Find(entity.Id);
        }
    }
}
