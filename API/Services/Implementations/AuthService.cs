using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public AuthService(
            IConfiguration config,
            ICustomerRepository customerRepository,
            IEmployeesRepository employeesRepository)
        {
            _config = config;
            _customerRepository = customerRepository;
            _employeesRepository = employeesRepository;
        }

        public string? Login(Auth auth)
        {
            var id = AuthenticateUser(auth);
            
            var token = id == null ? null : GenerateToken((Guid)id);
            return token;
        }

        private string GenerateToken(Guid id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                /*new Claim(ClaimTypes.NameIdentifier, user.Name),*/
                new Claim("Id", id.ToString())
                /*new Claim(ClaimTypes.Role, role)*/
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        private Guid? AuthenticateUser(Auth auth)
        {
            var customer = _customerRepository.GetCustomer(auth.Email);
            
            if (customer?.Auth.Password == auth.Password)
            {
                return customer.Id;
            }
            var employee = _employeesRepository.GetEmployee(auth.Email);

            if (employee?.Auth.Password == auth.Password)
            {
                return employee.Id;
            }

           return null;

            /*if (customer != null)
            {
                if (buyer.UserAuth.Password.ToLower() == userLogin.Password!.ToLower())
                    return buyer;
                else
                    throw new InvalidLoginCredentialsException("incorrect password");
            }*/
        }
    }
}
