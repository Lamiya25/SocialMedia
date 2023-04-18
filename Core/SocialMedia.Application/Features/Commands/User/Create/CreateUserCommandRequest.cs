using MediatR;
using SocialMedia.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.Create
{
    public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
    {
       public CreateUserDto CreateUser { get; set; }    
    }
}
