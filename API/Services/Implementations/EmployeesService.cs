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
        public Employee CreateEmployee(Employee employee)
        {
            if (EmailAlreadyRegistered())
            {
                return _employeesRepository.CreateEmployee(employee);
            }
            else
            {
                throw new EmailAlreadyRegisteredException("Employee with this email is already registered");
            }
        }

        public Employee GetEmployee(Guid id)
        {
            return null;
        }
        private bool EmailAlreadyRegistered()
        {
            // kazkokia tikrinimo logika
            return false;
        }
    }
}
