using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualLibrarity.Models
{
    public struct RegisterArgs
    {
        public User User { get; set; }
        public string Image { get; set; }
    }
}