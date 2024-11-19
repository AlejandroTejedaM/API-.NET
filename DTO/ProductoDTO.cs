namespace WebAPI.DTO;

public class ProductoDTO
{
	public int Id { get; set; }
	public string NombreProducto { get; set; }
	public int Stock { get; set; }
	public decimal Precio { get; set; }
	public sbyte IdCategoria { get; set; }
	public string? NombreCategoria { get; set; }
}