using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TBlog
    {
        public Guid PublId { get; set; }
        public string PublName { get; set; }
        public string PublDesc { get; set; }
        public string PublBody { get; set; }
        public DateTime? PublDate { get; set; }
        public Guid? FkUserUserId { get; set; }

        public virtual TUser FkUserUser { get; set; }
    }
}
