using SocialMedia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
}
