using CodereTecnicalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Infrastructure.Context.Mappings
{
    public static class CountryConfiguration
    {
        public static void MapCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(
                builder =>
                {
                    builder.HasKey(p => p.id);

                    builder.Property(p => p.name).HasColumnName("name");
                    builder.Property(p => p.code).HasColumnName("code");
                }
            );
        }
    }
}
