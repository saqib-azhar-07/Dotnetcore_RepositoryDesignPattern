namespace PRJ.Service.Services.System.Registeration;
public interface IRegisterService
{
    Task<OutputDTO<bool>> Register(RegisterInputDTO dto);
}
