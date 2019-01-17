using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TUser
    {
        public TUser()
        {
            TBlog = new HashSet<TBlog>();
            TProducto = new HashSet<TProducto>();
            TProyectos = new HashSet<TProyectos>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserRango { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserWeb { get; set; }

        public virtual ICollection<TBlog> TBlog { get; set; }
        public virtual ICollection<TProducto> TProducto { get; set; }
        public virtual ICollection<TProyectos> TProyectos { get; set; }
    }
}
