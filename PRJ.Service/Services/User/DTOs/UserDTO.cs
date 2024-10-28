namespace PRJ.Service.Services.User.DTOs;
public class UserDTO
{
    public long UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int GenderId { get; set; }
    public DateTime DOB { get; set; } 

}
