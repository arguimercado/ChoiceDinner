namespace ChoiceDinner.Contracts.Authentications;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Token);
