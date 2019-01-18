using System;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserRango { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserWeb { get; set; }
        public string Token { get; set; }
    }
}
