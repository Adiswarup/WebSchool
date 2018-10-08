using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebCat7.Models
{
    [Table("AspNetUsers")]
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class AppUser : IdentityUser<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        //public string BUserName { get; set; }
        public string Mobile { get; set; }
        public string WGroup { get; set; }
        public string Roles { get; set; }

        public DateTime ExpDate { get; set; }
    }
}
