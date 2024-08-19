using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructre.ViewModel
{
    public class RolesViewModel
    {
        public List<IdentityRole>? Roles { get; set; }
        public NewRole NewRole { get; set; }
    }

    public class NewRole
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
