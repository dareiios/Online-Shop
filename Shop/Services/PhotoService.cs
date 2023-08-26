using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Shop.Helpers;
using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class PhotoService : IPhotoService
    {

        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> cloudinary)
        {
            var account = new Account(cloudinary.Value.CloudName, cloudinary.Value.ApiKey, cloudinary.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);//для создания нужен аккаунт
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var param = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(param);//удаляет файл из cloudinary, принимает delitionParams
        }
    }
}
