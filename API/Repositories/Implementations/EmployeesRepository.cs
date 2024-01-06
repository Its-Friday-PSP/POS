using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly Context _context;

        public EmployeesRepository(Context context)
        {
            _context = context;
        }

        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee? GetEmployee(Guid id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee? UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Auth = employee.Auth;
            existingEmployee.Role = employee.Role;
            existingEmployee.Name = employee.Name;
            _context.SaveChanges();
            return existingEmployee;
        }

        public bool DeleteEmployee(Guid id)
        {
            return false;
        }
    }
}
