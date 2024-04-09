using System;
using System.Collections.Generic;

namespace Bot.Models
{
    public partial class Close
    {
        public Close()
        {
            CousesOnOutLets = new HashSet<CousesOnOutLet>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CousesOnOutLet> CousesOnOutLets { get; set; }
    }
}
