using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchMod.Models
{
    public class DataResult
    {
        public IEnumerable result { get; set; }
        public int count { get; set; }
        public IEnumerable aggregate { get; set; }
        public IEnumerable groupDs { get; set; }
    }
}
