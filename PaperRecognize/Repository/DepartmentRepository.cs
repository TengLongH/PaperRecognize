using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaperRecognize.Models;
using PaperRecognize.DTOs.DepartmentDTO;
using AutoMapper;

namespace PaperRecognize.Repository
{
    public class DepartmentRepository
    {
        private DBModel context = new DBModel();

        public IEnumerable<GetDepartmentDTO> GetDepartments() 
        {
            return context.Department.Select(Mapper.Map<GetDepartmentDTO>).ToList();
        }

        public IEnumerable<GetDepartmentDTO> GetColleges()
        {
            return context.Department
                .Where( d =>d.Type >= 10 && d.Type < 20 )
                .Select(Mapper.Map<GetDepartmentDTO>).ToList();
        }

    }
}