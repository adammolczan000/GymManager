namespace GymManager.API.DTOs; // namespace

// DTO = obiekt do przesyłania danych z frontend → backend
public class RegisterDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}