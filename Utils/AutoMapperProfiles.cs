using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Categoria, CategoriaDTO>();
        CreateMap<CategoriaRequestDTO, Categoria>();
        CreateMap<CategoriaDTO , Categoria>();
    }
    
}