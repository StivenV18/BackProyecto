using CESDE.MatriculasProyecto.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CESDE.MatriculasProyecto.Infrastructure.Persistence.DbContexts
{
    public partial class AgoraContext : DbContext, IAgoraDbContext
    {
       

        public AgoraContext()
        {
        }

        public AgoraContext(DbContextOptions<AgoraContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken); ;
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
