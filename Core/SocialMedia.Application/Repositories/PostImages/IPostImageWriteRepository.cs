using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Repositories.PostImages
{
    public interface IPostImageWriteRepository : IWriteRepository<PostImage>
    {
    }
}