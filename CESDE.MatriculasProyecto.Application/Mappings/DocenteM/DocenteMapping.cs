
using AutoMapper;
using CESDE.MatriculasProyecto.Application.Commands.DocenteCommand;
using CESDE.MatriculasProyecto.Application.Dtos.DocenteDto;
using CESDE.MatriculasProyecto.Domain.Entities;

namespace CESDE.MatriculasProyecto.Application.Mappings.DocenteM
{
    internal class DocenteMapping : Profile
    {
        public DocenteMapping() 
        {
            CreateMap<Docente, DocenteDto>();
            CreateMap<CrearDocenteCommand, Docente>();
            CreateMap<EditarDocenteCommand, Docente>();
        }
    }
}
