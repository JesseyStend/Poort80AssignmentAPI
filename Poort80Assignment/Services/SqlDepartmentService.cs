using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlDepartmentService : ICRUDservice<Department>
    {
        private Context.AppContext _appContext;

        public SqlDepartmentService(AppContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Department> All()
        {
            return _appContext.departments.ToList();
        }

        public Department Create(Department entity)
        {
            entity.Id = _appContext.departments.Last().Id + 1;
            _appContext.departments.Add(entity);
            _appContext.SaveChanges();
            return entity;
        }

        public void Delete(Department entity)
        {
            _appContext.departments.Remove(entity);
            _appContext.SaveChanges();
        }

        public Department? Find(int id)
        {
            return _appContext.departments.Find(id);
        }

        public Department? Update(Department entity)
        {
            _appContext.departments.Update(entity);
            _appContext.SaveChanges();
            return _appContext.departments.Find(entity.Id);
        }
    }
}
