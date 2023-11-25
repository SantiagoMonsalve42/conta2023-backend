using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Bussines.implementations
{
    public class FileSystemGenerico
    {
        private IConfiguration _config;
        public FileSystemGenerico()
        {
        }
        public FileSystemGenerico(IConfiguration config)
        {
            _config = config;
            this.basePath = _config["RutaDisco"]; 
        }

        public string? basePath { get; set; }

        public string subirArchivo(IFormFile archivo,string user)
        {
            try
            {
                var fullPath = "";
                if (basePath != null)
                {
                    DateTime date = DateTime.Now;
                    var nameFile = date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second + Path.GetExtension(archivo.FileName);
                    basePath += "\\"+user.ToLower() + "\\" + date.Year + date.Month + date.Day;
                    fullPath = Path.Combine(basePath, nameFile);
                    bool exists = System.IO.Directory.Exists(basePath);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(basePath);
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        var resultado = Path.GetDirectoryName(fullPath);
                        if (resultado != null)
                        {
                            Directory.CreateDirectory(resultado);
                            archivo.CopyToAsync(stream);
                            stream.Close();
                        }

                    }
                }

                return fullPath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public byte[] descargarArchivo(string fileName)
        {
            byte[] fileBytes = null;
            try
            {
                if (basePath != null)
                {
                    fileBytes = File.ReadAllBytes(Path.Combine(basePath, fileName));
                }
            }
            catch (Exception ex)
            {

            }
            return fileBytes;
        }

    }
}
