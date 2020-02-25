using System.Collections.Generic;

namespace Application.Features.TableGenerator.Models
{
	public class Table
	{
		public StyleData Settings { get; set; } = new StyleData();
		public IEnumerable<StyleData> Rows { get; set; } = new List<StyleData>();
		public IEnumerable<StyleData> Columns { get; set; } = new List<StyleData>();
		public IEnumerable<IEnumerable<CellData>> Cells { get; set; } = new List<List<CellData>>();
	}
}