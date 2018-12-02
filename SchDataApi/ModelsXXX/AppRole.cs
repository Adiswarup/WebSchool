using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SchDataApi.Models
{
    public class AppRole :IdentityRole<Guid>     
    {
        public string Users { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; }
    }
}
