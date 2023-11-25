using Bussines.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Bussines.implementations
{
    public class FileSystemGenerico
    {
        private ILogBussines _log;
        private IConfiguration _config;
        
        public FileSystemGenerico(IConfiguration config, ILogBussines logData)
        {
            _config = config;
            this.basePath = _config["RutaDisco"];
            _log = logData;
        }

        public string? basePath { get; set; }

        public async Task<string> subirArchivo(IFormFile archivo,string user,string ip)
        {
            var log = await _log.crearAuditoria("Subir archivo",user,ip);
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
                await _log.exitoAuditoria((int)log.IdLog, "OK");
                return fullPath;
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)log.IdLog,ex.Message);
                return ex.Message;
            }

        }
        public async Task<byte[]> descargarArchivo(string fileName, string user, string ip)
        {
            byte[] fileBytes = null;
            var log = await _log.crearAuditoria("Descragra archivo", user, ip);
            try
            {
                if (basePath != null)
                {
                    fileBytes = File.ReadAllBytes(Path.Combine(basePath, fileName));
                }
                await _log.exitoAuditoria((int)log.IdLog, "OK");
            }
            catch (Exception ex)
            {
                await _log.falloAuditoria((int)log.IdLog, ex.Message);
            }
            return fileBytes;
        }

    }
}
