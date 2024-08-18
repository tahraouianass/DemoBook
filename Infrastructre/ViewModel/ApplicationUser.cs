using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructre.ViewModel
{
	public class ApplicationUser : IdentityUser
	{
		public string name { get; set; }
		public string ImageUser { get; set; }
		public string ActiveUser { get; set; }
	}
}
