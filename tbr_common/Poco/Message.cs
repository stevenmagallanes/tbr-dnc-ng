using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbr_common.Poco
{
    public class Message
    {
        public string _id { get; set; }
        public string conversationId { get; set; }
        public Conversation Conversation { get; set; }
        public string uploadKey { get; set; }

        [Required]
        public int recipientId { get; set; }
        [Required]
        public int senderId { get; set; }

        public string text { get; set; }

        public IEnumerable<MediaUrl> MediaUrls { get; set; }

        public int externalId { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

    }
}
