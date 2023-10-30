using AutoMapper;
using CESDE.MatriculasProyecto.Application.Dtos.DocenteDto;
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

namespace CESDE.MatriculasProyecto.Application.Commands.DocenteCommand
{
    public class EliminarDocenteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class EliminarDocenteCommandHandler : IRequestHandler<EliminarDocenteCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<EliminarDocenteCommandHandler> _logger;

        public EliminarDocenteCommandHandler(IApplicationDbContext context, ILogger<EliminarDocenteCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(EliminarDocenteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("EliminarDocenteCommandHandle Started");
            var docente = await _context.Docentes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (docente == null) 
            {
                _logger.LogInformation("No se encuentra el docente");
            }
            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogDebug("EliminarDocenteCommandHandle Finished");
            return true;
        }
    }

}
