using AM.Domain.Models;
using AM.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infra.Data.EntityConfigurations
{
    public class UserConfig : EntityConfiguration<UserEntity>, IEntityTypeConfiguration<UserEntity>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // Com este método, já configuramos as propriedades comuns,
            // bem como nome da tabela e a chave primária
            DefaultConfigs(builder, tableName: "USERS");

            // Crio um index na propriedade de e-mail e marco como única,
            // ou seja, eu garato que jamais havará 2 ou mais e-mails iguais
            // em nossa base
            //builder.HasIndex(x => x.Email).IsUnique();

            //builder.Property(x => x.Name)   // Pego a propriedade de nome
            //    .HasMaxLength(45)           // Informo que o nome poderá ter no máximo 45 caracters
            //    .IsRequired();              // Informo que o nome é obrigatório

            //builder.Property(x => x.Email) // Pego a propriedade de email
            //    .HasMaxLength(45)          // Informo que o e-mail poderá ter no máximo 45 caracters
            //    .IsRequired();             // Informo que o e-mail é obrigatório

        }
    }
}
