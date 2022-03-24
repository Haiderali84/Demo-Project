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
    public class AdminController : Controller
    {
        //Crud on User
        [HttpGet]
        [Route(nameof(GetUser))]
        public string GetUser()
        {
            var result = BusinessLogics.AdminProcessor.GetUsers();
            return JsonConvert.SerializeObject(result);
        }
        [HttpGet]
        [Route(nameof(GetSpecificUsers))]
        public string GetSpecificUsers(int Id)
        {
            var result = BusinessLogics.AdminProcessor.GetSpecificUsers(Id);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(InsertUser))]
        public string InsertUser([FromBody] User user)
        {
            var result = BusinessLogics.AdminProcessor.InsertUser(user);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(UpdateUser))]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var result = BusinessLogics.AdminProcessor.UpdateUser(user);
            return Ok(new { message = "User created Successfully" });
        }
        [HttpDelete]
        [Route(nameof(DeleteUser))]
        public string DeleteUser(int Id)
        {
            var result = BusinessLogics.AdminProcessor.DeleteUser(Id);
            return JsonConvert.SerializeObject(result);
        }
        // Admin can Add Another Admin
        [HttpPost]
        [Route(nameof(InsertAdmin))]
        public string InsertAdmin(Admin admin)
        {
            var result = BusinessLogics.AdminProcessor.InsertAdmin(admin);
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
        public string InsertActivity([FromBody] Activity activity)
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
