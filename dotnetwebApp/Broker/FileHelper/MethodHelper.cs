using Broker.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Broker.FileHelper
{
    public class MethodHelper
    {
        public async static Task<string> FileToBeSaved(string title, IFormFile imageFile)
        {
            string fileName = title + "-" + DateTime.Now.ToString("MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + ".jpg";
            string fullFileName = fileName.Replace(":", "-").Replace(" ", "");
            string filePath = $"{RootToBroker()}\\wwwroot\\UploadFiles\\{fullFileName}";

            //string fileName = Path.GetFileName(postView.Image[0].FileName); 
            //string webRootPath = _webHostEnvironment.WebRootPath+ "\\Uploads\\"+ fileName;

            using (var stream = System.IO.File.Create(filePath))
            {
                try
                {
                    await imageFile.CopyToAsync(stream);
                }
                finally
                {
                    stream.Close();
                }
            }

            return fullFileName;
        }


        private static string RootToBroker()
        {
            return Environment.CurrentDirectory;
        }
    }
}
