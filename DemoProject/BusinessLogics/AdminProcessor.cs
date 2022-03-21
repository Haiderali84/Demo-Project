using Dapper;
using DemoProject.DataAccess;
using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.BusinessLogics
{
    public class AdminProcessor
    {
        public static int InsertAdmin(Admin Admin)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@UserId", Admin.AdminId);
            dbarg.Add("@FirstName", Admin.FirstName);
            dbarg.Add("@LastName", Admin.LastName);
            dbarg.Add("@Email", Admin.Email);
            dbarg.Add("@Password", Admin.Password);
            string query = $@"Insert into Admin (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
    }
}
