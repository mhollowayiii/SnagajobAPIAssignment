using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnagajobAPIAssignment.Models
{
    // model for binding json as described in assignment doc 
    public class Application
    {
        public string Name { get; set; }
        public List<ApplicationAnswer> Questions { get; set; }
    }
}