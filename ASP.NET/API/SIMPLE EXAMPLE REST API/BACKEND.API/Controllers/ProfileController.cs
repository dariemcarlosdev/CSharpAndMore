using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKEND.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        [HttpGet("api/GetProfile/{id}")]
        public string GetProfile(int id)
        {

            return id switch
            {
                1 => "Dariem",
                2 => "Curso",
                _ => throw new NotSupportedException("ID does not exist") 
            };
        }

        [HttpPost("api/PostProfile/")]
        public List<string> PostProfile(ProfileDTO profile)
        {
            List<string> respose = new List<string>();
            respose.Add("New Name added: " + profile.Name);
            respose.Add("Server Response Code: " + Response.StatusCode.ToString());
            return respose;

        }
    }
}
