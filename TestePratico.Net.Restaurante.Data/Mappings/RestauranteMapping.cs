    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TestePratico.Net.Restaurante.Data.Extensions;

namespace TestePratico.Net.Restaurante.Data.Mappings
{
    public class RestauranteMapping :  EntityTypeConfiguration<Domain.Eventos.Model.Restaurante>
    {
        public override void Map(EntityTypeBuilder<Domain.Eventos.Model.Restaurante> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();           

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Restaurantes");
        }
    }
}
