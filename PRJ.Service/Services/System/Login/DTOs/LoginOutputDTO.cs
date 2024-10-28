namespace PRJ.Service.Services.System.Login.DTOs;
public class LoginOutputDTO : LoginDTO
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int RoleId { get; set; }
    public string Token { get; set; }
}
