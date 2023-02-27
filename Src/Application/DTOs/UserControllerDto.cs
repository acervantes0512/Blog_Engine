using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UserControllerDto
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
    }
}
