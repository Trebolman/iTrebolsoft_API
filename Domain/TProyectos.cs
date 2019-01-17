using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TProyectos
    {
        public Guid ProyId { get; set; }
        public string ProyTitle { get; set; }
        public string ProyDesc { get; set; }
        public DateTime? ProyDate { get; set; }
        public Guid? FkUserUserId { get; set; }

        public virtual TUser FkUserUser { get; set; }
    }
}
