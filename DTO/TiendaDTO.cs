namespace WebAPI.DTO;

public class TiendaDTO
{
	public short Id { get; set; }
	public string NombreTienda { get; set; }
	public string Direccion { get; set; }
	public decimal? Latitud { get; set; }
	public decimal? Longitud { get; set; }
	public string Telefono { get; set; }
	public short IdEncargado { get; set; }
	public string? NombreEncargado { get; set; }
	public string? ApepatEncargado { get; set; }
	public string? ApematEncargado { get; set; }
	public string? CorreoEncargado { get; set; }
}