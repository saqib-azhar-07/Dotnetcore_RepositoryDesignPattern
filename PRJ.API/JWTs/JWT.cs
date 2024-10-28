namespace PRJ.API.JWTs;

public static class JWT
{
    public static string GenerateJwtToken(SessionDTO dto)
    {
        string role = dto.Role;

        var claims = new[]
        {
                new Claim(SessionProperty.UserId, Convert.ToString(dto.UserId)),
                new Claim(SessionProperty.Name, dto.Name),
                //new Claim(SessionProperty.RoleId, Convert.ToString(dto.RoleId)),
                new Claim(SessionProperty.Email, dto.Email),
                //new Claim(SessionProperty.Photo, string.IsNullOrEmpty(dto.Photo)?string.Empty: dto.Photo),
                //new Claim(SessionProperty.Timezone, string.IsNullOrEmpty(dto.Timezone)?string.Empty: dto.Timezone),
                //new Claim(ClaimTypes.Role, role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.JWTkey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
