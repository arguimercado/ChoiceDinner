using ChoiceDinner.Application.Extensions;
using ChoiceDinner.Domain.Models.Users;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ChoiceDinner.Application.Features.Authentications.Commands;

public static class Register
{
    public record Command(string Email, string Password, string FirstName,string MiddleName, string LastName) : ICommand<Result<Unit>>;

    public class Handler : ICommandHandler<Command, Result<Unit>>
    {
        private readonly UserManager<AppUser> _userManager;

        public Handler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Result.Ok(Unit.Value);
            }

            return Result.Fail("Failed to register user");
        }
    }
}