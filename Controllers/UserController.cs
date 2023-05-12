using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Xml.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // GET api/<UserController>/5
        [HttpGet("GetUsers")]
        public string GetAll()
        {
            string userJSON = "Is Empty, Create a new user to Get all users";
            foreach (User user in users)
            {
                if(user != null)
                {
                    userJSON += "\n{" + JsonSerializer.Serialize(user.ToString()) + "}";
                }
                
            }
            string format = userJSON.Replace("Is Empty, Create a new user to Get all users\n", "");
            format = format.Replace("\n", ", ");
            //string json = JsonSerializer.Serialize(userJSON);
            return (format);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            User user = users.Find(u => u.Id == id)!;
            string json = JsonSerializer.Serialize(user.ToString());
            return (json);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(string name, string email, string birthDate)
        {
            User user = new User(name, email, birthDate);
            users.Add(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, string name, string email, string birthDate)
        {
            User user = users.Find(u => u.Id == id)!;
            user.Name = name;
            user.Email = email;
            user.BirthDate = DateTime.Parse(birthDate);
            user.CreatedUserDate = DateTime.Now;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = users.Find(u => u.Id == id)!;
            users.Remove(user);
        }
    }
}
