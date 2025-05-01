using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatDbContext.Models
{
    [Table("Chats")]
    public class Chats
    {
        [Key]
        public int ChatId { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        [StringLength(250)]
        [DataType("nvarchar(250)")]
        public required string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        [DataType("bit")]
        public bool Delivered { get; set; } = false;
        [DataType("bit")]
        public bool Read { get; set; } = false;
        [DataType("bit")]
        public bool Edited { get; set; } = false;
    }
}
