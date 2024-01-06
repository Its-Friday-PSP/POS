using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Employee CreateEmployee(Employee employee);
        public Employee GetEmployee(Guid id);
        public Employee UpdateEmployee(Employee employee);
        public bool DeleteEmployee(Guid id);
    }
}
