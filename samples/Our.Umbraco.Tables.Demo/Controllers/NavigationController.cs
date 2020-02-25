using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Our.Umbraco.Tables.Demo.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace Our.Umbraco.Tables.Demo.Controllers
{
	public class NavigationController : SurfaceController
	{
		public PartialViewResult Render()
		{
			var root = this.Umbraco.ContentAtRoot().FirstOrDefault(x => x.ContentType.Alias.Equals(Home.ModelTypeAlias));
			var navigationItems = new List<IPublishedContent>();

			if (root != null)
			{
				navigationItems.AddRange(root.Children);
			}

			return this.PartialView("_Navigation", navigationItems);
		}
	}
}