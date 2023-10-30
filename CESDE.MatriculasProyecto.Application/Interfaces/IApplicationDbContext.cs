using CESDE.MatriculasProyecto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CESDE.MatriculasProyecto.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Docente> Docentes { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
    }
}
