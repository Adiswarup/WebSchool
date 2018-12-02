using System;
using System.Collections.Generic;

namespace SchDataApi.Models.General
{
    public partial class Images
    {
        public int AutoId { get; set; }
        public int? ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public double? ImageModTime { get; set; }
        public int? AccessLevel { get; set; }
        public int? Dormant { get; set; }
        public string CTerminal { get; set; }
        public string LoginName { get; set; }
        public double? ModTime { get; set; }
        public int? DBid { get; set; }
    }
}
