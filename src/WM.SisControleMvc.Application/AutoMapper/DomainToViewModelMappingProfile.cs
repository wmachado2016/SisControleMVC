using AutoMapper;
using WM.SisControleMvc.Application.ViewsModels;
using WM.SisControleMvc.Domain.Models;

namespace WM.SisControleMvc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
