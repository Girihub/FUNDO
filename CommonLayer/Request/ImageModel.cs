using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Request
{
    public class ImageModel
    {
        public int id { get; set; }

        public IFormFile formFile { get; set; }
    }
}
