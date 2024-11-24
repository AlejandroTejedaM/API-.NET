using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("productos")]
public class ProductoController : Controller
{
	private readonly Jq4bContext _db;
	private readonly IMapper _mapper;
	private readonly IAlmacenamiento _almacenamiento;

	public ProductoController(Jq4bContext db, IMapper mapper, IAlmacenamiento almacenamiento)
	{
		_db = db;
		_mapper = mapper;
		_almacenamiento = almacenamiento;
	}

	[HttpGet]
	public async Task<IActionResult> GetProductos()
	{
		var productos = await _db.Productos
			.Include(p => p.IdCategoriaNavigation)
			.ToListAsync();
		return Ok(_mapper.Map<List<ProductoDTO>>(productos));
	}

	[HttpPost]
	public async Task<IActionResult> AddProducto([FromBody] ProductoRequestDTO productoRequest)
	{
		var producto = _mapper.Map<Producto>(productoRequest);
		_db.Entry(producto).State = EntityState.Added;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Producto agregado" });
	}
	
	[HttpPost("WithImage")]
	public async Task<IActionResult> AddProductoWithImage([FromForm] ProductoRequestDTO productoRequest)
	{
		var producto = _mapper.Map<Producto>(productoRequest);
		producto.Imagen = await _almacenamiento.GuardarArchivoAsync("productos", productoRequest.Imagen);
		_db.Entry(producto).State = EntityState.Added;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Producto agregado" });
	}
	
	[HttpPost("WithImageUrl")]
	public async Task<IActionResult> AddProductoWithImageUrl([FromBody] ProductoRequestWithImageUrlDTO productoRequest)
	{
		var producto = _mapper.Map<Producto>(productoRequest);
		_db.Entry(producto).State = EntityState.Added;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Producto agregado" });
	}
	
	[HttpPut]
	public async Task<IActionResult> UpdateProducto([FromBody] ProductoDTO productoDto)
	{
		var producto = _mapper.Map<Producto>(productoDto);
		_db.Entry(producto).State = EntityState.Modified;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Producto actualizado" });
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteProducto(int id)
	{
		var producto = await _db.Productos.FindAsync(id);
		_db.Productos.Remove(producto);
		await _db.SaveChangesAsync();
		return Ok(new { message = "Producto eliminado" });
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetProducto(int id)
	{
		var producto = await _db.Productos
			.Include(p => p.IdCategoriaNavigation)
			.FirstOrDefaultAsync(p => p.Id == id);
		return Ok(_mapper.Map<ProductoDTO>(producto));
	}
}