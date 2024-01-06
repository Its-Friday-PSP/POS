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

        public AuthService(
            IConfiguration config,
            ICustomerRepository customerRepository)
        {
            _config = config;
            _customerRepository = customerRepository;
        }

        public string? Login(Auth auth)
        {
            var customer = AuthenticateUser(auth);

            var token = customer == null ? null : GenerateToken(customer);
            return token;
        }

        private string GenerateToken(Customer customer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                /*new Claim(ClaimTypes.NameIdentifier, user.Name),*/
                new Claim("Id", customer.Id.ToString())
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

        private Customer? AuthenticateUser(Auth auth)
        {
            var customer = _customerRepository.GetCustomer(auth.Email);
            if (customer?.Auth.Password != auth.Password)
            {
                return null;
            }
                //var buyer = await _buyerRepository.GetBuyerAsync(user => user.UserAuth.Email.ToLower() == userLogin.Email!.ToLower());

            return customer;

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
