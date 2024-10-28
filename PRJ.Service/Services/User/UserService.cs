using Serilog.Context;

namespace PRJ.Service.Services.User;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
  
    public UserService(IMapper _mapper, IUnitOfWork _unitOfWork)
    {
        this._mapper = _mapper;
        this._unitOfWork = _unitOfWork;
    }
   
    public async Task<OutputDTO<bool>> Delete(long id)
    {
        var userObj = await _unitOfWork.UserRepo.Get(x => x.UserId.Equals(id));
        userObj.IsArchived = true;
        _unitOfWork.UserRepo.Update(userObj);
        await _unitOfWork.Save();

        return Output.Handler<bool>((int) ResponseCode.USER_DELETE, true);
    }
    public async Task<OutputDTO<UserOutputDTO>> Get(long id, int? roleId)
    {
        var userObj = await _unitOfWork.UserRepo.Get(x => x.UserId.Equals(id) && x.IsArchived.Equals(false));
        if (userObj is null)
            return Output.Handler<UserOutputDTO>((int) ResponseCode.USER_NOT_FOUND, null);

        var mapped = _mapper.Map<UserOutputDTO>(userObj);
        return Output.Handler<UserOutputDTO>((int) ResponseCode.GET_USER, mapped);
    }
    public async Task<OutputDTO<List<UserOutputDTO>>> GetAll(long? userId, int? roleId)
    {
        var userObj = await _unitOfWork.UserRepo.GetAll(x => x.IsArchived.Equals(false));
        if (userObj is null || userObj.Count == 0)
            return Output.Handler<List<UserOutputDTO>>((int) ResponseCode.USER_NOT_FOUND, null!);

        var mapped = _mapper.Map<List<UserOutputDTO>>(userObj);
        return Output.Handler((int) ResponseCode.GET_USER, mapped);
    }
    public async Task<OutputDTO<UserOutputDTO>> Save(UserInputDTO? obj, long? userId, int? roleId)
    {
        LogContext.PushProperty("xyz", 9999999);
        Serilog.Log.Information("a");
        var userObj = await _unitOfWork.UserRepo.Get(x => x.Email.Equals(obj.Email) && x.IsArchived.Equals(false));
        if (userObj is null || userObj.UserId == obj.UserId)
        {
            if (obj.UserId == 0)
            {
                var mapper = _mapper.Map<UserInputDTO, SYS_User>(obj);
                mapper.CreatedDate = DateTime.Now;
                await _unitOfWork.UserRepo.Add(mapper);
                await _unitOfWork.Save();

                var mapped = _mapper.Map<UserOutputDTO>(mapper);
                return Output.Handler((int) ResponseCode.USER_CREATE, mapped);

            }
            else
            {

                var newUserObj = await _unitOfWork.UserRepo.Get(x => x.UserId.Equals(obj.UserId) && x.IsArchived.Equals(false));
               
                _unitOfWork.UserRepo.Update(newUserObj);
                await _unitOfWork.Save();
                newUserObj.FirstName = obj.FirstName;
                newUserObj.LastName = obj.LastName;
                newUserObj.GenderId = obj.GenderId;
                newUserObj.DOB = obj.DOB;
                newUserObj.ModifiedDate = DateTime.Now;

                _unitOfWork.UserRepo.Update(newUserObj);
                await _unitOfWork.Save();
                var mapped = _mapper.Map<UserOutputDTO>(newUserObj);

                return Output.Handler<UserOutputDTO>((int)ResponseCode.USER_UPDATE, mapped);

            }
        }
        return Output.Handler<UserOutputDTO>((int)ResponseCode.USER_EXIST, null);
    }

}
