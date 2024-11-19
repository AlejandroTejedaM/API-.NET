namespace WebAPI.DTO;

public class TiendaRequestDTO
{
	public string NombreTienda { get; set; }
	public string Direccion { get; set; }
	public decimal? Latitud { get; set; }
	public decimal? Longitud { get; set; }
	public string Telefono { get; set; }
	public short IdEncargado { get; set; }
}