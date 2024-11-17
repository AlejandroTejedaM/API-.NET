using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("categorias")]
public class CategoriaController : Controller
{
    
    private readonly Jq4bContext _db;
    private readonly IMapper _mapper;
    
    public CategoriaController(Jq4bContext db, IMapper mapper) 
    {
        _db = db;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategorias()
    {
        var categorias = await _db.Categorias.ToListAsync();
        return Ok(_mapper.Map<List<CategoriaDTO>>(categorias));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCategoria([FromBody] CategoriaRequestDTO categoriaRequest)
    {
        var categoria = _mapper.Map<Categoria>(categoriaRequest);
        _db.Entry(categoria).State = EntityState.Added;
        await _db.SaveChangesAsync();
        return Ok("Categoria agregada");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCategoria([FromBody] CategoriaDTO categoriaDto)
    {
        var categoria = _mapper.Map<Categoria>(categoriaDto);
        _db.Entry(categoria).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return Ok("Categoria actualizada");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(sbyte id)
    {
        var categoria = await _db.Categorias.FindAsync(id);
        _db.Categorias.Remove(categoria);
        await _db.SaveChangesAsync();
        return Ok("Categoria eliminada");
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoria(sbyte id)
    {
        var categoria = await _db.Categorias.FindAsync(id);
        return Ok(_mapper.Map<CategoriaDTO>(categoria));
    }
}