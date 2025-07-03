using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public record PostMetaData(DateTime CreatedAt, DateTime? ChangedAt, string CreatedBy, string? ChangedBy = "")
    {
        public static PostMetaData Default => new(DateTime.UtcNow, null, "System");
        
        public PostMetaData WithChangedBy(string changedBy)
        {
            return this with { ChangedBy = changedBy, ChangedAt = DateTime.UtcNow };
        }
        
        public PostMetaData WithChangedAt(DateTime changedAt)
        {
            return this with { ChangedAt = changedAt };
        }
    }   
}