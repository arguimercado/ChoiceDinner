using ChoiceDinner.Application.Extensions;
using ChoiceDinner.Application.Features.Authentications.Dto;
using ChoiceDinner.Domain.Models.Users;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace ChoiceDinner.Application.Features.Authentications.Queries;

public static class Login
{
    public record Query(string Email,string Password) : IQuery<Result<UserResponse>>;

    public class Handler : IQueryHandler<Query,Result<UserResponse>> {
        private readonly UserManager<AppUser> _userManager;
       

        public Handler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
           
        }

        public async Task<Result<UserResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if(user == null) 
                return Result.Fail("Incorrect email or password");
            
            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if(result) {
                return Result.Ok(new UserResponse
                {
                    Email = user.Email!,
                    Token = "token here",
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });
            }

            return Result.Fail("Incorrect email or password");
        }
    }
}
