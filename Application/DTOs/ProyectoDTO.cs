using System;

namespace Application.DTOs
{
    public class ProyectoDTO
    {
        public Guid ProyId { get; set; }
        public string ProyTitle { get; set; }
        public string ProyDesc { get; set; }
        public string ProyUrl { get; set; }
        public DateTime? ProyDate { get; set; }
        public Guid? FkTUserUserId { get; set; }
    }
}
