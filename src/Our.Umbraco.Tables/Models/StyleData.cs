using Our.Umbraco.Tables.Enums;
using System.Text.Json.Serialization;

namespace Our.Umbraco.Tables.Models
{
	public class StyleData
	{
		[JsonConverter(typeof(JsonStringEnumConverter))]
		[JsonPropertyName("backgroundColor")]
		public BackgroundColour BackgroundColor { get; set; } = BackgroundColour.None;
	}
}