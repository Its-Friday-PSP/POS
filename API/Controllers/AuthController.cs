using API.Model;
using API.Requests.Auth;
using API.Responses.Auth;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            var auth = _mapper.Map<Auth>(request.Auth);
            var token = _authService.Login(auth);
            return token == null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(new LoginResponse(token));
        }
    }
}
