using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiLeao.Domain.Entities;

namespace WebApi.Data.DataConfig
{
    public class CursosConfiguration : IEntityTypeConfiguration<EntityCursos>
    {
        public void Configure(EntityTypeBuilder<EntityCursos> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Valor)
              .HasColumnType("Decimal(18,2)")
              .IsRequired();
        }
    }
}
