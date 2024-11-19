namespace WebAPI.DTO;

public class EncargadoDTO
{
	public short Id { get; set; }
	public string Nombre { get; set; }
	public string Apepat { get; set; }
	public string Apemat { get; set; }
	public string Telefono { get; set; }
	public string Correo { get; set; }
	public string Usuario { get; set; }
	public string Pwd { get; set; }
	public sbyte IdRol { get; set; }
	public string? Rol { get; set; }
}