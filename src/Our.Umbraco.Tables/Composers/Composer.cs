using Our.Umbraco.Tables.ManifestFilters;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Tables.Composers
{
	public class Composer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.ManifestFilters().Append<ManifestFilter>();
		}
	}
}
