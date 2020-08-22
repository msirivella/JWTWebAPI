using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Immutable;

namespace API_JWTAuthentication.Model.Repository
{
    public class Repository:IRepository
    {
        public JsonResult GetEmployeeDetails(string FromDate, String ToDate)
        {
            
            using (WebAPIContext data = new WebAPIContext())
            {

                try
                {


                    var ndata = (from e in data.Employee.ToList()
                                 join a in data.Attendance.ToList() on e.Id equals a.Employeeid
                                 join o in data.OtData.ToList() on e.Id equals o.Employeeid
                                 where DateTime.Parse(a.Shiftdate) >= DateTime.Parse(FromDate) && DateTime.Parse(a.Shiftdate) <= DateTime.Parse(ToDate)
                                 select new
                                 {
                                     EmployeeID = e.Id,
                                     EmployeeName = e.Name,
                                     ShiftDate = a.Shiftdate,
                                     InTime = a.Intime,
                                     OutTime = a.Outtime,
                                     NormalOT = o.Normalot,
                                     PremiumOT = o.Premiumot
                                 }).ToList();

                    data.Dispose();

                    if (ndata.Count > 0)
                    {
                        return new JsonResult(ndata);
                    }
                    else

                        return new JsonResult("No data found..");
                }
                catch(Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }
    }
}
