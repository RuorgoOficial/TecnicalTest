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
    public static class NetworkConfiguration
    {
        public static void MapNetworks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Network>(
                builder =>
                {
                    builder.Property(p => p.id).ValueGeneratedNever();

                    builder.Property(p => p.name).HasColumnName("name");
                    builder.Property(p => p.officialSite).IsRequired(false).HasColumnName("officialSite");

                    //builder.Navigation(p => p.country).AutoInclude();
                    builder.HasOne(p => p.country);
                }
            );
        }
    }
}
