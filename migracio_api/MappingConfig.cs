using AutoMapper;
using SharedModels;
using SharedModels.Dto;

namespace migracio_api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoCreateDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoUpdateDto>().ReverseMap();

            CreateMap<User, RegisterUserDto>().ReverseMap();

            CreateMap<Ingreso, IngresoDto>().ReverseMap();
            CreateMap<Ingreso, IngresoCreateDto>().ReverseMap();
            CreateMap<Ingreso, IngresoUpdateDto>().ReverseMap();

            CreateMap<Deduccion, DeduccionDto>().ReverseMap();
            CreateMap<Deduccion, DeduccionCreateDto>().ReverseMap();
            CreateMap<Deduccion, DeduccionUpdateDto>().ReverseMap();

            CreateMap<Nomina, NominaDto>().ReverseMap();
            CreateMap<Nomina, NominaCreateDto>().ReverseMap();
            CreateMap<Nomina, NominaUpdateDto>().ReverseMap();
        }

    }
}
