using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TProducto
    {
        public TProducto()
        {
            TImages = new HashSet<TImages>();
        }

        public Guid ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdCod { get; set; }
        public string ProdDesc { get; set; }
        public string ProdStock { get; set; }
        public string ProdBrand { get; set; }
        public string ProdPrice { get; set; }
        public Guid? FkUserUserId { get; set; }

        public virtual TUser FkUserUser { get; set; }
        public virtual ICollection<TImages> TImages { get; set; }
    }
}
