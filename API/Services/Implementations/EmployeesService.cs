using API.Exceptions;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        public Employee? CreateEmployee(Employee employee)
        {
            if (EmailAlreadyRegistered())
            {
                return null;
            }
            else
            {
                return _employeesRepository.CreateEmployee(employee);
            }
        }

        public Employee? GetEmployee(Guid id)
        {
            return _employeesRepository.GetEmployee(id);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeesRepository.GetAllEmployees();
        }

        public Employee? UpdateEmployee(Employee employee, Guid id)
        {
            return _employeesRepository.UpdateEmployee(employee, id);
        }

        public bool DeleteEmployee(Guid id)
        {
            return _employeesRepository.DeleteEmployee(id);
        }

        private bool EmailAlreadyRegistered()
        {
            return false;
        }
    }
}
