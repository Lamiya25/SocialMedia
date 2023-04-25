using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.Edit
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommandRequest, EditUserCommandResponse>
    {
        private readonly IUserService _userService;
        public EditUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<EditUserCommandResponse> Handle(EditUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.EditUserAsync(request.EditUserDto);
        }
    }
}
