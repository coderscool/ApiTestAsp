using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiPictur.Models;

namespace TestApiPictur.Data.Configuration
{
    public class PicturConfiguration : IEntityTypeConfiguration<Pictur>
    {
        public void Configure(EntityTypeBuilder<Pictur> builder)
        {
            builder.ToTable("Pictur");

            builder.HasKey(x => x.PicturId);

            builder.Property(x => x.Title).IsRequired(true);

            builder.Property(x => x.Leter).IsRequired(true);
        }

    }
}
