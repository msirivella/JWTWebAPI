using System;
using System.Collections.Generic;

namespace API_JWTAuthentication.Model
{
    public partial class OtData
    {
        public int Employeeid { get; set; }
        public string Shiftdate { get; set; }
        public int? Normalot { get; set; }
        public int? Premiumot { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
