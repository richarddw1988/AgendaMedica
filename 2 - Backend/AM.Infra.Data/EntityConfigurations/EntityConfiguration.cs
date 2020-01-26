using AM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Infra.Data.EntityConfigurations
{
    public class EntityConfiguration<TEntity> where TEntity : Entity
    {
        public void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ToTable(tableName);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCriacao).IsRequired();
        }
    }
}
