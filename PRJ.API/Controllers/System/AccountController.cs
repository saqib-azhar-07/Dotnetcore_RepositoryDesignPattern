using PRJ.Service.Services.System.Login;
using PRJ.Service.Services.System.Login.DTOs;
using PRJ.Service.Services.System.Registeration;
using Serilog.Context;

namespace PRJ.API.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;


        public AccountController(IRegisterService _registerService, ILoginService _loginService)
        {
            this._registerService = _registerService;
            this._loginService = _loginService;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <remarks>
        /// Sample value of message
        /// 
        ///     {
        ///        "FirsName": "Hello",
        ///        "LastName": "hello"
        ///        "Email": "abc@gmail.com"
        ///        "Password": "123"
        ///     }
        ///     
        /// </remarks>

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register(RegisterInputDTO dto) =>
             Ok(await _registerService.Register(dto));


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(LoginInputDTO dto)
        {
            return Ok(await _loginService.Login(dto));
        }
    }
}
