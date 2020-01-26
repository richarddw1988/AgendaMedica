using AM.Domain.Entities;
using AM.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infra.Data.EntityConfigurations
{
    public class ConsultaConfig : EntityConfiguration<ConsultaEntity>, IEntityTypeConfiguration<ConsultaEntity>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<ConsultaEntity> builder)
        {
            DefaultConfigs(builder, tableName: "CONSULTA");
            builder.Property(x => x.DataHoraInicio)
                .IsRequired();
            builder.Property(x => x.DataHoraFinal)
                .IsRequired();
            builder.Property(x => x.Observacoes)
                .HasMaxLength(500)
                .HasDefaultValue();
            builder.HasMany<PessoaEntity>();
        }
    }
}
