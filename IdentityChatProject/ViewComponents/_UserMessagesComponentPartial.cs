using IdentityChatProject.Context;
using IdentityChatProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.ViewComponents
{
	public class _UserMessagesComponentPartial : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly MailContext _context;

		public _UserMessagesComponentPartial(MailContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var messages = _context.Messages.Where(m => m.ReceiverEmail == user.Email && !m.IsRead)
			.OrderByDescending(m => m.SendDate)
			.ToList();

			return View("Default", messages);
		}
	}
}