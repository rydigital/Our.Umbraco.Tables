using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Our.Umbraco.Tables.Models
{
	public class TableData
	{
		[JsonPropertyName("settings")]
		public StyleData Settings { get; set; } = new StyleData();

		[JsonPropertyName("rows")]
		public IEnumerable<StyleData> Rows { get; set; } = new List<StyleData>();

		[JsonPropertyName("columns")]
		public IEnumerable<StyleData> Columns { get; set; } = new List<StyleData>();

		[JsonPropertyName("cells")]
		public IEnumerable<IEnumerable<CellData>> Cells { get; set; } = new List<List<CellData>>();
	}
}