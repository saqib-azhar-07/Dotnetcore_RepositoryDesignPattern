using PRJ.Service.Services.CommonService;

namespace PRJ.Service.Services.User;
public interface IUserService : ICommonService<UserInputDTO, long, bool, UserOutputDTO>
{
}
