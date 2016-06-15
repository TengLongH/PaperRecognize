using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using PaperRecognize.DTOs;
using PaperRecognize.Models;

namespace PaperRecognize.AutoMapperConfig
{
    public class MapperConfig
    {
        public void config()
        {
            Mapper.Initialize( mapper => {
                mapper.CreateMap<Paper, GetOnePaperDTO>();
                mapper.CreateMap<Author, GetOneAuthorDTO>();
                mapper.CreateMap<Author_Person, GetAuthorPersonDTO>();
                mapper.CreateMap<Author_Person, Author_Person>();

                mapper.CreateMap<Person, GetPersonDTO>();
                 

            });
           
        }
    }
}