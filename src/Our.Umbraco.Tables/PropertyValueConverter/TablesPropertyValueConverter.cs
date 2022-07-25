using System;
using Our.Umbraco.Tables.Models;
using System.Text.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Our.Umbraco.Tables.PropertyValueConverter
{
	public class TablesPropertyValueConverter : PropertyValueConverterBase
	{
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
			return inter == null
				? new TableData()
				: JsonSerializer.Deserialize<TableData>(inter.ToString());
		}
	}
}