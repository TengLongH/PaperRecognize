﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaperRecognize.Repository;
using PaperRecognize.DTOs;
using PaperRecognize.Business;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using PaperRecognize.Import;

namespace PaperRecognize.Controllers
{
    public class RecognizeController : ApiController
    {
        private RecognizeRepository repository = new RecognizeRepository();

        [Route("api/recognize/papers/{page}")]
        public IEnumerable<GetOnePaperDTO> GetPapers(int page)
        {
            return repository.GetPapers(page);
        }
        [Route("api/recognize/paper/{paperId}")]
        public GetOnePaperDTO GetOnePaper(int paperId)
        {
            return repository.GetOnePaper(paperId);
        }

        public IEnumerable<GetAuthorPersonDTO> Put(UpdateAuthorPersonDTO update)
        {
            return repository.UpdateAuthorPerson(update);
        }

        [Route("api/recognize/pretreatment")]
        public string PostPretreatment()
        {
            Pretreatment p = new Pretreatment();
            try
            {
                p.pretreatPaper();
            }
            catch (Exception e)
            {
                return e.Message + e.StackTrace;
            }

            return "sucess";
        }


        [Route("api/recognize/import")]
        public string PutImportPaper()
        {
            string path = HttpRuntime.AppDomainAppPath + @"App_Data/Paper";
            string[] files = Directory.GetFiles(path);
            if (null == files) return "success";
            ImportPaper import = new ImportPaper();
            foreach (string name in files)
            {
                if (name.EndsWith(".xls") || name.EndsWith(".xlsx"))
                {
                    import.ExcelToSQLServer(name, "Sheet1", true);
                    File.Delete( name );
                }
            }
            return "success";
        }

        [Route("api/recognize/search")]
        public string PutSearchAuthor()
        {
            string response = DateTime.Now.ToString();
            LookupAuthor lookup = new LookupAuthor();
            lookup.LookupPapers();
            return response + " to " + DateTime.Now.ToString();
        }
    }
}
