using System;

namespace ChatContext.Models
{
    public class Chats
    {
        public int ChatId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool Delivered { get; set; } = false;
        public bool Read { get; set; } = false;
        public bool Edited { get; set; } = false;
    }
}
