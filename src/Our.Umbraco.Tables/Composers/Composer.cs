using Our.Umbraco.Tables.Components;
using Our.Umbraco.Tables.ManifestFilters;
using Our.Umbraco.Tables.NotificationHandlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.Tables.Composers
{
	public class Composer : IComposer
	{
		public void Compose(IUmbracoBuilder builder)
		{
			builder.ManifestFilters().Append<ManifestFilter>();
			builder.AddComponent<OurUmbracoTablesRteComponent>();
			builder.AddNotificationHandler<DataTypeDeletingNotification, StopOurUmbracoTablesRteDeleteNotificationHandler>();
		}
	}
}
