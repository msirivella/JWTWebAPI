using System;
using System.Collections.Generic;

namespace API_JWTAuthentication.Model
{
    public partial class Attendance
    {
        public int Employeeid { get; set; }
        public string Shiftdate { get; set; }
        public string Intime { get; set; }
        public string Outtime { get; set; }
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
