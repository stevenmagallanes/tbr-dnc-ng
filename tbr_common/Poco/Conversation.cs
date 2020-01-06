using System;
using System.Collections.Generic;
using System.Text;

namespace tbr_common.Poco
{
    public class Conversation
    {
        public string _id { get; set; }
        public string uploadKey { get; set; }
        public string conversationId { get; set; }
        public int recipientId { get; set; }
        public int senderId { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public DateTime createdDate { get; set; }
    }
}
