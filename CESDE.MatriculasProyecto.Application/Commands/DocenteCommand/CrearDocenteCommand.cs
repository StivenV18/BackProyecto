﻿
using AutoMapper;
using CESDE.MatriculasProyecto.Application.Dtos.DocenteDto;
using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CESDE.MatriculasProyecto.Application.Commands.DocenteCommand
{
    public class CrearDocenteCommand : IRequest<DocenteDto>
    {
        public int IdentificacionDocente { get; set; }
        public string TipoIdentificacionDocente { get; set; } = null!;
        public string NombreDocente { get; set; } = null!;
        public string ApellidoDocente { get; set; } = null!;
        public string CorreoElectronicoDocente { get; set; } = null!;
        public string TelefonoCelularDocente { get; set; } = null!;
        public string NumeroContratoDocente { get; set; } = null!;
        public string CiudadResidenciaDocente { get; set; } = null!;
        public string EscalafonTecnicoDocente { get; set; } = null!;
        public string EscalafonExtensionDocente { get; set; } = null!;
    }

    public class DocenteCommandHandler : IRequestHandler<CrearDocenteCommand, DocenteDto> 
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DocenteCommandHandler> _logger;

        public DocenteCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<DocenteCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<DocenteDto> Handle(CrearDocenteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CrearDocenteCommandHandler started.");

            var docente = _mapper.Map<Docente>(request);

            await _context.Docentes.AddAsync(docente);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("CrearDocenteCommandHandler finished.");

            return _mapper.Map<DocenteDto>(docente);
        }
    }
}
