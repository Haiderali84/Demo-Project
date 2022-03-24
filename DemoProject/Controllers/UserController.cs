using Dapper;
using DemoProject.DataAccess;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // User detail for its dashboard
        [HttpGet]
        [Route(nameof(GetDetail))]
        public string GetDetail(int Id)
        {
            var result = BusinessLogics.UsersProcessor.GetPersonalData(Id);
            return JsonConvert.SerializeObject(result);
        }
        // Update user data
        [HttpPost]
        [Route(nameof(UpdateInformation))]
        public string UpdateInformation(User user)
        {
            var result = BusinessLogics.AdminProcessor.UpdateUser(user);
            return JsonConvert.SerializeObject(result);
        }
        // Get all activities 
        [HttpGet]
        [Route(nameof(GetActivities))]
        public string GetActivities()
        {
            var result = BusinessLogics.ActivityProcessor.GetActivities();
            return JsonConvert.SerializeObject(result);
        }

        [HttpGet]
        [Route(nameof(GetSpecificActivity))]
        public string GetSpecificActivity(int id)
        {
            var result = BusinessLogics.ActivityProcessor.GetSpecificActivity(id);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(InsertActivity))]
        public string InsertActivity([FromBody]Activity activity)
        {
            var result = BusinessLogics.ActivityProcessor.InsertActivity(activity);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(UpdateActivity))]
        public string UpdateActivity([FromBody] Activity activity)
        {
            var result = BusinessLogics.ActivityProcessor.UpdateActivity(activity);
            return JsonConvert.SerializeObject(result);
        }
        [HttpDelete]
        [Route(nameof(DeleteActivity))]
        public string DeleteActivity(int id)
        {
            var result = BusinessLogics.ActivityProcessor.DeleteActivity(id);
            return JsonConvert.SerializeObject(result);
        }
    }
}
