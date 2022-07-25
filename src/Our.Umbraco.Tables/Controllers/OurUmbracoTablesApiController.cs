using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.Tables.Controllers
{
	[PluginController(Constants.AreaName)]
	public class OurUmbracoTablesApiController : UmbracoAuthorizedApiController
	{
		private readonly IDataTypeService _dataTypeService;
		private readonly IUmbracoMapper _umbracoMapper;

		public OurUmbracoTablesApiController(IDataTypeService dataTypeService, IUmbracoMapper umbracoMapper)
		{
			this._dataTypeService = dataTypeService;
			this._umbracoMapper = umbracoMapper;
		}

		public DataTypeDisplay GetDataType()
		{
			var dataType = _dataTypeService.GetDataType(Constants.DataTypeName);
			return dataType == null ? null : _umbracoMapper.Map<IDataType, DataTypeDisplay>(dataType);
		}
	}
}
