using System.Globalization;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.Tables.NotificationHandlers
{
	public class StopOurUmbracoTablesRteDeleteNotificationHandler : INotificationHandler<DataTypeDeletingNotification>
	{
		private readonly ILocalizedTextService _localizedTextService;

		public StopOurUmbracoTablesRteDeleteNotificationHandler(ILocalizedTextService localizedTextService)
		{
			this._localizedTextService = localizedTextService;
		}

		public void Handle(DataTypeDeletingNotification notification)
		{
			foreach (var dt in notification.DeletedEntities)
			{
				if (dt.Name == Constants.DataTypeName && notification.Cancel)
				{
					notification.CancelOperation(new EventMessage("Error", _localizedTextService.Localize(Constants.AreaName, Constants.ErrorMessageKey, CultureInfo.CurrentCulture), EventMessageType.Error));
				}
			}
		}
	}
}
