namespace PRJ.Utility.DTOs;
public class SessionDTO
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
    public string? Timezone { get; set; }
}
