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
        public static User GetPersonalData(int Id)
        {
            return SqlDataAccess.GetDataModel<User>($"select * from users where UserId = {Id};", new DynamicParameters());
        }
    }
}
