using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Storage;
using SocialMedia.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services.Storage
{
    public class Storage
    {
       

        protected async Task<string> FileRenameAsync(string pathName, string fileName)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extension = Path.GetExtension(fileName);
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                DateTime datetimenow = DateTime.UtcNow;
                string datetimeutcnow = datetimenow.ToString("yyyyMMddHHmmss");
                string newFileName = $"{datetimeutcnow}{NameOperation.CharacterRegulatory(oldName)}{extension}";

                if (File.Exists($"{pathName}\\{newFileName}"))
                    return await FileRenameAsync("", newFileName);
                else
                    return newFileName;
            });
            return newFileName;
        }
    }
}
