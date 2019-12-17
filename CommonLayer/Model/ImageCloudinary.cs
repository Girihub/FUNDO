using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class ImageCloudinary
    {
        public Cloudinary cloudinary;
        public string UploadImage(IFormFile formFile)
        {
            try
            {
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
