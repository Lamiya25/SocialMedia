using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        Task<DTOs.Token> CreateTokenAsync(User user);
        string CreateRefreshToken();
    }
}
