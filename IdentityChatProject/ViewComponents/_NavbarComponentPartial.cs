using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.ViewComponents
{
	public class _NavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
