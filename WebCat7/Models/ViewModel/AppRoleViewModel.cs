﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCat7.Models.ViewModel
{
    public class AppRoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
