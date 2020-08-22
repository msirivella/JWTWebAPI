using System;
using System.Collections.Generic;

namespace API_JWTAuthentication.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Employeenumber { get; set; }
        public string Role { get; set; }
        public int? Active { get; set; }
    }
}
