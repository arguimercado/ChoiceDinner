namespace ChoiceDinner.Contracts.Authentications;

public record RegisterRequest(
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Password);
