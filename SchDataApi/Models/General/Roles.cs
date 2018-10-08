using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class Roles
    {
        public int AutoId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleFnName { get; set; }
        public string RoleSet { get; set; }
        public int? DefaultPermission { get; set; }
        public int DefaultLevel { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }
        public int? DBid { get; set; }
    }
}
