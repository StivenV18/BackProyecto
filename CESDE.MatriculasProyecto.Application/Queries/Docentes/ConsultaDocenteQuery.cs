
using CESDE.MatriculasProyecto.Application.Dtos.DocenteDto;
using CESDE.MatriculasProyecto.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CESDE.MatriculasProyecto.Application.Queries.Docentes
{
    public class ConsultaDocenteQuery : IRequest<List<DocenteDto>>
    {

    }

    public class ConsultaDocenteQueryHandler : IRequestHandler<ConsultaDocenteQuery, List<DocenteDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ConsultaDocenteQueryHandler> _logger;

        public ConsultaDocenteQueryHandler(IApplicationDbContext context, ILogger<ConsultaDocenteQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<List<DocenteDto>> Handle(ConsultaDocenteQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("ConsultaDocentesQueryHandler started. ");

            var docentes = await _context.Docentes.Select(x => new DocenteDto()
            {
              Id = x.Id,
              IdentificacionDocente = x.IdentificacionDocente,
              TipoIdentificacionDocente = x.TipoIdentificacionDocente,
              NombreDocente = x.NombreDocente,
              ApellidoDocente = x.ApellidoDocente,
              CorreoElectronicoDocente  = x.CorreoElectronicoDocente,
              TelefonoCelularDocente  = x.TelefonoCelularDocente,
              NumeroContratoDocente = x.NumeroContratoDocente,
              EscalafonTecnicoDocente = x.EscalafonTecnicoDocente,
              EscalafonExtensionDocente = x.EscalafonExtensionDocente,
              CiudadResidenciaDocente = x.CiudadResidenciaDocente,
    }).ToListAsync(cancellationToken);

            _logger.LogDebug("ConsultaConceptoQueryHandler finished. ");

            return docentes;
        }
    }

}
