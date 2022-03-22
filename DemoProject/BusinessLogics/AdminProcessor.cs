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
        // Business logics to add new Admin
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
        // Crud on Users
        // To Read All the Active Users
        public static List<User> GetUsers()
        {
            return SqlDataAccess.LoadDataList<User>("select * from users where isDelete = 0;", new DynamicParameters());
        }
        // To Read the Specific User
        public static User GetSpecificUsers(int Id)
        {
            return SqlDataAccess.GetDataModel<User>($"select * from users where UserId = {Id};", new DynamicParameters());
        }
        // To insert New user
        public static int InsertUser(User user)
        {
            DynamicParameters dbarg = new DynamicParameters();
            dbarg.Add("@FirstName", user.FirstName);
            dbarg.Add("@LastName", user.LastName);
            dbarg.Add("@Email", user.Email);
            dbarg.Add("@Address", user.Address);
            dbarg.Add("@MobileNumber", user.MobileNumber);
            dbarg.Add("@Password", user.Password);
            string query = $@"insert into Users (FirstName, LastName, Email, Address, MobileNumber, Password) VALUES (@FirstName, @LastName, @Email, @Address, @MobileNumber, @Password)";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
        // To update existing user
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
            string query = $@"Update Users Set FirstName=@FirstName, LastName=@LastName, Email=@Email, Address=@Address, MobileNumber=@MobileNumber, Password=@Password where UserId = @UserId";
            return SqlDataAccess.insertDataDapper(query, dbarg);
        }
        // To delete specific user
        public static int DeleteUser(int Id)
        {
            return SqlDataAccess.insertDataDapper($"Update Users set isDelete=1 where UserId = {Id} ", new DynamicParameters());
        }
    }
}
