using Dapper;
using DemoProject.DataAccess;
using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.BusinessLogics
{
    public class UsersProcessor
    {
        public static List<User> GetUsers()
        {
            return SqlDataAccess.LoadDataList<User>("select * from users where isDelete = 0;", new DynamicParameters());
        }
        public static int InsertUser(User user)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@FirstName", user.FirstName);
            dbarg.Add("@LastName", user.LastName);
            dbarg.Add("@Email", user.Email);
            dbarg.Add("@Address", user.Address);
            dbarg.Add("@MobileNumber", user.MobileNumber);
            dbarg.Add("@Password", user.Password);
            string query = $@"insert into User (FirstName, LastName, Email, Address, MobileNumber, Password) VALUES (@FirstName, @LastName, @Email, @Address, @MobileNumber, @Password)";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
        public static int UpdateUser(User user)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@UserId", user.UserId);
            dbarg.Add("@FirstName", user.FirstName);
            dbarg.Add("@LastName", user.LastName);
            dbarg.Add("@Email", user.Email);
            dbarg.Add("@Address", user.Address);
            dbarg.Add("@MobileNumber", user.MobileNumber);
            dbarg.Add("@Password", user.Password);
            string query = $@"Update User Set FirstName=@FirstName, LastName=@LastName, Email=@Email, Address=@Address, MobileNumber=@MobileNumber, Password=@Password";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
        public static int DeleteUser(int Id)
        {
            return SqlDataAccess.insertDataDapper($"Delete from User where userid={Id}", new DynamicParameters());
        }
        
    }
}
