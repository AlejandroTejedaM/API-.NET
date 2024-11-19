using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("encargados")]
public class EncargadoController : Controller
{
	
	private readonly Jq4bContext _db;
	private readonly IMapper _mapper;
	
	public EncargadoController(Jq4bContext db, IMapper mapper) 
	{
		_db = db;
		_mapper = mapper;
	}
	
	[HttpGet]
	public async Task<IActionResult> GetEncargados()
	{
		var encargados = await _db.Encargadotienda
			.Include(e => e.IdRolNavigation)
			.ToListAsync();
		return Ok(_mapper.Map<List<EncargadoDTO>>(encargados));
	}
	
	[HttpPost]
	public async Task<IActionResult> AddEncargado([FromBody] EncargadoRequestDTO encargadoRequest)
	{
		var encargado = _mapper.Map<Encargadotiendum>(encargadoRequest);
		_db.Entry(encargado).State = EntityState.Added;
		await _db.SaveChangesAsync();
		return Ok("Encargado agregado");
	}
	
	[HttpPut]
	public async Task<IActionResult> UpdateEncargado([FromBody] EncargadoDTO encargadoDto)
	{
		var encargado = _mapper.Map<Encargadotiendum>(encargadoDto);
		_db.Entry(encargado).State = EntityState.Modified;
		await _db.SaveChangesAsync();
		return Ok("Encargado actualizado");
	}
	
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteEncargado(short id)
	{
		var encargado = await _db.Encargadotienda.FindAsync(id);
		_db.Encargadotienda.Remove(encargado);
		await _db.SaveChangesAsync();
		return Ok("Encargado eliminado");
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetEncargado(short id)
	{
		var encargado = await _db.Encargadotienda
			.Include(e => e.IdRolNavigation)
			.FirstOrDefaultAsync(e => e.Id == id);
		return Ok(_mapper.Map<EncargadoDTO>(encargado));
	}
}