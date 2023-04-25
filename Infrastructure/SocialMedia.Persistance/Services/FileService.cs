using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.Storage;
using SocialMedia.Application.Consts;
using SocialMedia.Application.Repositories.PostImages;
using SocialMedia.Application.Repositories.PostReactions;
using SocialMedia.Application.Repositories.ProfileImages;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Services
{
    public class FileService : IFileService
    {

        private readonly IPostImageWriteRepository _postImageWrite;
        private readonly IStorageService _storageService;
        private readonly IPostReadRepository _postReadRepo;
        private readonly IProfileImageWriteRepository _profileImageWrite;
        public FileService(IPostImageWriteRepository postImageWrite, IStorageService storageService, IPostReadRepository postReadRepo, IProfileImageWriteRepository profileImageWrite)
        {
            _postImageWrite = postImageWrite;
            _storageService = storageService;
            _postReadRepo = postReadRepo;
            _profileImageWrite = profileImageWrite;
        }

        public async Task DeletePostImageAsync(string postImageId)
        {
            await _postImageWrite.RemoveAsync(postImageId);
            await _postImageWrite.SaveAsync();
        }
        public async Task<List<PostImage>> WritePostImagesAsync(string postId, IFormFileCollection files)
        {
            string pathName = UploadPaths.PostImagePathName;
            var storageInfo = await _storageService.UploadAsync(pathName, files);
            List<PostImage> postImages = new();

            foreach (var item in storageInfo)
            {
                PostImage postImage = await _postImageWrite.AddEntityAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    FileName = item.fileName,
                    Path = item.pathName,
                    Storage = _storageService.StorageName,
                    PostId = postId
                });
                postImages.Add(postImage);
            }
            await _postImageWrite.SaveAsync();

            return postImages;
        }

        public async Task<ProfileImage> WriteProfileImageAsync(IFormFile file)
        {
            string pathName = UploadPaths.ProfileImagePathName;
            var storageInfo = await _storageService.UploadAsync(pathName, file);

            ProfileImage profileImage = await _profileImageWrite.AddEntityAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FileName = storageInfo.fileName,
                Path = storageInfo.pathName,
                Storage = _storageService.StorageName,
            });
            await _profileImageWrite.SaveAsync();
            return profileImage;
        }
    }
}