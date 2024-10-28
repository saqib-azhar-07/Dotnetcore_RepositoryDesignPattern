namespace PRJ.Service.Services.System.Login;

public class LoginService : ILoginService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;   
    public LoginService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<OutputDTO<LoginOutputDTO>> Login(LoginInputDTO dto)
    {
        var rec = await _unitOfWork.UserRepo.Get(x => x.Email.Equals(dto.Email));
        var password = Security.Encrypt(dto.Password);
        if(rec is null || !(rec.Password.Equals(password)))
            return Output.Handler<LoginOutputDTO>((int) ResponseCode.INVALID_CREDENTIALS, null);

        var mapper = _mapper.Map<LoginOutputDTO>(rec);

        return Output.Handler((int) ResponseCode.SUCCESSFULLY_LOGIN, mapper);

    }
}
