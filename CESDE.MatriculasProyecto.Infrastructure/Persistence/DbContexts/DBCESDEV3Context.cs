using CESDE.MatriculasProyecto.Application.Interfaces;
using CESDE.MatriculasProyecto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CESDE.MatriculasProyecto.Infrastructure.Persistence.DbContexts
{
    public partial class DBCESDEV3Context : DbContext, IApplicationDbContext
    {
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public DBCESDEV3Context() { }
        public DBCESDEV3Context(DbContextOptions<DBCESDEV3Context> options)
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
            return await base.SaveChangesAsync(cancellationToken); 
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
