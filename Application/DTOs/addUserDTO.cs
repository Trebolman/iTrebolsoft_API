using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class AddUserDTO
    {
        //public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGit { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoto { get; set; }
        public string UserWeb { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
