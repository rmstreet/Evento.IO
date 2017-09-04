
namespace Eventos.IO.Application.AutoMapper
{
    using ViewModels;
    using Domain.Eventos;
    using global::AutoMapper;
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
