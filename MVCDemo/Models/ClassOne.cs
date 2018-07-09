using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ClassOne
    {
        [Key]//Tied to class ID(Always tied to first one property)
        public int ClassID { get; set; }
        public String Name { get; set; }
        public int MyAge { get; set; }
    }
}