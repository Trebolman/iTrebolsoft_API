using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TProyectos
    {
        public TProyectos()
        {
            TImages = new HashSet<TImages>();
        }

        public Guid ProyId { get; set; }
        public string ProyTitle { get; set; }
        public string ProyDesc { get; set; }
        public DateTime? ProyDate { get; set; }
        public Guid? FkTUserUserId { get; set; }
        public string ProyUrl { get; set; }
        public string ProyEtiq { get; set; }

        public virtual TUser FkTUserUser { get; set; }
        public virtual ICollection<TImages> TImages { get; set; }
    }
}
