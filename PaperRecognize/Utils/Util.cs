using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PaperRecognize.DTOs;
using System.Web.SessionState;

namespace PaperRecognize.Utils
{
    public class Util
    {
        public static bool isSchoolAdmin(HttpSessionState session)
        {
            int role = GetRole(session);
            return role == (int)UserRole.SCHOOLADMIN;
        }
        public static bool isSchoolDepartAdmin(HttpSessionState session)
        {
            int role = GetRole(session);
            return role == (int)UserRole.DEPTADMIN;
        }
        public static bool isSchoolExpert(HttpSessionState session)
        {
            int role = GetRole(session);
            return role == (int)UserRole.COMMON;
        }
      
        private static int GetRole(HttpSessionState session)
        {
            if (null == session["role"]) throw new Exception("please login");
            try
            {
                int role = int.Parse(session["role"].ToString());
                return role;
            }
            catch (Exception e)
            {
                throw new Exception("unknown error");
            }
        }
    }
}