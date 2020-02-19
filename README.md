Our.Umbraco.Tables
=====================

An Umbraco 8+ property editor for generating tabular data in the CMS.
It is created as a data type and then used as a property of a doctype. There is a PropertyValueConverter that will convert the stored data to a strongly typed set of objects when used with ModelsBuilder.

### Install ###

`PM> Install-Package [TBC]`

**Umbraco Package:** http://our.umbraco.org/projects/developer-tools/[TBC]

**NuGet Package:** https://www.nuget.org/packages/[TBC]

### Use ###

After installation, Umbraco should automatically find the Table Generator and make it available to you when creating a new data type.

Create a new data type in 'Settings / Data Types' and choose 'Table Generator' from the drop down.

This is now ready to use on a Document Type.

### Output ###

If using ModelsBuilder the property should appear as a class
`Our.Umbraco.Tables.Models.TableData`

This contains all the rows, columns, cells and settings. You are free to output this how you see fit. There is a demo site with razor markup to generate a table using Bootstrap classes.


Simplified, you can generate a table with something like this

    @using Our.Umbraco.Tables.Enums
    @using Our.Umbraco.Tables.Models
    @model Our.Umbraco.Tables.Models.TableData

    @{
        var firstRow = Model.Cells.FirstOrDefault();
        var rows = Model.Rows.ToList();
        var columns = Model.Columns.ToList();
        var tableStyles = Model.Settings;
    }

    @if (firstRow != null)
    {
        <table class="@GetCssClass(tableStyles)">
            <thead>
                <tr class="@GetCssClass(tableStyles, Model.Rows.FirstOrDefault())">
                    @foreach (var cell in firstRow)
                    {
                        <th class="@GetCssClass(tableStyles, columns[cell.ColumnIndex])" scope="col">
                            @Html.Raw(cell.Value)
                        </th>
                    }
                </tr>
            </thead>
            <tbody>
                @foreach (var row in Model.Cells.Skip(1))
                {
                    <tr class="@GetCssClass(tableStyles, rows[row.FirstOrDefault().RowIndex])">
                        @foreach (var cell in row)
                        {
                            <td class="@GetCssClass(tableStyles, columns[cell.ColumnIndex])">
                                @Html.Raw(cell.Value)
                            </td>
                        }
                    </tr>
                }
            </tbody>
        </table>
    }

    @functions
    {
        public string GetCssClass(StyleData tableStyles, StyleData styleData = null)
        {
            var styles = tableStyles.BackgroundColor != BackgroundColour.None
                            ? tableStyles.BackgroundColor
                            : styleData?.BackgroundColor ?? BackgroundColour.None;

            switch (styles)
            {
                case BackgroundColour.OddEven:
                    return "is-odd-even";
                case BackgroundColour.OddEvenReverse:
                    return "is-odd-even-reversed";
                case BackgroundColour.Primary:
                    return "is-primary";
                case BackgroundColour.Secondary:
                    return "is-secondary";
                case BackgroundColour.Tertiary:
                    return "is-tertiary";
                default:
                    return null;
            }
        }
    }