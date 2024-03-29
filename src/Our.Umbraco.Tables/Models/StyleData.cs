﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Our.Umbraco.Tables.Enums;

namespace Our.Umbraco.Tables.Models
{
	public class StyleData
	{
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("backgroundColor")]
		public BackgroundColour BackgroundColor { get; set; } = BackgroundColour.None;

		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("columnWidth")]
		public ColumnWidth ColumnWidth { get; set; } = ColumnWidth.None;
	}
}