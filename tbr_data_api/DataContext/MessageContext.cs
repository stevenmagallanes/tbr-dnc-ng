using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using tbr_data_api.ModelBuilders;
using Poco = tbr_common.Poco;

namespace tbr_data_api.DataContext
{
    public class MessageContext : DbContext
    {
        private IEnumerable<IPocoToEfModelBuilder> modelsToBeBuilt;
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
            this.modelsToBeBuilt = new List<IPocoToEfModelBuilder> {
                new MediaUrlModelBuilder(),
                new MessageModelBuilder(),
                new ConversationModelBuilder()
                };
        }

        public DbSet<Poco.Message> Message { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.modelsToBeBuilt.BuildModels(modelBuilder);
        }

        public DbSet<tbr_common.Poco.Conversation> Conversation { get; set; }
    }
}
