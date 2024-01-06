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

        public Employee GetEmployee(Guid id)
        {
            return null;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return null;
        }

        public bool DeleteEmployee(Guid id)
        {
            return false;
        }
    }
}
