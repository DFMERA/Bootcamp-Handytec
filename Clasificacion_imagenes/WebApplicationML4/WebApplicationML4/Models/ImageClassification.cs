using System;
using System.IO;
using WebApplicationML4ML.Model;

namespace WebApplicationML4.Models
{
    public class ImageClassification
    {
        public ModelInput ImageData { get; set; }

        public ModelOutput ImagePrediction { get; set; }

    }
}
