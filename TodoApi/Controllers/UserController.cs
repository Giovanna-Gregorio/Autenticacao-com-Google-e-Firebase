using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public User Get()
        {
            var firebase = User.Claims.Where(x => x.Type == "firebase").FirstOrDefault().Value;
            var ret = JsonConvert.DeserializeObject<Firebase>(firebase);

            return new User
            {
                Name =  User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value,
                UserId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value,
                Email = ret.identities.email.FirstOrDefault().ToString(),
                EmailVerified = User.Claims.Where(x => x.Type == "email_verified").FirstOrDefault().Value,
                Picture = User.Claims.Where(x => x.Type == "picture").FirstOrDefault().Value
            };
        }
    }
}
