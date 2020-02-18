using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Our.Umbraco.TableGenerator.Enums;

namespace Our.Umbraco.TableGenerator.Models
{
	public class StyleData
	{
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("backgroundColor")]
		public BackgroundColour BackgroundColor { get; set; } = BackgroundColour.None;
	}
}