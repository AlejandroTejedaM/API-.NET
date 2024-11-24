using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Utils;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<Producto, ProductoDTO>().ForMember(dest =>
				dest.NombreCategoria, opt =>
				opt.MapFrom(src => src.IdCategoriaNavigation.NombreCategoria)
		);
		CreateMap<ProductoDTO, Producto>();
		CreateMap<ProductoRequestDTO, Producto>();
		CreateMap<ProductoRequestWithImageUrlDTO, Producto>();
		CreateMap<Categoria, CategoriaDTO>();
		CreateMap<CategoriaRequestDTO, Categoria>();
		CreateMap<CategoriaDTO, Categoria>();
		CreateMap<TiendaDTO, Tienda>();
		CreateMap<Tienda, TiendaDTO>().ForMember(dest =>
				dest.NombreEncargado, opt =>
				opt.MapFrom(src => src.IdEncargadoNavigation.Nombre)
		).ForMember(dest =>
				dest.ApepatEncargado, opt =>
				opt.MapFrom(src => src.IdEncargadoNavigation.Apepat)
		).ForMember(dest =>
				dest.ApematEncargado, opt =>
				opt.MapFrom(src => src.IdEncargadoNavigation.Apemat)
		).ForMember(dest =>
				dest.CorreoEncargado, opt =>
				opt.MapFrom(src => src.IdEncargadoNavigation.Correo)
		);
		CreateMap<TiendaRequestDTO, Tienda>();
		CreateMap<Encargadotiendum, EncargadoDTO>()
			.ForMember(dest =>
					dest.Rol, opt =>
					opt.MapFrom(src => src.IdRolNavigation.Rol)
			);
		CreateMap<EncargadoRequestDTO, Encargadotiendum>();
		CreateMap<EncargadoDTO, Encargadotiendum>();
	}
}