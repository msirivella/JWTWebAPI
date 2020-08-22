using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_JWTAuthentication.Model.Repository
{
    interface IRepository
    {
        JsonResult GetEmployeeDetails(string FromDate, string ToDate);
    }
}
