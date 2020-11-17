using AutoMapper;
using VxTel.Domain.Commands.Inputs;
using VxTel.Domain.Commands.Outputs;
using VxTel.Domain.Commands.QueriesResults;
using VxTel.Domain.Entities;

namespace VxTel.API.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ConsultaPlanosQueryResult, OutConsultaPlanos>();
            CreateMap<ConsultaTabelacaoPrecosQueryResult, OutConsultaTabelacaoPrecos>();
            
            CreateMap<VxTelUser, OutLogin>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Permissoes, opt => opt.MapFrom(src => src.Perfil));
            
            CreateMap<InNovoPlano, PlanosVxTel>()
                .ConstructUsing(c => new PlanosVxTel(0, c.NomePlano, c.MinutosPlano));

            CreateMap<PlanosVxTel, OutPlanoCadastrado>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomePlano, opt => opt.MapFrom(src => src.NomePlano))
                .ForMember(dest => dest.MinutosPlano, opt => opt.MapFrom(src => src.MinutosPlano));
        }
    }
}
