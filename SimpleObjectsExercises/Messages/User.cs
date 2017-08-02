using System;
using System.Collections.Generic;
using System.Linq;


namespace Messages
{
    public class User
    {
        public string Username { get; set; }

        public List<Message> ReceivedMessages { get; set; }
    }
}
