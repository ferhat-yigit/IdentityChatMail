using IdentityChatProject.Entities;
using IdentityChatProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}


		[HttpGet]
		public async Task<IActionResult> UserDetail()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var model = new UserUpdateViewModel
			{
				Name = user.Name,
				Surname = user.Surname,
				Email = user.Email,
				Username = user.UserName,
				PhoneNumber = user.PhoneNumber
			};
			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> UserDetail(UserUpdateViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Email;
			user.UserName = model.Username;
			user.PhoneNumber = model.PhoneNumber;

			if (!string.IsNullOrEmpty(model.Password))
			{
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
			}

			var result = await _userManager.UpdateAsync(user);

			if (result.Succeeded)
			{
				TempData["Success"] = "Profil güncellendi.";
				return RedirectToAction("UserDetail");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View(model);
			}
		}

	}
}
