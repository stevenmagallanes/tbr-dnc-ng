using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tbr_common.Poco;

namespace tbr_data_api.ModelBuilders
{
    internal class ConversationModelBuilder : IPocoToEfModelBuilder
    {
        void IPocoToEfModelBuilder.BuildModel(ModelBuilder mb)
        {
            mb.Entity<Conversation>()
                .HasKey(c => c._id);
            mb.Entity<Conversation>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.conversationId);
            mb.Entity<Conversation>()
                .Property(c => c.conversationId)
                .HasMaxLength(128)
                .IsRequired();
            mb.Entity<Conversation>()
                .Property(c => c.uploadKey)
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}
