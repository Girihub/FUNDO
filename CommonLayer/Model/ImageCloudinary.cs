using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class ImageCloudinary
    {
        private readonly IConfiguration configuration;

        public ImageCloudinary(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        //public Cloudinary cloudinary;        

        public string UploadImage(IFormFile formFile)
        {
            try
            {
                var cloudeName = configuration["Cloudinary:CloudName"];
                var keyName = configuration["Cloudinary:ApiKey"];
                var secretKey = configuration["Cloudinary:SecretKey"];

                Account account = new Account()
                {
                    Cloud = cloudeName,
                    ApiKey = keyName,
                    ApiSecret = secretKey
                };

                Cloudinary cloudinary = new Cloudinary(account);

                var file = formFile.FileName;
                var stream = formFile.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file, stream)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                return uploadResult.Uri.ToString();
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }
    }
}
