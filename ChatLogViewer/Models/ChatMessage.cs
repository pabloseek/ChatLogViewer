using System;

namespace ChatLogViewer.Models
{
    public class ChatMessage
    {
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }
}
