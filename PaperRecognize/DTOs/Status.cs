using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperRecognize.DTOs
{
    public enum PaperStatus
    {
        ANALISIS,
        CONFIRM,
        DEAL
    }
    public enum AuthorPersonStatus
    {
        CONFIRM,
        RIGHT,
        WRONG,
        DISPATCH,
        REJECT,
        CLAIM,
        UNCLAIM
    }
    public enum Role
    {
        SCHOOLADMIN = 10,
        DEPTADMIN = 1,
        EXPERT = 2,
        STUDENT
    }

    public enum DepartmentType
    {
        SCHOOL = 1,
        COLLEGE = 10,
        DEPARTMENT = 20,
        LAB= 21,
        INSTITUTE = 22

    }
}