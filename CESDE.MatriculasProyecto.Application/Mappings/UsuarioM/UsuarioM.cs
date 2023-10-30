using AutoMapper;
using CESDE.MatriculasProyecto.Application.Commands.LoginCommand;
using CESDE.MatriculasProyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESDE.MatriculasProyecto.Application.Mappings.UsuarioM
{
    internal class UsuarioM : Profile
    {
        public UsuarioM() {
            CreateMap<ActualizarCommand, Usuario>();
            CreateMap<CrearUsuarioCommand, Usuario>();
        }
    }
}
