using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public class Message
    {
        public string Content { get; set; }

        public User Sender { get; set; }
    }
}
