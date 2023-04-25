using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.User.GetOne
{
    public class GetOneUserQueryHandler : IRequestHandler<GetOneUserQueryRequest, GetOneUserQueryResponse>
    {
        private readonly IUserService _userService;
        public GetOneUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetOneUserQueryResponse> Handle(GetOneUserQueryRequest request, CancellationToken cancellationToken)
        {
            return await _userService.GetOneUserAsync(x => x.Id == request.UserId);
        }
    }
}