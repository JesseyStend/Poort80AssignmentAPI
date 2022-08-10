using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlDepartmentService : ICRUDservice<Department>
    {
        private Context.AppContext _appContext;

        public SqlDepartmentService(Context.AppContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Department> All()
        {
            throw new NotImplementedException();
        }

        public Department Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public Department Find(int id)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
