using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers;
[ApiController]
[Route("tiendas")]
public class TiendaController : Controller
{
	private readonly Jq4bContext _db;
	private readonly IMapper _mapper;
	
	public TiendaController(Jq4bContext db, IMapper mapper) 
	{
		_db = db;
		_mapper = mapper;
	}
	
	[HttpGet]
	public async Task<IActionResult> GetTiendas()
	{
		var tiendas = await _db.Tiendas
			.Include(t => t.IdEncargadoNavigation)
			.ToListAsync();
		return Ok(_mapper.Map<List<TiendaDTO>>(tiendas));
	}
	
	[HttpPost]
	public async Task<IActionResult> AddTienda([FromBody] TiendaRequestDTO tiendaRequest)
	{
		var tienda = _mapper.Map<Tienda>(tiendaRequest);
		_db.Entry(tienda).State = EntityState.Added;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Tienda agregada" });
	}
	
	[HttpPut]
	public async Task<IActionResult> UpdateTienda([FromBody] TiendaDTO tiendaDto)
	{
		var tienda = _mapper.Map<Tienda>(tiendaDto);
		_db.Entry(tienda).State = EntityState.Modified;
		await _db.SaveChangesAsync();
		return Ok(new { message = "Tienda actualizada" });
	}
	
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteTienda(short id)
	{
		var tienda = await _db.Tiendas.FindAsync(id);
		_db.Tiendas.Remove(tienda);
		await _db.SaveChangesAsync();
		return Ok(new { message = "Tienda eliminada" });
	}
	
	[HttpGet("{id}")]
	public async Task<IActionResult> GetTienda(short id)
	{
		var tienda = await _db.Tiendas
			.Include(t => t.IdEncargadoNavigation)
			.FirstOrDefaultAsync(t => t.Id == id);
		return Ok(_mapper.Map<TiendaDTO>(tienda));
	}
}