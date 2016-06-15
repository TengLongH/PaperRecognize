using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaperRecognize.Models;
using PaperRecognize.DTOs.Login;
using System.Web;
namespace PaperRecognize.Controllers.Login
{
    public class LoginController : ApiController
    {
        private DBModel context = new DBModel();

        [Route("api/Login")]
        public string Post( LoginDTO dto )
        {
            if (null == dto.Name || null == dto.Password )
            {
                return "username password can't be empty";
            }
            string sql = "select * from User where Name={0} and Password={1}";
            List<User> users = context.Database.SqlQuery<User>(sql, dto.Name, dto.Password).ToList();
            if (null == users || users.Count <= 0) return "can't find the user";
            var session = HttpContext.Current.Session;
            session.Add("username", users[0].Name );
            session.Add("role", users[0].Role );
            return "success";
        }
    }
}
