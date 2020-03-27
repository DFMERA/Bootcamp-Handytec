using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using WebApplicationML4ML.Model;

namespace WebApplicationML4.Models
{
    public class ImageClassification
    {
        public IFormFile ImgFile { get; set; }

        public ModelInput ImageData { get; set; }

        public ModelOutput ImagePrediction { get; set; }

    }
}
