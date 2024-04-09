using System;
using System.Collections.Generic;

namespace Bot.Models
{
    public partial class CousesOnOutLet
    {
        public int Id { get; set; }
        public int? Idcloses { get; set; }
        public int? Idoutlets { get; set; }
        public int? Count { get; set; }
        public string? Size { get; set; }

        public virtual Close? IdclosesNavigation { get; set; }
        public virtual Outlet? IdoutletsNavigation { get; set; }
    }
}
