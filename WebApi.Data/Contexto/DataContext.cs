using Microsoft.EntityFrameworkCore;
using WebApi.Data.DataConfig;
using WebApiLeao.Domain.Entities;

namespace WebApi.Data.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntityCursos>(new CursosConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
