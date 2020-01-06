using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poco = tbr_common.Poco;

namespace tbr_data_api.ModelBuilders
{
    internal class MessageModelBuilder : IPocoToEfModelBuilder
    {
        void IPocoToEfModelBuilder.BuildModel(ModelBuilder mb)
        {
            mb.Entity<Poco.Message>()
                .HasKey(m => m._id);
            mb.Entity<Poco.Message>()
                .HasOne(m => m.Conversation).WithMany(c => c.Messages).HasForeignKey(m => m.conversationId);
            mb.Entity<Poco.Message>()
                .HasMany<Poco.MediaUrl>(m => m.MediaUrls)
                .WithOne(u => u.Message)
                .HasForeignKey(u => u.messageId);
            mb.Entity<Poco.Message>()
                .Property(m => m.uploadKey)
                .HasMaxLength(16)
                .IsRequired();
            mb.Entity<Poco.Message>()
                .Property(m => m.recipientId)
                .IsRequired();
            mb.Entity<Poco.Message>()
                .Property(m => m.senderId)
                .IsRequired();
        }
    }
}
