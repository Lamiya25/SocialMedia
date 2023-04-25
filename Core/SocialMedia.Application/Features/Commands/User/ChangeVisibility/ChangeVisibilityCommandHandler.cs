using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.ChangeVisibility
{
    public class ChangeVisibilityCommandHandler : IRequestHandler<ChangeVisibilityCommandRequest, ChangeVisibilityCommandResponse>
    {
        private readonly IUserService _userService;
        public ChangeVisibilityCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ChangeVisibilityCommandResponse> Handle(ChangeVisibilityCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.ChangeVisibilityAsync(request.UserId);
        }
    }
}