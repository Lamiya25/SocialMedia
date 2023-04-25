using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathName)>> UploadAsync(string pathName, IFormFileCollection files);
        Task<(string fileName, string pathName)> UploadAsync(string pathName, IFormFile file);
        Task DeleteAsync(string pathName, string fileName);
        List<string> GetFiles(string pathName);
        bool HasFile(string pathName, string fileName);
    }
}