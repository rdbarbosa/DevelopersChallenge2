using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjetoNibo.Domain.Models;
using ProjetoNibo.Services.Helpers;
using ProjetoNibo.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Services
{
    public class FileService : IFileService
    {
        private readonly ITransactionService _transactionService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private const string folderName = "Upload";

        public FileService(ITransactionService transactionService, IWebHostEnvironment hostingEnviroment)
        {
            _transactionService = transactionService;
            _hostingEnvironment = hostingEnviroment;
        }

        public async Task Upload(IFormFileCollection files)
        {
            long size = files.Sum(f => f.Length);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            string fullPath = "";
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (files.Any())
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "-" + ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                        fullPath = Path.Combine(newPath, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        await Task.Run(() => Read(fullPath));
                    }

                }
            }
        }

        private void Read(string filePath)
        {
            try
            {
                var fixedString = XmlConverter.Convert(filePath);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(OFXFile));
                var steamFile = GenerateStream(fixedString);
                var result = xmlSerializer.Deserialize(steamFile);

                steamFile.Close();

                _transactionService.AddFromFile(result as OFXFile);

            }
            catch (Exception ex)
            { throw new ApplicationException($"Invalid File : {ex}"); };

        }

        private Stream GenerateStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
