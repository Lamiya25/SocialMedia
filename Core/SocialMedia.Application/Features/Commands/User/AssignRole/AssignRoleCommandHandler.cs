using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, AssignRoleCommandResponse>
    {
        private readonly IUserService _userService;
        public AssignRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            bool res = await _userService.AssignRoleAsync(request.UserId, request.RoleType);
            return new() { Succeeded = res };
        }
    }
}