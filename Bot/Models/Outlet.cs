using System;
using System.Collections.Generic;

namespace Bot.Models
{
    public partial class Outlet
    {
        public Outlet()
        {
            CousesOnOutLets = new HashSet<CousesOnOutLet>();
        }

        public int Id { get; set; }
        public string? Adress { get; set; }

        public virtual ICollection<CousesOnOutLet> CousesOnOutLets { get; set; }
    }
}
