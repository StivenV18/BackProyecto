using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CESDE.MatriculasProyecto.Application.Interfaces
{
    public interface IAgoraDbContext
    {
 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
    }
}
