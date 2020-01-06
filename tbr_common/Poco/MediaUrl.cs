using System;
using System.Collections.Generic;
using System.Text;

namespace tbr_common.Poco
{
    public class MediaUrl
    {
        public string _id { get; set; }
        public string messageId { get; set; }
        public Message Message { get; set; }
        public string Url { get; set; }
    }
}
