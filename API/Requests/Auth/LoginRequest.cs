using API.DTOs;
using API.Model;

namespace API.Requests.Auth
{
    public class LoginRequest
    {
        public AuthDTO Auth { get; set; }
    }
}
