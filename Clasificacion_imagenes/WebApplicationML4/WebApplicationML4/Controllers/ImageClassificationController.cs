using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationML4ML.Model;
using WebApplicationML4.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WebApplicationML4.Controllers
{
    public class ImageClassificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClasificarImagen()
        {
            ImageClassification imageClassification = new ImageClassification()
            {
                ImageData = new ModelInput()
                {
                    ImageSource = @"..\..\..\..\..\data\Test\Jackets\0ed0fc9c-c942-4761-a560-3d31c7962a81___Data_36-aaaboptk000brown-golden-triangle-original-imaem5sbdfhgzhcd.jpeg",
                    Label = "Jacket",
                },
                ImagePrediction = new ModelOutput()
            };

            return View(imageClassification);
        }

        [HttpPost]
        public async Task<IActionResult> ClasificarImagen(IFormFile imgFile)
        {
            string pathPrediction = @"..\..\..\..\..\data\Predict\";
            string pathImgPredict = Path.Combine(pathPrediction, imgFile.FileName);

            using (var stream  =System.IO.File.Create(pathImgPredict))
            {
               await imgFile.CopyToAsync(stream);
            }

            ImageClassification imageClassification = new ImageClassification()
            {
                ImageData = new ModelInput()
                {
                    ImageSource = pathImgPredict,
                    Label = "Desconocido",
                },
                ImagePrediction = new ModelOutput()
            };

            imageClassification.ImagePrediction = QueTipoDeProductoEs(imageClassification.ImageData);

            return View(imageClassification);
        }

        private ModelOutput QueTipoDeProductoEs(ModelInput modelInput)
        {
            return ConsumeModel.Predict(modelInput);
        }

        private IEnumerable<ModelInput> LoadImagesFromDirectory(string folder, bool useFolderNameasLabel = true)
        {
            var files = Directory.GetFiles(folder, "*",
                searchOption: SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png") && (Path.GetExtension(file) != ".jpeg"))
                    continue;

                var label = Path.GetFileName(file);
                if (useFolderNameasLabel)
                    label = Directory.GetParent(file).Name;
                else
                {
                    for (int index = 0; index < label.Length; index++)
                    {
                        if (!char.IsLetter(label[index]))
                        {
                            label = label.Substring(0, index);
                            break;
                        }
                    }
                }

                yield return new ModelInput()
                {
                    ImageSource = file,
                    Label = label
                };

            }
        }
    }
}