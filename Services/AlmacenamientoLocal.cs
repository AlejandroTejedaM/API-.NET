namespace WebAPI.Services;

public class AlmacenamientoLocal : IAlmacenamiento
{
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AlmacenamientoLocal(
        IWebHostEnvironment env, 
        IHttpContextAccessor httpContextAccessor)
    {
        _env = env;
        _httpContextAccessor = httpContextAccessor;
    }
    public Task BorrarArchivoAsync(string contenedor, string? ruta)
    {
        throw new NotImplementedException();
    }

    public Task<string> EditarArchivoAsync(string contenedor, IFormFile archivo, string? ruta)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GuardarArchivoAsync(string contenedor, IFormFile archivo)
    {
        var extension = Path.GetExtension(archivo.FileName);
        var nombreArchivo = $"{Guid.NewGuid()}{extension}";
        var carpeta = Path.Combine(_env.WebRootPath, contenedor);
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        var ruta = Path.Combine(carpeta, nombreArchivo);
        using (var ms = new MemoryStream())
        {
            await archivo.CopyToAsync(ms);
            await File.WriteAllBytesAsync(ruta, ms.ToArray());
        }
        
        var request = _httpContextAccessor.HttpContext.Request;
        var url = $"{request.Scheme}://{request.Host}";
        var urlArchivo = Path.Combine(url, contenedor, nombreArchivo).Replace("\\", "/");
        return urlArchivo;
    }

    public Task<string> ObtenerArchivoAsync(string contenedor, string ruta)
    {
        throw new NotImplementedException();
    }

    public Task<string> ObtenerUrlAsync(string contenedor, string ruta)
    {
        throw new NotImplementedException();
    }
    
}