using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.Core.Models
{
    public class ApplicationUser :  IdentityUser
    {
       [Required]
       public int  FullName { get; set; }
        public int Picture { get; set; }

        public string Group { get; set; }
    }
}
