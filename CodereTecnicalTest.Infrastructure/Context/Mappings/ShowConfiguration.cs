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
    public static class ShowConfiguration
    {
        public static void MapShows(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>(
                builder =>
                {
                    builder.Property(p => p.id).ValueGeneratedNever();

                    builder.Property(p => p.url).HasColumnName("url");
                    builder.Property(p => p.name).HasColumnName("name");
                    builder.Property(p => p.type).HasColumnName("type");
                    builder.Property(p => p.language).HasColumnName("language");
                    builder.Property(p => p.status).HasColumnName("status");
                    builder.Property(p => p.runtime).HasColumnName("runtime");
                    builder.Property(p => p.averageRuntime).HasColumnName("averageRuntime");
                    builder.Property(p => p.premiered).HasColumnName("premiered");
                    builder.Property(p => p.ended).HasColumnName("ended");
                    builder.Property(p => p.officialSite).HasColumnName("officialSite");
                    builder.Property(p => p.weight).HasColumnName("weight");
                    builder.Property(p => p.summary).HasColumnName("summary");

                    //builder.Navigation(p => p.genres).AutoInclude();
                    builder.HasMany(p => p.genres).WithMany(p => p.shows);

                    //builder.Navigation(p => p.network).AutoInclude();
                    //builder.HasOne(p => p.network).WithOne(p => p.show).HasForeignKey<Show>(p => p.networkid).OnDelete(DeleteBehavior.NoAction);
                    //builder.HasOne(p => p.webChannel).WithOne().IsRequired(false).HasForeignKey<Show>(p => p.webChannelid).OnDelete(DeleteBehavior.NoAction);

                    //builder.HasOne(p => p.rating).WithOne(p => p.show).HasForeignKey<Show>(p => p.ratingid).OnDelete(DeleteBehavior.NoAction);
                    //builder.HasOne(p => p.externals).WithOne(p => p.show).HasForeignKey<Show>(p => p.externalsid).OnDelete(DeleteBehavior.NoAction);
                    //builder.HasOne(p => p._links).WithOne(p => p.show).HasForeignKey<Show>(p => p._linksid).OnDelete(DeleteBehavior.NoAction);
                    //builder.HasOne(p => p.schedule).WithOne(p => p.show).HasForeignKey<Show>(p => p.scheduleid).OnDelete(DeleteBehavior.NoAction);
                    //builder.HasOne(p => p.image).WithOne(p => p.show).HasForeignKey<Show>(p => p.imageid).OnDelete(DeleteBehavior.NoAction);
                }
                );
        }
    }
}
