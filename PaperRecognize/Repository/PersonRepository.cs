using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using PaperRecognize.Models;
using PaperRecognize.DTOs.PersonDTO;
using System.Data.Common;
using PaperRecognize.DTOs;
using System.Data.SqlClient;

namespace PaperRecognize.Repository
{
    public class PersonRepository
    {
        private DBModel context = new DBModel();

        public IEnumerable<GetPersonDTO> GetManager()
        {
            List<GetPersonDTO> persons = null;
            string sql = "select * from Person where PersonNo in ( select Name from [User] where Role = 1 )";
            persons = context.Database.SqlQuery<GetPersonDTO>(sql).ToList();
            return persons;
        }
        public IEnumerable<GetPersonDTO> GetDepartExpert( int departId )
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select Id,PersonNo,NameCN,NameEN,Sex,Mobile,Email from Person where PersonType = ");
            sqlBuilder.Append(0);
            sqlBuilder.Append(" and Id in ( select PersonId from Person_Department where DepartmentId = ");
            sqlBuilder.Append(departId);
            sqlBuilder.Append(")");
            
            List<GetPersonDTO> experts = context.Database.SqlQuery<GetPersonDTO>( sqlBuilder.ToString())
                .ToList();
            return experts;
        }
    }
}