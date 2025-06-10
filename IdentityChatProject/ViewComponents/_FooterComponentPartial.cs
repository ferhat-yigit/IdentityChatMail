using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.ViewComponents
{
	public class _FooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
