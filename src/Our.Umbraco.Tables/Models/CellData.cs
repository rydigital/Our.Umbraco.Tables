using System.Text.Json.Serialization;

namespace Our.Umbraco.Tables.Models
{
	public class CellData
	{
		[JsonPropertyName("rowIndex")]
		public int RowIndex { get; set; } = 0;

		[JsonPropertyName("columnIndex")]
		public int ColumnIndex { get; set; } = 0;

		[JsonPropertyName("value")]
		public string Value { get; set; } = string.Empty;
	}
}