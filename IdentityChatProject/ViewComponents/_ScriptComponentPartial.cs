using Microsoft.AspNetCore.Mvc;

namespace IdentityChatProject.ViewComponents
{
	public class _ScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
