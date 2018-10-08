using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class PermissionT
    {
        public int AutoId { get; set; }
        public int? PermId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public int? Permissionss { get; set; }
        public double? TillDate { get; set; }
        public int? DBid { get; set; }
        public string LoginName { get; set; }
        public int? Dormant { get; set; }
        public double? ModTime { get; set; }
        public string CTerminal { get; set; }

    }
}
