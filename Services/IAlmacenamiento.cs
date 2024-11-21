namespace WebAPI.Services;

public interface IAlmacenamiento
{
    Task<string> GuardarArchivoAsync(string contenedor, IFormFile archivo);
    Task BorrarArchivoAsync(string contenedor, string? ruta);
    Task<string> EditarArchivoAsync(string contenedor, IFormFile archivo, string? ruta);
    Task<string> ObtenerArchivoAsync(string contenedor, string ruta);
    Task<string> ObtenerUrlAsync(string contenedor, string ruta);
}
