namespace WebAPI.DTO;

public class ProductoRequestDTO
{
	public string NombreProducto { get; set; }
	public int Stock { get; set; }
	public decimal Precio { get; set; }
	public sbyte IdCategoria { get; set; }
	public IFormFile? Imagen { get; set; }
}