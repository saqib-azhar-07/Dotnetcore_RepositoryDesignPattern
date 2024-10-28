namespace PRJ.Service.Services.System.Registeration;

public class RegisterService : IRegisterService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;   
    public RegisterService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<OutputDTO<bool>> Register(RegisterInputDTO dto)
    {
        var rec = await _unitOfWork.UserRepo.Get(x => x.Email.Equals(dto.Email));
        if(rec is null)
        {
            var mapper = _mapper.Map<SYS_User>(dto);
            mapper.Password = Security.Encrypt(dto.Password);
            mapper.CreatedDate = DateTime.UtcNow;
            await _unitOfWork.UserRepo.Add(mapper);
            await _unitOfWork.Save();

            return Output.Handler((int) ResponseCode.SUCCESSFULLY_REGISTER, true);
        }
        return Output.Handler((int) ResponseCode.EMAIL_EXIST, false);
    }
}
