using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.ViewComponents
{
	public class _MessageSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
