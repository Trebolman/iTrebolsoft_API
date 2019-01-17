using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TImages
    {
        public Guid ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public Guid? FkTProductoProdId { get; set; }

        public virtual TProducto FkTProductoProd { get; set; }
    }
}
