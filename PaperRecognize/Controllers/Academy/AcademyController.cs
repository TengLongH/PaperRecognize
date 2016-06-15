using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaperRecognize.DTOs;
using PaperRecognize.Repository;
using PaperRecognize.Models;
namespace PaperRecognize.Controllers.Academy
{
    public class AcademyController : ApiController
    {
        private RecognizeRepository repository;

        [Route("api/academy/getManagers")]
        public IEnumerable<GetPersonDTO> GetManagers()
        {
            IEnumerable<GetPersonDTO> managers;
            managers = repository.GetPerson( Role.DEPTADMIN );
            return managers;
        }
    }
}
