using SocialMedia.Application.Repositories.ProfileImages;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories.ProfileImages
{
    public class ProfileImageWriteRepository : WriteRepository<ProfileImage>, IProfileImageWriteRepository
    {
        public ProfileImageWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}