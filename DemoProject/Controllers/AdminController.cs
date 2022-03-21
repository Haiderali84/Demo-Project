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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route(nameof(GetUser))]
        public string GetUser()
        {
            var result = BusinessLogics.UsersProcessor.GetUsers();
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(InsertUser))]
        public string InsertUser([FromForm] User user)
        {
            var result = BusinessLogics.UsersProcessor.InsertUser(user);
            return JsonConvert.SerializeObject(result);
        }
        [HttpDelete]
        [Route(nameof(DeleteUser))]
        public string DeleteUser(int Id)
        {
            var result = BusinessLogics.UsersProcessor.DeleteUser(Id);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(UpdateUser))]
        public string UpdateUser(User user)
        {
            var result = BusinessLogics.UsersProcessor.UpdateUser(user);
            return JsonConvert.SerializeObject(result);
        }
        [HttpPost]
        [Route(nameof(InsertAdmin))]
        public string InsertAdmin(Admin admin)
        {
            var result = BusinessLogics.AdminProcessor.InsertAdmin(admin);
            return JsonConvert.SerializeObject(result);
        }
    }
}
