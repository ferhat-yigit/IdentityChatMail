using IdentityChatProject.Context;
using IdentityChatProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.Controllers
{
	public class DefaultController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly MailContext _context;

		public DefaultController(UserManager<AppUser> userManager, MailContext context)
		{
			_userManager = userManager;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.v1 = _context.Messages.Where(x=>x.ReceiverEmail == user.Email).Count();//gelen
            ViewBag.v4 = _context.Messages.Where(x => x.SenderEmail == user.Email).Count();//gönderilen
            ViewBag.v2 = _context.Messages.Where(x=>x.ReceiverEmail == user.Email && x.IsRead == false).Count();//okunmayan
			ViewBag.v3 = _context.Messages.Where(x=>x.ReceiverEmail == user.Email && x.IsRead == true).Count();//okunmuş

			return View();
		}
	}
}
