using MediatR;

namespace CESDE.MatriculasProyecto.API.Controllers.Docentes
{
    internal class ConsultaDocenteByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
    }
}