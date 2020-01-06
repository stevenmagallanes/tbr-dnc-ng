using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tbr_common.Poco;

namespace tbr_data_api.ModelBuilders
{
    internal class MediaUrlModelBuilder : IPocoToEfModelBuilder
    {
        void IPocoToEfModelBuilder.BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaUrl>().HasKey(u => u._id);
            modelBuilder.Entity<MediaUrl>()
                .HasOne(u => u.Message)
                .WithMany(m => m.MediaUrls)
                .HasForeignKey(u => u.messageId);
            modelBuilder.Entity<MediaUrl>()
                .Property(u => u.Url)
                .HasMaxLength(512)
                .IsRequired(false);
        }
    }
}
