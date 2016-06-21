using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaperRecognize.Models;
using PaperRecognize.DTOs.Login;
using System.Web;
namespace PaperRecognize.Controllers
{
    public class LoginController : ApiController
    {
        private DBModel context = new DBModel();

        [Route("api/login")]
        public string Post( LoginDTO dto )
        {
            if (null == dto.Name || null == dto.Password )
            {
                return "username password can't be empty";
            }
            User user = context.User.FirstOrDefault(u => u.Role == dto.Role && u.Name == dto.Name && u.Password == dto.Password);
            if (null == user ) return "can't find the user";
            var session = HttpContext.Current.Session;
            session.Add("username", user.Name);
            session.Add("role", user.Role);
            return "success";
        }
    }
}
