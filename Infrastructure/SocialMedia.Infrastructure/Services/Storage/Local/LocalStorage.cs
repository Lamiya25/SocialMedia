using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Storage;
using SocialMedia.Application.Abstractions.Storage.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Storage.Local
{
    public class LocalStorage :Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteAsync(string pathName, string fileName)
                    => File.Delete($"{pathName}\\{fileName}");

        public List<string> GetFiles(string pathName)
        {
            DirectoryInfo directory = new(pathName);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string pathName, string fileName)
            => File.Exists($"{pathName}\\{fileName}");

        public async Task<List<(string fileName, string pathName)>> UploadAsync(string pathName, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> values = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(pathName, file.FileName);
                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                values.Add((fileNewName, $"{pathName}\\{fileNewName}"));
            }
            return values;
        }

        public async Task<(string fileName, string pathName)> UploadAsync(string pathName, IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            (string fileName, string path) values = new();

            string fileNewName = await FileRenameAsync(pathName, file.FileName);
            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            values.fileName = fileNewName;
            values.path = $"{pathName}\\{fileNewName}";
            return values;
        }

        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
    }
}