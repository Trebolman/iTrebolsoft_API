using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TBlog
    {
        public TBlog()
        {
            TImages = new HashSet<TImages>();
        }

        public Guid PublId { get; set; }
        public string PublName { get; set; }
        public string PublDesc { get; set; }
        public string PublBody { get; set; }
        public DateTime? PublDate { get; set; }
        public Guid? FkTUserUserId { get; set; }

        public virtual TUser FkTUserUser { get; set; }
        public virtual ICollection<TImages> TImages { get; set; }
    }
}
