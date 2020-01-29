using AM.Domain.Entities;
using AM.Infra.Data.Interfaces.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infra.Data.EntityConfigurations
{
    public class PessoaConfig : EntityConfiguration<PessoaEntity>, IEntityTypeConfiguration<PessoaEntity>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            DefaultConfigs(builder, tableName: "PESSOA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.HasMany(x => x.Consultas).WithOne(x => x.Pessoa).HasForeignKey(x => x.IdPessoa);
        }
    }
}
