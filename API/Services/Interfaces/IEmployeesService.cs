using API.Model;

namespace API.Services.Interfaces
{
    public interface IEmployeesService
    {
        public Employee? CreateEmployee(Employee employee);
        public Employee? GetEmployee(Guid id);
        public IEnumerable<Employee> GetAllEmployees();
        public Employee? UpdateEmployee(Employee employee);
        public bool DeleteEmployee(Guid id);
    }
}
