using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePratico.Net.Restaurante.Data.Extensions;

namespace TestePratico.Net.Restaurante.Data.Mappings
{
    public class PratoMapping : EntityTypeConfiguration<Domain.Eventos.Model.Prato>
    {
        public override void Map(EntityTypeBuilder<Domain.Eventos.Model.Prato> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);
            
            builder.ToTable("Pratos");
        }
    }
}
