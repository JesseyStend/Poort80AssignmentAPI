using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

namespace Poort80Assignment.Service
{
    public class SqlDepartmentService : ICRUDservice<Department, DepartmentIn>
    {
        private Context.ApiContext _appContext;

        public SqlDepartmentService(Context.ApiContext employeeContext)
        {
            _appContext = employeeContext;
        }

        public List<Department> All()
        {
            return _appContext.departments.ToList();
        }

        public Department Create(DepartmentIn entity)
        {
            Department department = new()
            {
                Description = entity.Description,
                Name = entity.Name,
            };
       
            _appContext.departments.Add(department);
            _appContext.SaveChanges();
            return department;
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

        public Department? Update(DepartmentIn change, Department current)
        {
            Type t = typeof(DepartmentIn);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(change, null);
                if (value != null)
                    prop.SetValue(current, value, null);
            }

            _appContext.departments.Update(current);
            _appContext.SaveChanges();
            return _appContext.departments.Find(current.Id);
        }
    }
}
