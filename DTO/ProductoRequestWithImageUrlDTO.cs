namespace WebAPI.DTO;

public class ProductoRequestWithImageUrlDTO
{
    public string NombreProducto { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public sbyte IdCategoria { get; set; }
    public string Imagen { get; set; }
}