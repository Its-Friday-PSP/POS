using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Employee CreateEmployee(Employee employee);
        public Employee? GetEmployee(Guid id);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee? UpdateEmployee(Employee employee, Guid id);
        public bool DeleteEmployee(Guid id);
    }
}
