using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public record Url(string Value)
    {
        public static implicit operator string(Url url) => url.Value;
        public static implicit operator Url(string value) => new Url(value);
    }
}