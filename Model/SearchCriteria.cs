using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_JWTAuthentication.Model
{
    public partial class SearchCriteria
    {
        [Required]
        public string FromDate { get; set; }
        [Required]
        public string ToDate { get; set; }
    }
}
