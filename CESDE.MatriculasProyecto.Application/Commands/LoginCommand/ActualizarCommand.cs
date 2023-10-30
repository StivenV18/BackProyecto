using AutoMapper;
using CESDE.MatriculasProyecto.Application.Commands.DocenteCommand;
using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESDE.MatriculasProyecto.Application.Commands.LoginCommand
{
    public class ActualizarCommand : IRequest<Usuario>
    {
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
    public class ActualizarCommandHandler : IRequestHandler<ActualizarCommand, Usuario> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ActualizarCommandHandler> _logger;

        public ActualizarCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<ActualizarCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Usuario> Handle(ActualizarCommand request, CancellationToken cancellationToken)
        {
            var consultar = await _context.Usuarios
     .FirstOrDefaultAsync(x => x.Usuario1 == request.Usuario,
         cancellationToken);

            _mapper.Map(request, consultar);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Usuario>(consultar);
        }
    }
}
