using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCat7.Auth
{
    public class SubTeacherRequirement: IAuthorizationRequirement
    {
     public SubTeacherRequirement(string  subject, string teacher, string clss)
    {
            subjectX = subject;
            subjectTeach = teacher;
            subjectClass = clss;
        }
        public string subjectTeach { get; set; }
        public string subjectX { get; set; }
        public string subjectClass { get; set; }
    }
}

