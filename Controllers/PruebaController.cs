using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("Prueba")]
public class PruebaController : Controller
{
    private readonly DbfrontendContext _db;
    
    public PruebaController(DbfrontendContext db) 
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPruebas()
    {
        return Ok(_db.Pruebas.ToList());
    }
    
    [HttpPost]
    [Description("Agrega una prueba")]
    public async Task<IActionResult> AddPrueba([FromBody] Prueba prueba)
    {
        _db.Pruebas.Add(prueba);
        await _db.SaveChangesAsync();
        return Ok("Prueba agregada");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePrueba([FromBody] Prueba prueba)
    {
        
        _db.Entry(prueba).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return Ok("Prueba actualizada");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrueba(int id)
    {
        var prueba = await _db.Pruebas.FindAsync(id);
        _db.Pruebas.Remove(prueba);
        await _db.SaveChangesAsync();
        return Ok("Prueba eliminada");
    }
}