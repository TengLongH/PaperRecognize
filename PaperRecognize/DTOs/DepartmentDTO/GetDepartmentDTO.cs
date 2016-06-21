using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperRecognize.DTOs.DepartmentDTO
{
    public class GetDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}