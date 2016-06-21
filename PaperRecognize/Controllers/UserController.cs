using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaperRecognize.Repository;
using PaperRecognize.DTOs;
using PaperRecognize.DTOs.UserDTO;
using PaperRecognize.DTOs.PersonDTO;


namespace PaperRecognize.Controllers
{
    public class UserController : ApiController
    {
        private UserRepository repository;

        public UserController() 
        {
            repository = new UserRepository();
        }

        [Route("api/managers")]
        public IEnumerable<GetPersonDTO> GetManagers()
        {
            IEnumerable<GetPersonDTO> managers;
            managers = repository.GetManager();
            return managers;
        }

        [Route("api/user/{name}/{role}")]
        public string DeleteUser( string name, int role ) 
        {
            return "";
            //return repository.DeleteUser( dto );
        }

        [Route("api/user")]
        public string PostUser( AddUserDTO dto )
        {
            return repository.AddUser(dto);
        }

        [Route("api/user")]
        public string PutUser(UpdateUserDTO dto)
        {
            return repository.UpdateUser( dto );
        }
    }
}
