using System;
using System.Linq;
using Newtonsoft.Json;
using Our.Umbraco.Tables.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;
using Umbraco.Web.Macros;
using Umbraco.Web.PropertyEditors.ValueConverters;
using Umbraco.Web.Templates;

namespace Our.Umbraco.Tables.PropertyValueConverter
{
	public class TablesPropertyValueConverter : PropertyValueConverterBase
	{
		private readonly RteMacroRenderingValueConverter _rteRenderingValueConverter;

		public TablesPropertyValueConverter(IUmbracoContextAccessor umbracoContextAccessor,
			IMacroRenderer macroRenderer,
			HtmlLocalLinkParser linkParser,
			HtmlUrlParser urlParser,
			HtmlImageSourceParser imageSourceParser)
		{
			_rteRenderingValueConverter = new RteMacroRenderingValueConverter(umbracoContextAccessor, macroRenderer, linkParser, urlParser, imageSourceParser);
		}

		public override Type GetPropertyValueType(IPublishedPropertyType propertyType) => typeof(TableData);
		public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType) => PropertyCacheLevel.Element;

		public override bool IsConverter(IPublishedPropertyType propertyType)
		{
			return propertyType.EditorAlias.Equals("Our.Umbraco.Tables");
		}

		public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
		{
			return source?.ToString();
		}

		public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
		{
			if (inter is null)
				return new TableData();
			var tableData = JsonConvert.DeserializeObject<TableData>(inter.ToString());
			foreach (var cell in tableData.Cells.SelectMany(it => it))
			{
				cell.Value = _rteRenderingValueConverter.ConvertIntermediateToObject(owner, propertyType, referenceCacheLevel, cell.Value, preview)?.ToString();
			}
			return tableData;
		}
	}
}