using System.Web.Http.Description;

namespace PRJ.API.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService _userService) =>
            this._userService = _userService;
        
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save(UserInputDTO dto) =>
             Ok(await _userService.Save(dto,null,null));

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(long userId) =>
            Ok(await _userService.Get(userId , null));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<List<UserOutputDTO>>))]
        [Route("getAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() =>
             Ok(await _userService.GetAll(null , null));

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(long userId) =>
            Ok(await _userService.Delete(userId));


        [HttpPost]
        [Route("save1")]
        public async Task<IActionResult> Save1(int a , int b) =>
            Ok();
    }
}
