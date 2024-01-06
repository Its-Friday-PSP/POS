using API.Model;

namespace API.Services.Interfaces
{
    public interface IEmployeesService
    {
        public Employee CreateEmployee(Employee employee);
        public Employee GetEmployee(Guid id);
    }
}
