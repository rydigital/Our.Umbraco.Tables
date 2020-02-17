using System.Collections.Generic;
using Newtonsoft.Json;

namespace Our.Umbraco.TableGenerator.Models
{
	public class TableData
	{
		[JsonProperty("settings")]
		public StyleData Settings { get; set; } = new StyleData();

		[JsonProperty("rows")]
		public IEnumerable<StyleData> Rows { get; set; } = new List<StyleData>();

		[JsonProperty("columns")]
		public IEnumerable<StyleData> Columns { get; set; } = new List<StyleData>();

		[JsonProperty("cells")]
		public IEnumerable<IEnumerable<CellData>> Cells { get; set; } = new List<List<CellData>>();
	}
}