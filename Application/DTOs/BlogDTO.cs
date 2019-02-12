using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class BlogDTO
    {
        public Guid PublId { get; set; }
        public string PublName { get; set; }
        public string PublDesc { get; set; }
        public string PublBody { get; set; }
        public DateTime PublDate { get; set; }
        public Guid? FkTUserUserId { get; set; }
    }
}
