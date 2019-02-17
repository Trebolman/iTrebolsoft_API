using System;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastname { get; set; }
        public string UserGit { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoto { get; set; }
        public string UserWeb { get; set; }
        public string Token { get; set; }
    }
}
