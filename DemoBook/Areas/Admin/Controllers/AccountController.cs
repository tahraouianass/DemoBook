using Domain.Entity;
using Elfie.Serialization;
using Infrastructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController( RoleManager<IdentityRole> roleManager )
        {
            _roleManager = roleManager;
        }
        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var model = new RolesViewModel
            {
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                NewRole = new NewRole()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Roles(RolesViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                //var role = new IdentityRole
                //{
                //    Id = model.NewRole.RoleId,
                //    Name = model.NewRole.RoleName
                //};
                // Create
                if (model.NewRole.Id == null)
                {
                    //role.Id = Guid.NewGuid().ToString();
                    var result = await _roleManager.CreateAsync(new IdentityRole(model.NewRole.Name));

                    if (result.Succeeded)// Succeeded 
                        SessionMsg(Helper.Success, "Save", "SaveMsgRole");
                    else // Not Successeded
                        SessionMsg(Helper.Error, "NotSaved", "NotSavedMsgRole");
                }//Update
                else
                {
                    var RoleUpdate = await _roleManager.FindByIdAsync(model.NewRole.Id);
                    RoleUpdate.Id = model.NewRole.Id;
                    RoleUpdate.Name = model.NewRole.Name;
                    var Result = await _roleManager.UpdateAsync(RoleUpdate);
                    if (Result.Succeeded) // Succeeded
                        SessionMsg(Helper.Success, "Update", "UpdateMsgRole");
                    else  // Not Successeded
                        SessionMsg(Helper.Error, "NotUpdate", "NotUpdateMsgRole");
                }
            //}
            return RedirectToAction("Roles");
        }

        
        public async Task<IActionResult> DeleteRole(string id)
        {
            var Role = await _roleManager.FindByIdAsync(id);
            if(Role == null)
            {
                SessionMsg(Helper.Error, "NotFound", "NotFount");
            }
            else
            {
               await _roleManager.DeleteAsync(Role);
                SessionMsg(Helper.Success, "Deleted", "Success Deleted");
            }
           return RedirectToAction("Roles");
        }




        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }

    }
}
