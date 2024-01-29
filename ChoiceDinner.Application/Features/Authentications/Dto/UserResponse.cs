namespace ChoiceDinner.Application.Features.Authentications.Dto;

public class UserResponse
{
    public required string Email { get; set; } 
    public required string Token { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }    
}