using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperRecognize.Models;
using PaperRecognize.DTOs.UserDTO;
using PaperRecognize.DTOs;
using System.Text.RegularExpressions;
using PaperRecognize.DTOs.PersonDTO;
using AutoMapper;

namespace PaperRecognize.Repository
{
    public class UserRepository
    {
        private DBModel context = new DBModel();

        public UserRepository()
        {
        }

        public IEnumerable<GetPersonDTO> GetManager()
        {
            List<GetPersonDTO> persons = null;
            string sql = "select PersonNo,NameCN,NameEN,Sex,Mobile,Email,DepartmentId from Person,[User] where [User].Role=1 and [User].Name=Person.PersonNo";
            persons = context.Database.SqlQuery<GetPersonDTO>(sql).ToList();
            return persons;
        }

        public string AddUser(AddUserDTO dto)
        {
            if (null == dto) return "request is usless";
            var person = context.Person.FirstOrDefault(p => p.PersonNo == dto.Name);
            if (null == person)
                return "this man is not our school teacher";
            var user = context.User.FirstOrDefault(u => u.Name == dto.Name && u.Role == dto.Role);
            if (null != user)
                return "user has exist";
            
            if (!AcceptPassword( dto.Password))
                return "password contains digital alphabet and underline the length is 6-20";
            if (!(dto.Role == (int)UserRole.DEPTADMIN || dto.Role == (int)UserRole.COMMON))
            {
                return "the role is error";
            }
            var depart = context.Department.FirstOrDefault(d => d.Id == dto.DepartmentId);
            if (depart == null)
                return "can't find the department";
            User newUser = Mapper.Map<User>( dto );
            context.User.Add( newUser );
            context.SaveChanges();
            return "success";
        }

        public string DeleteUser(GetUserDTO dto)
        {
            var user = context.User.First(u => u.Name == dto.Name && u.Role == dto.Role);
            if (null != user)
            {
                context.User.Remove(user);
                context.SaveChanges();
                return "success";
            }
            return "can't find the user";
        }

        public string UpdateUser(UpdateUserDTO dto)
        {
            var user = context.User.First(u => u.Name == dto.Name && u.Role == dto.Role);
            if (null == user)
                return "can't find the user";
           
            if( !AcceptPassword( dto.Password ) )
                return "password contains digital alphabet and underline the length is 6-20";

            user.Password = dto.Password;
            context.SaveChanges();
            return "success";
        }

        private bool AcceptPassword(string password)
        {
            if (null == password) return false;
            Regex reg = new Regex(@"\b(\w){6,20}\b");
            return reg.IsMatch(password);
        }
    }
}
