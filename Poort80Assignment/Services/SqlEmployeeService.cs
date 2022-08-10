using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlEmployeeService : ICRUDservice<Employee>
    {
        private Context.AppContext _appContext;

        public SqlEmployeeService(Context.AppContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Employee> All()
        {
            throw new NotImplementedException();
        }

        public Employee Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Find(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
