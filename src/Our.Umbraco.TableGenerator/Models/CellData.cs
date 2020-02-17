using Newtonsoft.Json;

namespace Our.Umbraco.TableGenerator.Models
{
	public class CellData
	{
		[JsonProperty("rowIndex")]
		public int RowIndex { get; set; } = 0;

		[JsonProperty("columnIndex")]
		public int ColumnIndex { get; set; } = 0;

		[JsonProperty("value")]
		public string Value { get; set; } = string.Empty;
	}
}