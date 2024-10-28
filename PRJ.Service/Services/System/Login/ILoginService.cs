namespace PRJ.Service.Services.System.Login;
public interface ILoginService
{
    Task<OutputDTO<LoginOutputDTO>> Login(LoginInputDTO dto);
}
