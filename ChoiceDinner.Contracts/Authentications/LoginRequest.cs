namespace ChoiceDinner.Contracts.Authentications;

public record LoginRequest(
    string Email,
    string Password);